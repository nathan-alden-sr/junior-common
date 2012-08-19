using System;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for the <see cref="DateTime"/> type.
	/// </summary>
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Converts the specified <see cref="DateTime"/> into a local time. The actual date and time will remain unchanged.
		/// </summary>
		/// <param name="dateTime">A <see cref="DateTime"/>.</param>
		/// <returns><paramref name="dateTime"/> as a local time.</returns>
		public static DateTime AsLocal(this DateTime dateTime)
		{
			return DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
		}

		/// <summary>
		/// Converts the specified <see cref="DateTime"/> into UTC time. The actual date and time will remain unchanged.
		/// </summary>
		/// <param name="dateTime">A <see cref="DateTime"/>.</param>
		/// <returns><paramref name="dateTime"/> as UTC time.</returns>
		public static DateTime AsUtc(this DateTime dateTime)
		{
			return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
		}

		/// <summary>
		/// Converts the specified <see cref="DateTime"/> into an unspecified kind of time. The actual date and time will remain unchanged.
		/// </summary>
		/// <param name="dateTime">A <see cref="DateTime"/>.</param>
		/// <returns><paramref name="dateTime"/> as an unspecified kind of time.</returns>
		public static DateTime AsUnspecified(this DateTime dateTime)
		{
			return DateTime.SpecifyKind(dateTime.ToUniversalTime(), DateTimeKind.Unspecified);
		}

		/// <summary>
		/// Converts the specified <see cref="DateTime"/> into a specific kind of time. The actual date and time will remain unchanged.
		/// </summary>
		/// <param name="dateTime">A <see cref="DateTime"/>.</param>
		/// <param name="kind">A <see cref="DateTimeKind"/>.</param>
		/// <returns><paramref name="dateTime"/> as a <paramref name="kind"/> of time.</returns>
		public static DateTime AsKind(this DateTime dateTime, DateTimeKind kind)
		{
			return DateTime.SpecifyKind(dateTime, kind);
		}
	}
}