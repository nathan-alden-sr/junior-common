using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Junior.Common
{
	/// <summary>
	/// A task scheduler that executes queued tasks asynchronously and provides a task that completes when all queued tasks have completed.
	/// </summary>
	/// <remarks>
	/// https://github.com/ChadBurggraf/parallel-extensions-extras/blob/master/TaskSchedulers/LimitedConcurrencyLevelTaskScheduler.cs
	/// </remarks>
	[DebuggerStepThrough]
	public class AwaitableTaskScheduler : TaskScheduler
	{
		private static readonly AwaitableTaskSchedulerFactory<AwaitableTaskScheduler> _factory = new AwaitableTaskSchedulerFactory<AwaitableTaskScheduler>();
		[ThreadStatic]
		private static bool _currentThreadIsProcessingItems;
		private readonly object _lockObject = new object();
		private readonly ManualResetEventSlim _manualResetEvent = new ManualResetEventSlim(false);
		private Task _completionTask;
		private int _taskCount;

		/// <summary>
		/// Gets a factory that can start a <see cref="Task"/> on an <see cref="AwaitableTaskScheduler"/>.
		/// </summary>
		public static AwaitableTaskSchedulerFactory<AwaitableTaskScheduler> Factory
		{
			get
			{
				return _factory;
			}
		}

		/// <summary>
		/// Gets a task that completes when all queued tasks have completed.
		/// </summary>
		public Task CompletionTask
		{
			get
			{
				return _completionTask ?? Task.Factory.Empty();
			}
		}

		/// <summary>
		/// Queues a <see cref="Task"/> to the scheduler.
		/// </summary>
		/// <param name="task">The <see cref="Task"/> to be queued.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="task"/> argument is null.</exception>
		protected override sealed void QueueTask(Task task)
		{
			task.ThrowIfNull("task");

			lock (_lockObject)
			{
				_completionTask = _completionTask ?? Task.Factory.StartNew(() => _manualResetEvent.Wait());
			}
			Interlocked.Increment(ref _taskCount);
			ThreadPool.UnsafeQueueUserWorkItem(
				state =>
					{
						// Note that the current thread is now processing work items.
						// This is necessary to enable inlining of tasks into this thread.
						_currentThreadIsProcessingItems = true;
						try
						{
							TryExecuteTaskWithCompletionTracking(task);
						}
						finally
						{
							// We're done processing items on the current thread
							_currentThreadIsProcessingItems = false;
						}
					},
				null);
		}

		/// <summary>
		/// Determines whether the provided <see cref="Task"/> can be executed synchronously in this call, and if it can, executes it.
		/// </summary>
		/// <returns>
		/// A Boolean value indicating whether the task was executed inline.
		/// </returns>
		/// <param name="task">The <see cref="Task"/> to be executed.</param>
		/// <param name="taskWasPreviouslyQueued">A Boolean denoting whether or not task has previously been queued. If this parameter is True, then the task may have been previously queued (scheduled); if False, then the task is known not to have been queued, and this call is being made in order to execute the task inline without queuing it.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="task"/> argument is null.</exception>
		/// <exception cref="InvalidOperationException">The <paramref name="task"/> was already executed.</exception>
		protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
		{
			task.ThrowIfNull("task");

			// If this thread isn't already processing a task, we don't support inlining
			if (!_currentThreadIsProcessingItems)
			{
				return false;
			}

			// If the task was previously queued, remove it from the queue
			if (taskWasPreviouslyQueued)
			{
				TryDequeue(task);
			}

			// Try to run the task.
			return TryExecuteTask(task);
		}

		/// <summary>
		/// For debugger support only, generates an enumerable of <see cref="Task"/> instances currently queued to the scheduler waiting to be executed.
		/// </summary>
		/// <returns>
		/// An enumerable that allows a debugger to traverse the tasks currently queued to this scheduler.
		/// </returns>
		/// <exception cref="NotSupportedException">Thrown always.</exception>
		protected override IEnumerable<Task> GetScheduledTasks()
		{
			throw new NotSupportedException("This scheduler does not track queued tasks.");
		}

		/// <summary>
		/// Attempts to execute the a task and track its completion.
		/// </summary>
		/// <param name="task">A task to execute.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="task"/> is null.</exception>
		protected virtual void TryExecuteTaskWithCompletionTracking(Task task)
		{
			task.ThrowIfNull("task");

			if (!TryExecuteTask(task))
			{
				return;
			}

			Interlocked.Decrement(ref _taskCount);
			if (_taskCount == 0)
			{
				_manualResetEvent.Set();
			}
		}
	}
}