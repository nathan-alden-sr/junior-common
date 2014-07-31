using System;

namespace Junior.Common.Net35
{
	/// <summary>
	/// Extension methods for the <see cref="Guid"/> type.
	/// </summary>
	public static class GuidExtensions
	{
		/// <summary>
		/// Throws an <see cref="ArgumentException"/> if the specified value is <see cref="Guid.Empty"/>.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="paramName">The value's parameter name.</param>
		/// <param name="argumentExceptionMessage">The exception message to use when throwing an <see cref="ArgumentException"/>.</param>
		/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
		/// <returns>The specified value.</returns>
		public static void ThrowIfEmpty(this Guid value, string paramName, string argumentExceptionMessage = "GUID cannot be empty.")
		{
			if (value == Guid.Empty)
			{
				throw new ArgumentException(argumentExceptionMessage, paramName);
			}
		}

		/// <summary>
		/// Throws an <see cref="ArgumentException"/> if the specified value is <see cref="Guid.Empty"/>; otherwise, returns the value.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="paramName">The value's parameter name.</param>
		/// <param name="argumentExceptionMessage">The exception message to use when throwing an <see cref="ArgumentException"/>.</param>
		/// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
		/// <returns>The specified value.</returns>
		public static Guid EnsureNotEmpty(this Guid value, string paramName, string argumentExceptionMessage = "GUID cannot be empty.")
		{
			value.ThrowIfEmpty(paramName, argumentExceptionMessage);

			return value;
		}
	}
}