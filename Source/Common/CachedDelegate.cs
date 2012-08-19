using System;

namespace Junior.Common
{
	/// <summary>
	/// Invokes a delegate only if a provided key is different than the last execution.
	/// </summary>
	public class CachedDelegate<TKey, TResult>
		where TKey : class
	{
		private TKey _lastKey;
		private TResult _lastResult;

		/// <summary>
		/// Invokes <paramref name="delegate"/> only if <paramref name="key"/> is different than the last time <see cref="Invoke"/> was called.
		/// If <see cref="Invoke"/> has never been called, the delegate will be invoked.
		/// </summary>
		/// <param name="key">A key.</param>
		/// <param name="delegate">A <see cref="Func{TResult}"/>.</param>
		/// <returns>The result returneds by <paramref name="delegate"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
		public TResult Invoke(TKey key, Func<TResult> @delegate)
		{
			key.ThrowIfNull("_key");

			if (key == _lastKey)
			{
				return _lastResult;
			}

			_lastKey = key;
			_lastResult = @delegate();

			return _lastResult;
		}
	}
}