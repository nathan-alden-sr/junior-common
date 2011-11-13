using System;
using System.Diagnostics;

namespace JuniorCommon.Common
{
	/// <summary>
	/// Extensions for the <see cref="IDisposable"/> type.
	/// </summary>
	public static class DisposableExtensions
	{
		/// <summary>
		/// Throws an exception if <paramref name="disposed"/> is true.
		/// </summary>
		/// <param name="object">An object.</param>
		/// <param name="disposed">A value indicating if <paramref name="object"/> is disposed.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="object"/> is null.</exception>
		[DebuggerNonUserCode]
		public static void ThrowIfDisposed(this IDisposable @object, bool disposed)
		{
			@object.ThrowIfNull("object");

			if (disposed)
			{
				throw new ObjectDisposedException(@object.GetType().FullName);
			}
		}
	}
}