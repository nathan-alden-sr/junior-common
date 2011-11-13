using System;
using System.Collections.Generic;

namespace JuniorCommon.Common
{
	/// <summary>
	/// Extensions for the <see cref="Dictionary{TKey,TValue}"/> type.
	/// </summary>
	public static class DictionaryExtensions
	{
		/// <summary>
		/// Adds an enumerable of entries to the specified dictionary.
		/// </summary>
		/// <param name="dictionary">A <see cref="Dictionary{TKey,TValue}"/>.</param>
		/// <param name="pairs">An enumerable of <see cref="KeyValuePair{TKey,TValue}"/> to add.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="dictionary"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="pairs"/> is null.</exception>
		public static void AddMany<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		{
			dictionary.ThrowIfNull("dictionary");
			pairs.ThrowIfNull("pairs");

			foreach (var pair in pairs)
			{
				dictionary.Add(pair.Key, pair.Value);
			}
		}

		/// <summary>
		/// Adds or replaces an enumerable of entries in the specified dictionary.
		/// </summary>
		/// <param name="dictionary">A <see cref="Dictionary{TKey,TValue}"/>.</param>
		/// <param name="pairs">An enumerable of <see cref="KeyValuePair{TKey,TValue}"/> to add or replace.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="dictionary"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="pairs"/> is null.</exception>
		public static void ReplaceMany<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		{
			dictionary.ThrowIfNull("dictionary");
			pairs.ThrowIfNull("pairs");

			foreach (var pair in pairs)
			{
				dictionary[pair.Key] = pair.Value;
			}
		}

		/// <summary>
		/// Removes entries with the specified keys from the specified dictionary.
		/// </summary>
		/// <param name="dictionary">A <see cref="Dictionary{TKey,TValue}"/>.</param>
		/// <param name="keys">An enumerable of keys to remove.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="dictionary"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="keys"/> is null.</exception>
		public static void RemoveMany<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys)
		{
			dictionary.ThrowIfNull("dictionary");
			keys.ThrowIfNull("keys");

			foreach (TKey key in keys)
			{
				dictionary.Remove(key);
			}
		}
	}
}