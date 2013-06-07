using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Junior.Common
{
	/// <summary>
	/// Reverses a comparison result.
	/// </summary>
	[DebuggerStepThrough]
	public class ComparerReverser<T> : IComparer<T>
	{
		private readonly IComparer<T> _comparer;

		/// <summary>
		/// Initializes a new instance of the <see cref="ComparerReverser{T}"/> class.
		/// </summary>
		/// <param name="comparer">An <see cref="IComparer{T}"/>.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="comparer"/> is null.</exception>
		public ComparerReverser(IComparer<T> comparer)
		{
			comparer.ThrowIfNull("comparer");

			_comparer = comparer;
		}

		/// <summary>
		/// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
		/// </summary>
		/// <returns>
		/// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.Value Meaning Less than zero<paramref name="x"/> is less than <paramref name="y"/>.Zero<paramref name="x"/> equals <paramref name="y"/>.Greater than zero<paramref name="x"/> is greater than <paramref name="y"/>.
		/// </returns>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		public int Compare(T x, T y)
		{
			return _comparer.Compare(y, x);
		}
	}
}