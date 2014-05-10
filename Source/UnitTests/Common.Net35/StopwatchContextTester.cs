using System;
using System.Threading;

using Junior.Common.Net35;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Net35
{
	public static class StopwatchContextTester
	{
		[TestFixture]
		public class When_executing_timed_delegate
		{
			[Test]
			public void Must_return_elapsed_time()
			{
				Assert.That(StopwatchContext.Timed(() => Thread.Sleep(TimeSpan.FromMilliseconds(250))), Is.GreaterThanOrEqualTo(TimeSpan.Zero));
			}
		}
	}
}