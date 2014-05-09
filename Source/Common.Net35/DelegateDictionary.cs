using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Junior.Common
{
	/// <summary>
	/// A caching dictionary of <see cref="Func{T,TResult}"/> tracked by <typeparamref name="TKey"/>.
	/// Delegate return values are cached when a delegate is invoked.
	/// </summary>
	[DebuggerStepThrough]
	public class DelegateDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
	{
		private readonly Dictionary<TKey, TValue> _cachedValueDictionary = new Dictionary<TKey, TValue>();
		private readonly Dictionary<TKey, Func<TKey, TValue>> _delegateDictionary = new Dictionary<TKey, Func<TKey, TValue>>();

		/// <summary>
		/// Gets the number of delegates in the dictionary.
		/// </summary>
		public int DelegateCount
		{
			get
			{
				return _delegateDictionary.Count;
			}
		}

		/// <summary>
		/// Gets the number of cached values in the dictionary.
		/// </summary>
		public int CachedValueCount
		{
			get
			{
				return _cachedValueDictionary.Count;
			}
		}

		/// <summary>
		/// Gets the return value of the delegate with the specified key.
		/// </summary>
		/// <param name="key">A key.</param>
		/// <returns>The return value of the delegate with key <paramref name="key"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
		public TValue this[TKey key]
		{
			get
			{
				key.ThrowIfNull("key");

				return GetValue(key);
			}
		}

		/// <summary>
		/// Adds a delegate to the dictionary if it is not already in the dictionary, then returns the value of the delegate.
		/// </summary>
		/// <param name="key">A key.</param>
		/// <param name="delegate">A <see cref="Func{TKey,TValue}"/>.</param>
		/// <returns>The return value of the delegate.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
		public TValue this[TKey key, Func<TKey, TValue> @delegate]
		{
			get
			{
				key.ThrowIfNull("key");

				if (!_delegateDictionary.ContainsKey(key))
				{
					Add(key, @delegate);
				}

				return GetValue(key);
			}
		}

		/// <summary>
		/// Gets all keys in the dictionary.
		/// </summary>
		public IEnumerable<TKey> Keys
		{
			get
			{
				return _delegateDictionary.Keys;
			}
		}

		/// <summary>
		/// Gets all cached values in the dictionary.
		/// </summary>
		public IEnumerable<TValue> CachedValues
		{
			get
			{
				return _cachedValueDictionary.Values;
			}
		}

		/// <summary>
		/// Gets all values for all delegates in the dictionary. Uninvoked delegates will be invoked.
		/// </summary>
		public IEnumerable<TValue> AllValues
		{
			get
			{
				return Keys.Select(GetValue);
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return Keys.Select(arg => new KeyValuePair<TKey, TValue>(arg, GetValue(arg))).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// Clears all delegates and cached values.
		/// </summary>
		public void ClearAll()
		{
			_delegateDictionary.Clear();
			_cachedValueDictionary.Clear();
		}

		/// <summary>
		/// Clears all cached values. Retrieving values will re-invoke the delegates.
		/// </summary>
		public void ClearCachedValues()
		{
			_cachedValueDictionary.Clear();
		}

		/// <summary>
		/// Determines if the dictionary contains the specified key.
		/// </summary>
		/// <param name="key">A key.</param>
		/// <returns>true if the dictionary contains <paramref name="key"/>; otherwise, false.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
		public bool ContainsKey(TKey key)
		{
			key.ThrowIfNull("key");

			return _delegateDictionary.ContainsKey(key);
		}

		/// <summary>
		/// Adds an entry with the specified key and delegate to the dictionary. The delegate is not invoked.
		/// </summary>
		/// <param name="key">A key.</param>
		/// <param name="delegate">A <see cref="Func{TKey,TValue}"/>.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="delegate"/> is null.</exception>
		public void Add(TKey key, Func<TKey, TValue> @delegate)
		{
			key.ThrowIfNull("key");
			@delegate.ThrowIfNull("value");

			_delegateDictionary.Add(key, @delegate);
		}

		/// <summary>
		/// Removes the entry with the specified key from the dictionary.
		/// </summary>
		/// <param name="key">A key.</param>
		/// <returns>true if the dictionary contains an entry with the specified key; otherwise, false.</returns>
		public bool Remove(TKey key)
		{
			bool result = _delegateDictionary.Remove(key);

			_cachedValueDictionary.Remove(key);

			return result;
		}

		private TValue GetValue(TKey key)
		{
			TValue value;

			if (!_cachedValueDictionary.TryGetValue(key, out value))
			{
				value = _delegateDictionary[key](key);
				_cachedValueDictionary.Add(key, value);
			}

			return value;
		}
	}
}