using System;

namespace Junior.Common.Net35
{
	/// <summary>
	/// Extension methods for the <see cref="Guid"/> type.
	/// </summary>
	public static class GuidExtensions
	{
		/// <summary>
		/// Throws an <see cref="ArgumentException"/> if the specified value is <see cref="Guid.Empty"/>; otherwise, returns the value.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="paramName">The value's parameter name.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
		/// <returns>the specified value</returns>
		[Obsolete("Use GuidExtensions.EnsureNotEmpty")]
		public static Guid EnsureNotNull(this Guid value, string paramName)
		{
			return EnsureNotEmpty(value, paramName);
		}

		/// <summary>
		/// Throws an <see cref="ArgumentException"/> if the specified value is <see cref="Guid.Empty"/>; otherwise, returns the value.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="paramName">The value's parameter name.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
		/// <returns>the specified value</returns>
		public static Guid EnsureNotEmpty(this Guid value, string paramName)
		{
			if (value == Guid.Empty)
			{
				throw new ArgumentException("Value cannot be empty.", paramName);
			}

			return value;
		}
	}
}