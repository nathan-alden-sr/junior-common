using System;
using System.Diagnostics;

namespace Junior.Common.Net35
{
	/// <summary>
	/// Provides the current system date and time in both local time and UTC time.
	/// </summary>
	[DebuggerStepThrough]
	public class SystemClock : ISystemClock
	{
		/// <summary>
		/// Gets the current local date.
		/// </summary>
		public DateTimeOffset LocalDate
		{
			get
			{
				return DateTimeOffset.Now.Date;
			}
		}

		/// <summary>
		/// Gets the current local date and time.
		/// </summary>
		public DateTimeOffset LocalDateTime
		{
			get
			{
				return DateTimeOffset.Now;
			}
		}

		/// <summary>
		/// Gets the current local time.
		/// </summary>
		public TimeSpan LocalTime
		{
			get
			{
				return DateTimeOffset.Now.TimeOfDay;
			}
		}

		/// <summary>
		/// Gets the current UTC date.
		/// </summary>
		public DateTimeOffset UtcDate
		{
			get
			{
				return DateTimeOffset.UtcNow.Date;
			}
		}

		/// <summary>
		/// Gets the current UTC date and time.
		/// </summary>
		public DateTimeOffset UtcDateTime
		{
			get
			{
				return DateTimeOffset.UtcNow;
			}
		}

		/// <summary>
		/// Gets the current UTC time.
		/// </summary>
		public TimeSpan UtcTime
		{
			get
			{
				return DateTimeOffset.UtcNow.TimeOfDay;
			}
		}
	}
}