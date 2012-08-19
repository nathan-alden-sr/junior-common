using System;
using System.Collections.Generic;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for the <see cref="IComparer{T}"/> type.
	/// </summary>
	public static class ComparerExtensions
	{
		/// <summary>
		/// Reverses a comparison result.
		/// </summary>
		/// <param name="comparer">An <see cref="IComparer{T}"/>.</param>
		/// <returns>The negative of the comparison result.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="comparer"/> is null.</exception>
		public static IComparer<T> Reverse<T>(this IComparer<T> comparer)
		{
			comparer.ThrowIfNull("comparer");

			return new ComparerReverser<T>(comparer);
		}
	}
}