using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Junior.Common.Net40
{
	/// <summary>
	/// Initializes a value lazily and asynchronously by using <see cref="Task{TResult}"/>.
	/// </summary>
	[DebuggerStepThrough]
	public class AsyncLazy<T> : Lazy<Task<T>>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AsyncLazy{T}"/> class.
		/// </summary>
		/// <param name="valueFactory">A delegate that returns the value.</param>
		public AsyncLazy(Func<T> valueFactory)
			: base(() => Task.Factory.StartNew(valueFactory))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AsyncLazy{T}"/> class.
		/// </summary>
		/// <param name="valueFactory">A delegate that returns a <see cref="Task{T}"/>.</param>
		public AsyncLazy(Func<Task<T>> valueFactory)
			: base(() => Task.Factory.StartNew(valueFactory).Unwrap())
		{
		}
	}
}