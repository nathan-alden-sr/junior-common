using System;
using System.Diagnostics;
using System.Globalization;

namespace Junior.Common
{
	/// <summary>
	/// Represents a <see cref="DateTime"/> as a <see cref="long"/>. <see cref="DateTime.ToFileTimeUtc"/> is used to represent the <see cref="DateTime"/>.
	/// </summary>
	[DebuggerDisplay("UTC file time = {_utcFileTime}")]
	public struct PreciseDateTime : IEquatable<PreciseDateTime>, IEquatable<DateTime>, IEquatable<long>, IComparable<PreciseDateTime>, IComparable<DateTime>, IComparable<long>
	{
		private readonly long _utcFileTime;

		/// <summary>
		/// Initializes a new instance of the <see cref="PreciseDateTime"/> class.
		/// </summary>
		/// <param name="dateTime">A <see cref="DateTime"/>.</param>
		public PreciseDateTime(DateTime dateTime)
		{
			_utcFileTime = dateTime.ToFileTimeUtc();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PreciseDateTime"/> class.
		/// </summary>
		/// <param name="utcFileTime">A UTC file time.</param>
		public PreciseDateTime(long utcFileTime)
		{
			_utcFileTime = utcFileTime;
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(DateTime other)
		{
			return _utcFileTime.CompareTo(other.ToFileTimeUtc());
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(long other)
		{
			return _utcFileTime.CompareTo(other);
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(PreciseDateTime other)
		{
			return _utcFileTime.CompareTo(other._utcFileTime);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(DateTime other)
		{
			return _utcFileTime == other.ToFileTimeUtc();
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(long other)
		{
			return _utcFileTime.Equals(other);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(PreciseDateTime other)
		{
			return true;
		}

		/// <summary>
		/// Implicitly converts from a <see cref="PreciseDateTime"/> to a <see cref="long"/>.
		/// </summary>
		/// <param name="value">A <see cref="PreciseDateTime"/>.</param>
		/// <returns>A <see cref="long"/> representing the specified <see cref="PreciseDateTime"/>.</returns>
		public static implicit operator long(PreciseDateTime value)
		{
			return value._utcFileTime;
		}

		/// <summary>
		/// Implicitly converts from a <see cref="PreciseDateTime"/> to a <see cref="DateTime"/>.
		/// </summary>
		/// <param name="value">A <see cref="PreciseDateTime"/>.</param>
		/// <returns>A <see cref="DateTime"/> representing the specified <see cref="PreciseDateTime"/>.</returns>
		public static implicit operator DateTime(PreciseDateTime value)
		{
			return DateTime.FromFileTimeUtc(value._utcFileTime);
		}

		/// <summary>
		/// Implicitly converts from a <see cref="DateTime"/> to a <see cref="PreciseDateTime"/>.
		/// </summary>
		/// <param name="value">A <see cref="DateTime"/>.</param>
		/// <returns>A <see cref="PreciseDateTime"/> representing the specified <see cref="DateTime"/>.</returns>
		public static implicit operator PreciseDateTime(DateTime value)
		{
			return new PreciseDateTime(value);
		}

		/// <summary>
		/// Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <returns>
		/// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
		/// </returns>
		/// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			if (obj.GetType() != typeof(PreciseDateTime))
			{
				return false;
			}
			return Equals((PreciseDateTime)obj);
		}

		/// <summary>
		/// Determines if two <see cref="PreciseDateTime"/> instances are equal.
		/// </summary>
		/// <param name="left">A <see cref="PreciseDateTime"/>.</param>
		/// <param name="right">A <see cref="PreciseDateTime"/>.</param>
		/// <returns>true if the two <see cref="PreciseDateTime"/> instances are equal; otherwise, false.</returns>
		public static bool operator ==(PreciseDateTime left, PreciseDateTime right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Determines if two <see cref="PreciseDateTime"/> instances are not equal.
		/// </summary>
		/// <param name="left">A <see cref="PreciseDateTime"/>.</param>
		/// <param name="right">A <see cref="PreciseDateTime"/>.</param>
		/// <returns>true if the two <see cref="PreciseDateTime"/> instances are not equal; otherwise, false.</returns>
		public static bool operator !=(PreciseDateTime left, PreciseDateTime right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			return _utcFileTime.GetHashCode();
		}

		/// <summary>
		/// Returns the fully qualified type name of this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> containing a fully qualified type name.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override string ToString()
		{
			return _utcFileTime.ToString(CultureInfo.InvariantCulture);
		}
	}
}