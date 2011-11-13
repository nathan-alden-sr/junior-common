using System;

namespace Junior.Common
{
	/// <summary>
	/// Represents the current system date and time in both local time and UTC time.
	/// </summary>
	public interface ISystemClock
	{
		/// <summary>
		/// Gets the current local date.
		/// </summary>
		DateTime LocalDate
		{
			get;
		}
		/// <summary>
		/// Gets the current local date and time.
		/// </summary>
		DateTime LocalDateTime
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
		DateTime UtcDate
		{
			get;
		}
		/// <summary>
		/// Gets the current UTC date and time.
		/// </summary>
		DateTime UtcDateTime
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