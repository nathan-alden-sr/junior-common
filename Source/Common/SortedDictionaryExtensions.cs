using System;
using System.Collections.Generic;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for the <see cref="SortedDictionary{TKey,TValue}"/> type.
	/// </summary>
	public static class SortedDictionaryExtensions
	{
		/// <summary>
		/// Adds an enumerable of entries to the specified sorted dictionary.
		/// </summary>
		/// <param name="sortedDictionary">A <see cref="SortedDictionary{TKey,TValue}"/>.</param>
		/// <param name="pairs">An enumerable of <see cref="KeyValuePair{TKey,TValue}"/> to add.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="sortedDictionary"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="pairs"/> is null.</exception>
		public static void AddMany<TKey, TValue>(this SortedDictionary<TKey, TValue> sortedDictionary, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		{
			sortedDictionary.ThrowIfNull("sortedDictionary");
			pairs.ThrowIfNull("pairs");

			foreach (var pair in pairs)
			{
				sortedDictionary.Add(pair.Key, pair.Value);
			}
		}

		/// <summary>
		/// Adds or replaces an enumerable of entries in the specified sorted dictionary.
		/// </summary>
		/// <param name="sortedDictionary">A <see cref="SortedDictionary{TKey,TValue}"/>.</param>
		/// <param name="pairs">An enumerable of <see cref="KeyValuePair{TKey,TValue}"/> to add or replace.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="sortedDictionary"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="pairs"/> is null.</exception>
		public static void ReplaceMany<TKey, TValue>(this SortedDictionary<TKey, TValue> sortedDictionary, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		{
			sortedDictionary.ThrowIfNull("sortedDictionary");
			pairs.ThrowIfNull("pairs");

			foreach (var pair in pairs)
			{
				sortedDictionary[pair.Key] = pair.Value;
			}
		}

		/// <summary>
		/// Removes entries with the specified keys from the specified sorted dictionary.
		/// </summary>
		/// <param name="sortedDictionary">A <see cref="SortedDictionary{TKey,TValue}"/>.</param>
		/// <param name="keys">An enumerable of keys to remove.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="sortedDictionary"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="keys"/> is null.</exception>
		public static void RemoveMany<TKey, TValue>(this SortedDictionary<TKey, TValue> sortedDictionary, IEnumerable<TKey> keys)
		{
			sortedDictionary.ThrowIfNull("sortedDictionary");
			keys.ThrowIfNull("keys");

			foreach (TKey key in keys)
			{
				sortedDictionary.Remove(key);
			}
		}
	}
}