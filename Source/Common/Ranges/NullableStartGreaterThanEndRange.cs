using System;
using System.Collections.Generic;

namespace JuniorCommon.Common.Ranges
{
	/// <summary>
	/// A range of nullable <typeparamref name="T"/> where the start must be greater than the end.
	/// </summary>
	public class NullableStartGreaterThanEndRange<T> : Range<T?>
		where T : struct, IComparable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NullableStartGreaterThanEndRange{T}"/> class.
		/// </summary>
		/// <param name="start">The start of the range.</param>
		/// <param name="end">The end of the range.</param>
		/// <exception cref="ArgumentException">Thrown when <paramref name="start"/> is less than or equal to <paramref name="end"/>.</exception>
		public NullableStartGreaterThanEndRange(T? start, T? end)
			: base(start, end)
		{
			if (Comparer<T?>.Default.Compare(start, end) <= 0)
			{
				throw new ArgumentException("Start value must be greater than end value.", "start");
			}
		}
	}
}