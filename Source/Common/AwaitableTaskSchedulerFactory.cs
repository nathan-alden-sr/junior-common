using System;
using System.Threading;
using System.Threading.Tasks;

namespace Junior.Common
{
	/// <summary>
	/// Creates and starts a <see cref="T:System.Threading.Tasks.Task">Task</see> on a new <typeparamref name="T"/> instance.
	/// </summary>
	/// <typeparam name="T">An <see cref="AwaitableTaskScheduler"/>.</typeparam>
	public class AwaitableTaskSchedulerFactory<T>
		where T : AwaitableTaskScheduler, new()
	{
		/// <summary>
		/// Creates and starts a <see cref="T:System.Threading.Tasks.Task">Task</see> on a new <typeparamref name="T"/> instance.
		/// </summary>
		/// <param name="action">The action delegate to execute asynchronously.</param>
		/// <returns>An <typeparamref name="T"/> instance.</returns>
		public T StartNew(Action action)
		{
			var taskScheduler = new T();

			Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, taskScheduler);

			return taskScheduler;
		}

		/// <summary>
		/// Creates and starts a <see cref="T:System.Threading.Tasks.Task">Task</see> on a new <typeparamref name="T"/> instance.
		/// </summary>
		/// <param name="action">The action delegate to execute asynchronously.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new task.</param>
		/// <returns>An <typeparamref name="T"/> instance.</returns>
		public T StartNew(Action action, CancellationToken cancellationToken)
		{
			var taskScheduler = new T();

			Task.Factory.StartNew(action, cancellationToken, TaskCreationOptions.None, taskScheduler);

			return taskScheduler;
		}

		/// <summary>
		/// Creates and starts a <see cref="T:System.Threading.Tasks.Task">Task</see> on a new <typeparamref name="T"/> instance.
		/// </summary>
		/// <param name="action">The action delegate to execute asynchronously.</param>
		/// <param name="creationOptions">A TaskCreationOptions value that controls the behavior of the created <see cref="T:System.Threading.Tasks.Task">Task.</see></param>
		/// <returns>An instance of <typeparamref name="T"/>.</returns>
		public T StartNew(Action action, TaskCreationOptions creationOptions)
		{
			var taskScheduler = new T();

			Task.Factory.StartNew(action, CancellationToken.None, creationOptions, taskScheduler);

			return taskScheduler;
		}

		/// <summary>
		/// Creates and starts a <see cref="T:System.Threading.Tasks.Task">Task</see> on a new <typeparamref name="T"/> instance.
		/// </summary>
		/// <param name="action">The action delegate to execute asynchronously.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new task.</param>
		/// <param name="creationOptions">A TaskCreationOptions value that controls the behavior of the created <see cref="T:System.Threading.Tasks.Task">Task.</see></param>
		/// <returns>An instance of <typeparamref name="T"/>.</returns>
		public T StartNew(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
		{
			var taskScheduler = new T();

			Task.Factory.StartNew(action, cancellationToken, creationOptions, taskScheduler);

			return taskScheduler;
		}

		/// <summary>
		/// Creates and starts a <see cref="T:System.Threading.Tasks.Task">Task</see> on a new <typeparamref name="T"/> instance.
		/// </summary>
		/// <param name="action">The action delegate to execute asynchronously.</param>
		/// <param name="state">An object containing data to be used by the <paramref name="action"/> delegate.</param>
		/// <returns>An instance of <typeparamref name="T"/>.</returns>
		public T StartNew(Action<object> action, object state)
		{
			var taskScheduler = new T();

			Task.Factory.StartNew(action, state, CancellationToken.None, TaskCreationOptions.None, taskScheduler);

			return taskScheduler;
		}

		/// <summary>
		/// Creates and starts a <see cref="T:System.Threading.Tasks.Task">Task</see> on a new <typeparamref name="T"/> instance.
		/// </summary>
		/// <param name="action">The action delegate to execute asynchronously.</param>
		/// <param name="state">An object containing data to be used by the <paramref name="action"/> delegate.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new task.</param>
		/// <returns>An instance of <typeparamref name="T"/>.</returns>
		public T StartNew(Action<object> action, object state, CancellationToken cancellationToken)
		{
			var taskScheduler = new T();

			Task.Factory.StartNew(action, state, cancellationToken, TaskCreationOptions.None, taskScheduler);

			return taskScheduler;
		}

		/// <summary>
		/// Creates and starts a <see cref="T:System.Threading.Tasks.Task">Task</see> on a new <typeparamref name="T"/> instance.
		/// </summary>
		/// <param name="action">The action delegate to execute asynchronously.</param>
		/// <param name="state">An object containing data to be used by the <paramref name="action"/> delegate.</param>
		/// <param name="creationOptions">A TaskCreationOptions value that controls the behavior of the created <see cref="T:System.Threading.Tasks.Task">Task.</see></param>
		/// <returns>An instance of <typeparamref name="T"/>.</returns>
		public T StartNew(Action<object> action, object state, TaskCreationOptions creationOptions)
		{
			var taskScheduler = new T();

			Task.Factory.StartNew(action, state, CancellationToken.None, creationOptions, taskScheduler);

			return taskScheduler;
		}

		/// <summary>
		/// Creates and starts a <see cref="T:System.Threading.Tasks.Task">Task</see> on a new <typeparamref name="T"/> instance.
		/// </summary>
		/// <param name="action">The action delegate to execute asynchronously.</param>
		/// <param name="state">An object containing data to be used by the <paramref name="action"/> delegate.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> that will be assigned to the new task.</param>
		/// <param name="creationOptions">A TaskCreationOptions value that controls the behavior of the created <see cref="T:System.Threading.Tasks.Task">Task.</see></param>
		/// <returns>An instance of <typeparamref name="T"/>.</returns>
		public T StartNew(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
		{
			var taskScheduler = new T();

			Task.Factory.StartNew(action, state, cancellationToken, creationOptions, taskScheduler);

			return taskScheduler;
		}
	}
}