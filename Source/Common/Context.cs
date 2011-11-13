using System;

// ReSharper disable StaticFieldInGenericType

namespace JuniorCommon.Common
{
	/// <summary>
	/// A nestable per-process context. Contexts must always be disposed when they are exited to ensure proper behavior.
	/// </summary>
	public abstract class Context<T> : IDisposable
		where T : Context<T>
	{
		[ThreadStatic]
		private static T _currentContext;
		private readonly T _outerContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="Context{T}"/> class. The new instance becomes the current context.
		/// </summary>
		protected Context()
		{
			_outerContext = _currentContext;
			_currentContext = (T)this;
		}

		/// <summary>
		/// Gets the current context value.
		/// </summary>
		public static T Current
		{
			get
			{
				return _currentContext;
			}
		}

		/// <summary>
		/// Gets a value indicating if the context is disposed.
		/// </summary>
		protected bool Disposed
		{
			get;
			private set;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			this.ThrowIfDisposed(Disposed);

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// The next outer scope in the process becomes the current context.
		/// </summary>
		/// <param name="disposing">When true, the next outer scope in the process becomes the current context; otherwise, a null operation.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (Disposed || !disposing)
			{
				return;
			}

			_currentContext = _outerContext;
			Disposed = true;
		}
	}
}