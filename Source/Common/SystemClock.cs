using System;

namespace Junior.Common
{
	/// <summary>
	/// Provides the current system date and time in both local time and UTC time.
	/// </summary>
	public class SystemClock : ISystemClock
	{
		/// <summary>
		/// Gets the current local date.
		/// </summary>
		public DateTime LocalDate
		{
			get
			{
				return DateTime.Today.AsLocal();
			}
		}

		/// <summary>
		/// Gets the current local date and time.
		/// </summary>
		public DateTime LocalDateTime
		{
			get
			{
				return DateTime.Now.AsLocal();
			}
		}

		/// <summary>
		/// Gets the current local time.
		/// </summary>
		public TimeSpan LocalTime
		{
			get
			{
				return DateTime.Now.TimeOfDay;
			}
		}

		/// <summary>
		/// Gets the current UTC date.
		/// </summary>
		public DateTime UtcDate
		{
			get
			{
				return DateTime.UtcNow.Date.AsUtc();
			}
		}

		/// <summary>
		/// Gets the current UTC date and time.
		/// </summary>
		public DateTime UtcDateTime
		{
			get
			{
				return DateTime.UtcNow.AsUtc();
			}
		}

		/// <summary>
		/// Gets the current UTC time.
		/// </summary>
		public TimeSpan UtcTime
		{
			get
			{
				return DateTime.UtcNow.TimeOfDay;
			}
		}
	}
}