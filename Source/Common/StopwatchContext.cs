using System;
using System.Diagnostics;

namespace Junior.Common
{
	/// <summary>
	/// Times how long it takes for a delegate to finish executing by using the <see cref="Stopwatch"/> class.
	/// </summary>
	public static class StopwatchContext
	{
		/// <summary>
		/// Times how long it takes for the specified delegate to finish executing.
		/// </summary>
		/// <param name="action">An <see cref="Action"/>.</param>
		/// <returns>The amount of time it took to execute <paramref name="action"/>.</returns>
		public static TimeSpan Timed(Action action)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			action();

			stopwatch.Stop();

			return stopwatch.Elapsed;
		}
	}
}