using System.Threading;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common
{
	public static class AwaitableTaskSchedulerTester
	{
		[TestFixture]
		public class When_awaiting_completion_task_with_no_queued_tasks
		{
			[Test]
			public async void Must_complete()
			{
				var systemUnderTest = new AwaitableTaskScheduler();

				await systemUnderTest.CompletionTask;
			}
		}

		[TestFixture]
		public class When_awaiting_completion_task_with_queued_tasks
		{
			[Test]
			public async void Must_complete_after_queued_tasks_complete()
			{
				var systemUnderTest = new AwaitableTaskScheduler();
				var manualResetEvent = new ManualResetEvent(false);

				Task task = Task.Factory.StartNew(() => manualResetEvent.WaitOne(), CancellationToken.None, TaskCreationOptions.None, systemUnderTest);
				Task completionTask = systemUnderTest.CompletionTask;

				Assert.That(completionTask.IsCompleted, Is.False);

				manualResetEvent.Set();

				await task;

				Assert.That(completionTask.IsCompleted, Is.True);
			}
		}
	}
}