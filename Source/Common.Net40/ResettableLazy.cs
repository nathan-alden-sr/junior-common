using System;
using System.Threading;

namespace Junior.Common
{
	/// <summary>
	/// Encapsulates <see cref="Lazy{T}"/>, allowing it to be reset.
	/// </summary>
	/// <typeparam name="TLazy">A <see cref="Lazy{T}"/> or derived type.</typeparam>
	/// <typeparam name="TValue">The type of the value to be lazy-initialized.</typeparam>
	public class ResettableLazy<TLazy, TValue>
		where TLazy : Lazy<TValue>
	{
		private readonly Func<TLazy> _lazyFactory;
		private TLazy _lazy;

		/// <summary>
		/// Initializes a new instance of the <see cref="ResettableLazy{TLazy,TValue}"/> class.
		/// </summary>
		/// <param name="lazyFactory">A delegate used to initialize and reset the internal <typeparamref name="TLazy"/> instance</param>.
		public ResettableLazy(Func<TLazy> lazyFactory)
		{
			lazyFactory.ThrowIfNull("lazyFactory");

			_lazyFactory = lazyFactory;
			Reset();
		}

		/// <summary>
		/// Gets a value that indicates whether a value has been created for the internal <typeparamref name="TLazy"/> instance.
		/// </summary>
		public bool IsValueCreated
		{
			get
			{
				return _lazy.IsValueCreated;
			}
		}

		/// <summary>
		/// Gets the lazily initialized value of the internal <typeparamref name="TLazy"/> instance.
		/// </summary>
		public TValue Value
		{
			get
			{
				return _lazy.Value;
			}
		}

		/// <summary>
		/// Resets the internal <typeparamref name="TLazy"/> instance.
		/// </summary>
		public void Reset()
		{
			_lazy = _lazyFactory();
		}

		/// <summary>
		/// Casts the current <see cref="ResettableLazy{TLazy,TValue}"/> instance to <typeparamref name="TLazy"/>.
		/// </summary>
		/// <param name="resettableLazy">A <see cref="ResettableLazy{TLazy,TValue}"/> instance.</param>
		/// <returns>A <see cref="ResettableLazy{TLazy,TValue}"/> instance.</returns>
		public static implicit operator TLazy(ResettableLazy<TLazy, TValue> resettableLazy)
		{
			return resettableLazy._lazy;
		}
	}

	/// <summary>
	/// A factory that creates instances of <see cref="ResettableLazy{TLazy,TValue}"/> using specific <see cref="Lazy{T}"/> implementations.
	/// </summary>
	public static class ResettableLazy
	{
		/// <summary>
		/// Creates a <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.
		/// </summary>
		/// <typeparam name="T">The type of the value to be lazy-initialized.</typeparam>
		/// <returns>A <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.</returns>
		public static ResettableLazy<Lazy<T>, T> CreateUsingLazy<T>()
			where T : new()
		{
			return new ResettableLazy<Lazy<T>, T>(() => new Lazy<T>(() => new T()));
		}

		/// <summary>
		/// Creates a <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.
		/// </summary>
		/// <typeparam name="T">The type of the value to be lazy-initialized.</typeparam>
		/// <param name="isThreadSafe">true to make this instance usable concurrently by multiple threads; false to make the instance usable by only one thread at a time.</param>
		/// <returns>A <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.</returns>
		public static ResettableLazy<Lazy<T>, T> CreateUsingLazy<T>(bool isThreadSafe)
			where T : new()
		{
			return new ResettableLazy<Lazy<T>, T>(() => new Lazy<T>(isThreadSafe));
		}

		/// <summary>
		/// Creates a <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.
		/// </summary>
		/// <typeparam name="T">The type of the value to be lazy-initialized.</typeparam>
		/// <param name="valueFactory">The delegate that is invoked to produce the lazily initialized value when it is needed.</param>
		/// <returns>A <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.</returns>
		public static ResettableLazy<Lazy<T>, T> CreateUsingLazy<T>(Func<T> valueFactory)
			where T : new()
		{
			return new ResettableLazy<Lazy<T>, T>(() => new Lazy<T>(valueFactory));
		}

		/// <summary>
		/// Creates a <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.
		/// </summary>
		/// <typeparam name="T">The type of the value to be lazy-initialized.</typeparam>
		/// <param name="mode">One of the enumeration values that specifies the thread safety mode.</param>
		/// <returns>A <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.</returns>
		public static ResettableLazy<Lazy<T>, T> CreateUsingLazy<T>(LazyThreadSafetyMode mode)
			where T : new()
		{
			return new ResettableLazy<Lazy<T>, T>(() => new Lazy<T>(mode));
		}

		/// <summary>
		/// Creates a <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.
		/// </summary>
		/// <typeparam name="T">The type of the value to be lazy-initialized.</typeparam>
		/// <param name="valueFactory">The delegate that is invoked to produce the lazily initialized value when it is needed.</param>
		/// <param name="isThreadSafe">true to make this instance usable concurrently by multiple threads; false to make the instance usable by only one thread at a time.</param>
		/// <returns>A <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.</returns>
		public static ResettableLazy<Lazy<T>, T> CreateUsingLazy<T>(Func<T> valueFactory, bool isThreadSafe)
			where T : new()
		{
			return new ResettableLazy<Lazy<T>, T>(() => new Lazy<T>(valueFactory, isThreadSafe));
		}

		/// <summary>
		/// Creates a <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.
		/// </summary>
		/// <typeparam name="T">The type of the value to be lazy-initialized.</typeparam>
		/// <param name="valueFactory">The delegate that is invoked to produce the lazily initialized value when it is needed.</param>
		/// <param name="mode">One of the enumeration values that specifies the thread safety mode.</param>
		/// <returns>A <see cref="ResettableLazy{TLazy,TValue}"/> instance that uses <see cref="Lazy{T}"/> internally.</returns>
		public static ResettableLazy<Lazy<T>, T> CreateUsingLazy<T>(Func<T> valueFactory, LazyThreadSafetyMode mode)
			where T : new()
		{
			return new ResettableLazy<Lazy<T>, T>(() => new Lazy<T>(valueFactory, mode));
		}
	}
}