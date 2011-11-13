using System;
using System.Collections.Generic;

namespace Junior.Common.Ranges
{
	/// <summary>
	/// A range of nullable <typeparamref name="T"/> where the start must be greater than or equal to the end.
	/// </summary>
	public class NullableStartGreaterThanOrEqualToEndRange<T> : Range<T?>
		where T : struct, IComparable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NullableStartGreaterThanOrEqualToEndRange{T}"/> class.
		/// </summary>
		/// <param name="start">The start of the range.</param>
		/// <param name="end">The end of the range.</param>
		/// <exception cref="ArgumentException">Thrown when <paramref name="start"/> is less than <paramref name="end"/>.</exception>
		public NullableStartGreaterThanOrEqualToEndRange(T? start, T? end)
			: base(start, end)
		{
			if (Comparer<T?>.Default.Compare(start, end) < 0)
			{
				throw new ArgumentException("Start value must be greater than or equal to end value.", "start");
			}
		}
	}
}