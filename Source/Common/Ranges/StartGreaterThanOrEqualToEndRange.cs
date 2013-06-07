using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Junior.Common.Ranges
{
	/// <summary>
	/// A range of <typeparamref name="T"/> where the start must be greater than or equal to the end.
	/// </summary>
	[DebuggerStepThrough]
	public class StartGreaterThanOrEqualToEndRange<T> : Range<T>
		where T : IComparable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StartGreaterThanOrEqualToEndRange{T}"/> class.
		/// </summary>
		/// <param name="start">The start of the range.</param>
		/// <param name="end">The end of the range.</param>
		/// <exception cref="ArgumentException">Thrown when <paramref name="start"/> is less than <paramref name="end"/>.</exception>
		public StartGreaterThanOrEqualToEndRange(T start, T end)
			: base(start, end)
		{
			if (Comparer<T>.Default.Compare(start, end) < 0)
			{
				throw new ArgumentException("Start value must be greater than or equal to end value.", "start");
			}
		}
	}
}