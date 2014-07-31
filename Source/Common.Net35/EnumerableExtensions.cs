using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Junior.Common.Net35
{
	/// <summary>
	/// Extensions for the <see cref="IEnumerable{T}"/> type.
	/// </summary>
	[DebuggerStepThrough]
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Retrieves the element in the specified enumerable with the minimum value as determined by the specified delegate.
		/// The default comparer for <typeparamref name="TKey"/> is used.
		/// </summary>
		/// <param name="value">An enumerable of <typeparamref name="TItem"/>.</param>
		/// <param name="selector">A <see cref="Func{TItem,TKey}"/> used to retrieve the comparison value.</param>
		/// <returns>The element in the specified enumerable with the minimum value as determined by the specified delegate.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		public static TItem MinBy<TItem, TKey>(this IEnumerable<TItem> value, Func<TItem, TKey> selector)
		{
			value.ThrowIfNull("value");

			return value.MinBy(selector, Comparer<TKey>.Default);
		}

		/// <summary>
		/// Retrieves the element in the specified enumerable with the minimum value as determined by the specified delegate.
		/// </summary>
		/// <param name="value">An enumerable of <typeparamref name="TItem"/>.</param>
		/// <param name="selector">A <see cref="Func{TItem,TKey}"/> used to retrieve the comparison value.</param>
		/// <param name="comparer">An <see cref="IComparer{TKey}"/>.</param>
		/// <returns>The element in the specified enumerable with the minimum value as determined by the specified delegate.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="selector"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="comparer"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
		public static TItem MinBy<TItem, TKey>(this IEnumerable<TItem> value, Func<TItem, TKey> selector, IComparer<TKey> comparer)
		{
			value.ThrowIfNull("value");
			selector.ThrowIfNull("selector");
			comparer.ThrowIfNull("comparer");

			using (IEnumerator<TItem> valueEnumerator = value.GetEnumerator())
			{
				if (!valueEnumerator.MoveNext())
				{
					throw new ArgumentException("Value must contain at least one element.", "value");
				}

				TItem min = valueEnumerator.Current;
				TKey minKey = selector(min);

				while (valueEnumerator.MoveNext())
				{
					TItem candidate = valueEnumerator.Current;
					TKey candidateProjected = selector(candidate);

					if (comparer.Compare(candidateProjected, minKey) >= 0)
					{
						continue;
					}

					min = candidate;
					minKey = candidateProjected;
				}

				return min;
			}
		}

		/// <summary>
		/// Retrieves the element in the specified enumerable with the maximum value as determined by the specified delegate.
		/// The default comparer for <typeparamref name="TKey"/> is used.
		/// </summary>
		/// <param name="value">An enumerable of <typeparamref name="TItem"/>.</param>
		/// <param name="selector">A <see cref="Func{TItem,TKey}"/> used to retrieve the comparison value.</param>
		/// <returns>The element in the specified enumerable with the maximum value as determined by the specified delegate.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		public static TItem MaxBy<TItem, TKey>(this IEnumerable<TItem> value, Func<TItem, TKey> selector)
		{
			value.ThrowIfNull("value");

			return value.MaxBy(selector, Comparer<TKey>.Default);
		}

		/// <summary>
		/// Retrieves the element in the specified enumerable with the maximum value as determined by the specified delegate.
		/// </summary>
		/// <param name="value">An enumerable of <typeparamref name="TItem"/>.</param>
		/// <param name="selector">A <see cref="Func{TItem,TKey}"/> used to retrieve the comparison value.</param>
		/// <param name="comparer">An <see cref="IComparer{TKey}"/>.</param>
		/// <returns>The element in the specified enumerable with the maximum value as determined by the specified delegate.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="selector"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="comparer"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
		public static TItem MaxBy<TItem, TKey>(this IEnumerable<TItem> value, Func<TItem, TKey> selector, IComparer<TKey> comparer)
		{
			value.ThrowIfNull("value");
			selector.ThrowIfNull("selector");
			comparer.ThrowIfNull("comparer");

			using (IEnumerator<TItem> valueEnumerator = value.GetEnumerator())
			{
				if (!valueEnumerator.MoveNext())
				{
					throw new ArgumentException("Value must contain at least one element.", "value");
				}

				TItem max = valueEnumerator.Current;
				TKey maxKey = selector(max);

				while (valueEnumerator.MoveNext())
				{
					TItem candidate = valueEnumerator.Current;
					TKey candidateProjected = selector(candidate);

					if (comparer.Compare(candidateProjected, maxKey) <= 0)
					{
						continue;
					}

					max = candidate;
					maxKey = candidateProjected;
				}

				return max;
			}
		}

		/// <summary>
		/// Determines if the number of elements in the specified enumerable is less than the specified count.
		/// <see cref="CountLessThan{T}"/> uses an enumerator to only retrieve as many values as necessary to make the determination.
		/// </summary>
		/// <param name="value">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="value"/> is less than <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountLessThan<T>(this IEnumerable<T> value, int elementCount)
		{
			IEnumerator enumerator = value.GetEnumerator();

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
		/// <param name="value">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="value"/> is less than or equal to <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountLessThanOrEqual<T>(this IEnumerable<T> value, int elementCount)
		{
			IEnumerator enumerator = value.GetEnumerator();

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
		/// <param name="value">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="value"/> is equal to <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountEqual<T>(this IEnumerable<T> value, int elementCount)
		{
			IEnumerator enumerator = value.GetEnumerator();

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
		/// <param name="value">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="value"/> is greater than <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountGreaterThan<T>(this IEnumerable<T> value, int elementCount)
		{
			value.ThrowIfNull("value");

			IEnumerator enumerator = value.GetEnumerator();

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
		/// <param name="value">An <see cref="IEnumerable{T}"/>.</param>
		/// <param name="elementCount">A count of elements.</param>
		/// <returns>true if the number of elements in <paramref name="value"/> is greater than or equal to <paramref name="elementCount"/>; otherwise, false.</returns>
		public static bool CountGreaterThanOrEqual<T>(this IEnumerable<T> value, int elementCount)
		{
			value.ThrowIfNull("value");

			IEnumerator enumerator = value.GetEnumerator();

			for (int i = 0; i < elementCount; i++)
			{
				if (!enumerator.MoveNext())
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Converts an empty enumerable to null.
		/// </summary>
		/// <param name="value">An enumerable.</param>
		/// <returns>null if <paramref name="value"/> is empty; otherwise, <paramref name="value"/>.</returns>
		public static IEnumerable<T> EmptyToNull<T>(this IEnumerable<T> value)
		{
			// ReSharper disable PossibleMultipleEnumeration
			return value != null ? ((!value.Any() ? null : value)) : null;
			// ReSharper restore PossibleMultipleEnumeration
		}

		/// <summary>
		/// Converts an null enumerable to an empty one.
		/// </summary>
		/// <param name="value">An enumerable.</param>
		/// <returns>An empty enumerable if <paramref name="value"/> is null; otherwise, <paramref name="value"/>.</returns>
		public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> value)
		{
			return value ?? Enumerable.Empty<T>();
		}

		/// <summary>
		/// Throws an <see cref="ArgumentNullException"/> if the specified value is null or throws an <see cref="ArgumentException"/> if the specified value is empty.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="paramName">The value's parameter name.</param>
		/// <param name="argumentNullExceptionMessage">The exception message to use when throwing an <see cref="ArgumentNullException"/>.</param>
		/// <param name="argumentExceptionMessage">The exception message to use when throwing an <see cref="ArgumentException"/>.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
		public static void ThrowIfNullOrEmpty<T>(this IEnumerable<T> value, string paramName, string argumentNullExceptionMessage = null, string argumentExceptionMessage = "Enumerable cannot be empty.")
		{
			value.ThrowIfNull(paramName, argumentNullExceptionMessage);
			value.ThrowIfEmpty(paramName, argumentExceptionMessage);
		}

		/// <summary>
		/// Throws an <see cref="ArgumentException"/> if the specified value is empty.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="paramName">The value's parameter name.</param>
		/// <param name="argumentExceptionMessage">The exception message to use when throwing an <see cref="ArgumentException"/>.</param>
		/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
		/// <returns>The specified value.</returns>
		public static void ThrowIfEmpty<T>(this IEnumerable<T> value, string paramName, string argumentExceptionMessage = "Enumerable cannot be empty.")
		{
			if (!value.Any())
			{
				throw new ArgumentException(argumentExceptionMessage, paramName);
			}
		}

		/// <summary>
		/// Throws an <see cref="ArgumentNullException"/> if the specified value is null or throws an <see cref="ArgumentException"/> if the specified value is empty; otherwise, returns the value.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="paramName">The value's parameter name.</param>
		/// <param name="argumentNullExceptionMessage">The exception message to use when throwing an <see cref="ArgumentNullException"/>.</param>
		/// <param name="argumentExceptionMessage">The exception message to use when throwing an <see cref="ArgumentException"/>.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
		public static IEnumerable<T> EnsureNotNullOrEmpty<T>(this IEnumerable<T> value, string paramName, string argumentNullExceptionMessage = null, string argumentExceptionMessage = "Enumerable cannot be empty.")
		{
			// ReSharper disable PossibleMultipleEnumeration
			value.ThrowIfNullOrEmpty(paramName, argumentNullExceptionMessage, argumentExceptionMessage);

			return value;
			// ReSharper restore PossibleMultipleEnumeration
		}

		/// <summary>
		/// Throws an <see cref="ArgumentException"/> if the specified value is empty; otherwise, returns the value.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="paramName">The value's parameter name.</param>
		/// <param name="argumentExceptionMessage">The exception message to use when throwing an <see cref="ArgumentException"/>.</param>
		/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is empty.</exception>
		/// <returns>The specified value.</returns>
		public static IEnumerable<T> EnsureNotEmpty<T>(this IEnumerable<T> value, string paramName, string argumentExceptionMessage = "Enumerable cannot be empty.")
		{
			// ReSharper disable PossibleMultipleEnumeration
			value.ThrowIfEmpty(paramName, argumentExceptionMessage);

			return value;
			// ReSharper restore PossibleMultipleEnumeration
		}
	}
}