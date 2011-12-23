using System;
using System.Runtime.InteropServices;

namespace Junior.Common
{
	/// <summary>
	/// Safely converts a <see cref="double"/> to an <see cref="long"/> for floating-point comparisons.
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct DoubleToLong : IEquatable<DoubleToLong>, IEquatable<double>, IEquatable<long>, IComparable<DoubleToLong>, IComparable<double>, IComparable<long>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DoubleToLong"/> class.
		/// </summary>
		/// <param name="doubleValue">The <see cref="double"/> value to be converted to an <see cref="long"/>.</param>
		public DoubleToLong(double doubleValue)
			: this()
		{
			DoubleValue = doubleValue;
		}

		/// <summary>
		/// Gets the floating-point value as an integer.
		/// </summary>
		[FieldOffset(0)]
		public readonly long LongValue;

		/// <summary>
		/// Gets the floating-point value.
		/// </summary>
		[FieldOffset(0)]
		public readonly double DoubleValue;

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(DoubleToLong other)
		{
			return other.LongValue == LongValue;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(double other)
		{
			return LongValue == new DoubleToLong(other).LongValue;
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
			return LongValue == other;
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(DoubleToLong other)
		{
			return LongValue.CompareTo(other.LongValue);
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(double other)
		{
			return LongValue.CompareTo(new DoubleToLong(other).LongValue);
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
			return LongValue.CompareTo(other);
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
			if (obj.GetType() != typeof(DoubleToLong))
			{
				return false;
			}
			return Equals((DoubleToLong)obj);
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
			return LongValue.GetHashCode();
		}

		/// <summary>
		/// Implicitly converts from a <see cref="DoubleToLong"/> to an <see cref="long"/>.
		/// </summary>
		/// <param name="value">A <see cref="DoubleToLong"/>.</param>
		/// <returns>An integer representation of the floating-point value.</returns>
		public static implicit operator long(DoubleToLong value)
		{
			return value.LongValue;
		}

		/// <summary>
		/// Implicitly converts from a <see cref="DoubleToLong"/> to a <see cref="double"/>.
		/// </summary>
		/// <param name="value">A <see cref="DoubleToLong"/>.</param>
		/// <returns>The floating-point value.</returns>
		public static implicit operator double(DoubleToLong value)
		{
			return value.DoubleValue;
		}

		/// <summary>
		/// Determines if two <see cref="DoubleToLong"/> instances have the same integer representation.
		/// </summary>
		/// <param name="left">A <see cref="DoubleToLong"/>.</param>
		/// <param name="right">A <see cref="DoubleToLong"/>.</param>
		/// <returns>true if the two <see cref="DoubleToLong"/> have the same integer representation; otherwise, false.</returns>
		public static bool operator ==(DoubleToLong left, DoubleToLong right)
		{
			return left.LongValue == right.LongValue;
		}

		/// <summary>
		/// Determines if two <see cref="DoubleToLong"/> instances have different integer representations.
		/// </summary>
		/// <param name="left">A <see cref="DoubleToLong"/>.</param>
		/// <param name="right">A <see cref="DoubleToLong"/>.</param>
		/// <returns>true if the two <see cref="DoubleToLong"/> have different integer representations; otherwise, false.</returns>
		public static bool operator !=(DoubleToLong left, DoubleToLong right)
		{
			return !(left == right);
		}
	}
}