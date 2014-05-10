using System;

namespace Junior.Common.Net35
{
	/// <summary>
	/// Represents the current system date and time in both local time and UTC time.
	/// </summary>
	public interface ISystemClock
	{
		/// <summary>
		/// Gets the current local date.
		/// </summary>
		DateTimeOffset LocalDate
		{
			get;
		}

		/// <summary>
		/// Gets the current local date and time.
		/// </summary>
		DateTimeOffset LocalDateTime
		{
			get;
		}

		/// <summary>
		/// Gets the current local time.
		/// </summary>
		TimeSpan LocalTime
		{
			get;
		}

		/// <summary>
		/// Gets the current UTC date.
		/// </summary>
		DateTimeOffset UtcDate
		{
			get;
		}

		/// <summary>
		/// Gets the current UTC date and time.
		/// </summary>
		DateTimeOffset UtcDateTime
		{
			get;
		}

		/// <summary>
		/// Gets the current UTC time.
		/// </summary>
		TimeSpan UtcTime
		{
			get;
		}
	}
}