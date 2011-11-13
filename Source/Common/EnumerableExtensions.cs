using System;
using System.Collections;
using System.Collections.Generic;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for the <see cref="IEnumerable{T}"/> type.
	/// </summary>
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Retrieves the element in the specified enumerable with the minimum value as determined by the specified delegate.
		/// The default comparer for <typeparamref name="TKey"/> is used.
		/// </summary>
		/// <param name="source">An enumerable of <typeparamref name="TSource"/>.</param>
		/// <param name="selector">A <see cref="Func{TSource,TKey}"/> used to retrieve the comparison value.</param>
		/// <returns>The element in the specified enumerable with the minimum value as determined by the specified delegate.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
		public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			source.ThrowIfNull("source");

			return source.MinBy(selector, Comparer<TKey>.Default);
		}

		/// <summary>
		/// Retrieves the element in the specified enumerable with the minimum value as determined by the specified delegate.
		/// </summary>
		/// <param name="source">An enumerable of <typeparamref name="TSource"/>.</param>
		/// <param name="selector">A <see cref="Func{TSource,TKey}"/> used to retrieve the comparison value.</param>
		/// <param name="comparer">An <see cref="IComparer{TKey}"/>.</param>
		/// <returns>The element in the specified enumerable with the minimum value as determined by the specified delegate.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="selector"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="comparer"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is empty.</exception>
		public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			source.ThrowIfNull("source");
			selector.ThrowIfNull("selector");
			comparer.ThrowIfNull("comparer");

			using (IEnumerator<TSource> sourceEnumerator = source.GetEnumerator())
			{
				if (!sourceEnumerator.MoveNext())
				{
					throw new ArgumentException("Source must contain at least one element.", "source");
				}

				TSource min = sourceEnumerator.Current;
				TKey minKey = selector(min);

				while (sourceEnumerator.MoveNext())
				{
					TSource candidate = sourceEnumerator.Current;
					TKey candidateProjected = selector(candidate);
					if (comparer.Compare(candidateProjected, minKey) < 0)
					{
						min = candidate;
						minKey = candidateProjected;
					}
				}

				return min;
			}
		}

		/// <summary>
		/// Retrieves the element in the specified enumerable with the maximum value as determined by the specified delegate.
		/// The default comparer for <typeparamref name="TKey"/> is used.
		/// </summary>
		/// <param name="source">An enumerable of <typeparamref name="TSource"/>.</param>
		/// <param name="selector">A <see cref="Func{TSource,TKey}"/> used to retrieve the comparison value.</param>
		/// <returns>The element in the specified enumerable with the maximum value as determined by the specified delegate.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			source.ThrowIfNull("source");

			return source.MaxBy(selector, Comparer<TKey>.Default);
		}

		/// <summary>
		/// Retrieves the element in the specified enumerable with the maximum value as determined by the specified delegate.
		/// </summary>
		/// <param name="source">An enumerable of <typeparamref name="TSource"/>.</param>
		/// <param name="selector">A <see cref="Func{TSource,TKey}"/> used to retrieve the comparison value.</param>
		/// <param name="comparer">An <see cref="IComparer{TKey}"/>.</param>
		/// <returns>The element in the specified enumerable with the maximum value as determined by the specified delegate.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="selector"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="comparer"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is empty.</exception>
		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			source.ThrowIfNull("source");
			selector.ThrowIfNull("selector");
			comparer.ThrowIfNull("comparer");

			using (IEnumerator<TSource> sourceEnumerator = source.GetEnumerator())
			{
				if (!sourceEnumerator.MoveNext())
				{
					throw new ArgumentException("Source must contain at least one element.", "source");
				}

				TSource max = sourceEnumerator.Current;
				TKey maxKey = selector(max);

				while (sourceEnumerator.MoveNext())
				{
					TSource candidate = sourceEnumerator.Current;
					TKey candidateProjected = selector(candidate);
					if (comparer.Compare(candidateProjected, maxKey) > 0)
					{
						max = candidate;
						maxKey = candidateProjected;
					}
				}

				return max;
			}
		}

		/// <summary>
		/// Determines if the number of elements in the specified enumerable is less than the specified count.
		/// <see cref="CountLessThan{T}"/> uses an enumerator to only retrieve as many values as necessary to make the determination.
		/// </summary>
		/// <param name="source">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="source"/> is less than <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountLessThan<T>(this IEnumerable<T> source, int elementCount)
		{
			IEnumerator enumerator = source.GetEnumerator();

			for (int i = 0; i < elementCount - 1; i++)
			{
				if (!enumerator.MoveNext())
				{
					return true;
				}
			}

			return !enumerator.MoveNext();
		}

		/// <summary>
		/// Determines if the number of elements in the specified enumerable is less than or equal to the specified count.
		/// <see cref="CountLessThanOrEqual{T}"/> uses an enumerator to only retrieve as many values as necessary to make the determination.
		/// </summary>
		/// <param name="source">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="source"/> is less than or equal to <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountLessThanOrEqual<T>(this IEnumerable<T> source, int elementCount)
		{
			IEnumerator enumerator = source.GetEnumerator();

			for (int i = 0; i < elementCount; i++)
			{
				if (!enumerator.MoveNext())
				{
					return true;
				}
			}

			return !enumerator.MoveNext();
		}

		/// <summary>
		/// Determines if the number of elements in the specified enumerable is equal to the specified count.
		/// <see cref="CountEqual{T}"/> uses an enumerator to only retrieve as many values as necessary to make the determination.
		/// </summary>
		/// <param name="source">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="source"/> is equal to <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountEqual<T>(this IEnumerable<T> source, int elementCount)
		{
			IEnumerator enumerator = source.GetEnumerator();

			for (int i = 1; i <= elementCount; i++)
			{
				if (!enumerator.MoveNext())
				{
					return false;
				}
			}

			return !enumerator.MoveNext();
		}

		/// <summary>
		/// Determines if the number of elements in the specified enumerable is greater than the specified count.
		/// <see cref="CountGreaterThan{T}"/> uses an enumerator to only retrieve as many values as necessary to make the determination.
		/// </summary>
		/// <param name="source">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="source"/> is greater than <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountGreaterThan<T>(this IEnumerable<T> source, int elementCount)
		{
			source.ThrowIfNull("source");

			IEnumerator enumerator = source.GetEnumerator();

			for (int i = 0; i < elementCount + 1; i++)
			{
				if (!enumerator.MoveNext())
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Determines if the number of elements in the specified enumerable is greater than or equal to the specified count.
		/// <see cref="CountGreaterThanOrEqual{T}"/> uses an enumerator to only retrieve as many values as necessary to make the determination.
		/// </summary>
		/// <param name="source">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="source"/> is greater than or equal to <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountGreaterThanOrEqual<T>(this IEnumerable<T> source, int elementCount)
		{
			source.ThrowIfNull("source");

			IEnumerator enumerator = source.GetEnumerator();

			for (int i = 0; i < elementCount; i++)
			{
				if (!enumerator.MoveNext())
				{
					return false;
				}
			}

			return true;
		}
	}
}