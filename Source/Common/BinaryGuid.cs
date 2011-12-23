using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Junior.Common
{
	/// <summary>
	/// Allows conversion to and from <see cref="Guid"/> and an <see cref="Array"/> of <see cref="Byte"/>.
	/// </summary>
	[DebuggerDisplay("{_guid}")]
	public struct BinaryGuid : IEquatable<BinaryGuid>, IEquatable<Guid>, IEquatable<byte[]>, IComparable<BinaryGuid>, IComparable<Guid>, IComparable<byte[]>
	{
		private readonly Guid _guid;

		/// <summary>
		/// Initializes a new instance of the <see cref="BinaryGuid"/> class.
		/// </summary>
		/// <param name="guid">A <see cref="Guid"/>.</param>
		public BinaryGuid(Guid guid)
		{
			_guid = guid;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BinaryGuid"/> class.
		/// </summary>
		/// <param name="guidBytes">An array of bytes representing a GUID.</param>
		public BinaryGuid(byte[] guidBytes)
		{
			ValidateGuidBytes(guidBytes);

			_guid = new Guid(guidBytes);
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(BinaryGuid other)
		{
			return _guid.CompareTo(other._guid);
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(byte[] other)
		{
			ValidateGuidBytes(other);

			return _guid.CompareTo(new Guid(other));
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(Guid other)
		{
			return _guid.CompareTo(other);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(BinaryGuid other)
		{
			return other._guid.Equals(_guid);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(byte[] other)
		{
			ValidateGuidBytes(other);

			return _guid.Equals(other);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(Guid other)
		{
			return _guid == other;
		}

		/// <summary>
		/// Implicitly converts from a <see cref="BinaryGuid"/> to a <see cref="Guid"/>.
		/// </summary>
		/// <param name="value">A <see cref="BinaryGuid"/>.</param>
		/// <returns>A <see cref="Guid"/> representing the specified <see cref="BinaryGuid"/>.</returns>
		public static implicit operator Guid(BinaryGuid value)
		{
			return value._guid;
		}

		/// <summary>
		/// Implicitly converts from a <see cref="BinaryGuid"/> to an <see cref="Array"/> of <see cref="Byte"/>.
		/// </summary>
		/// <param name="value">A <see cref="BinaryGuid"/>.</param>
		/// <returns>An <see cref="Array"/> of <see cref="Byte"/> representing the specified <see cref="BinaryGuid"/>.</returns>
		public static implicit operator byte[](BinaryGuid value)
		{
			return value._guid.ToByteArray();
		}

		/// <summary>
		/// Implicitly converts from a <see cref="Guid"/> to a <see cref="BinaryGuid"/>.
		/// </summary>
		/// <param name="value">A <see cref="Guid"/>.</param>
		/// <returns>A <see cref="BinaryGuid"/> representing the specified <see cref="Guid"/>.</returns>
		public static implicit operator BinaryGuid(Guid value)
		{
			return new BinaryGuid(value);
		}

		/// <summary>
		/// Implicitly converts from an <see cref="Array"/> of <see cref="Byte"/> to a <see cref="BinaryGuid"/>.
		/// </summary>
		/// <param name="value">An <see cref="Array"/> of <see cref="Byte"/>.</param>
		/// <returns>A <see cref="BinaryGuid"/> representing the specified <see cref="Array"/> of <see cref="Byte"/>.</returns>
		public static implicit operator BinaryGuid(byte[] value)
		{
			return new BinaryGuid(value);
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
			if (obj is BinaryGuid)
			{
				return Equals((BinaryGuid)obj);
			}
			if (obj is Guid)
			{
				return Equals((BinaryGuid)(Guid)obj);
			}
			if (obj.GetType() == typeof(byte[]))
			{
				return Equals((BinaryGuid)(byte[])obj);
			}
			return false;
		}

		/// <summary>
		/// Determines if two <see cref="BinaryGuid"/> instances represent the same GUID.
		/// </summary>
		/// <param name="left">A <see cref="BinaryGuid"/>.</param>
		/// <param name="right">A <see cref="BinaryGuid"/>.</param>
		/// <returns>true if the two <see cref="BinaryGuid"/> instances are equal; otherwise, false.</returns>
		public static bool operator ==(BinaryGuid left, BinaryGuid right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Determines if two <see cref="BinaryGuid"/> instances do not represent the same GUID.
		/// </summary>
		/// <param name="left">A <see cref="BinaryGuid"/>.</param>
		/// <param name="right">A <see cref="BinaryGuid"/>.</param>
		/// <returns>true if the two <see cref="BinaryGuid"/> instances are not equal; otherwise, false.</returns>
		public static bool operator !=(BinaryGuid left, BinaryGuid right)
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
			return _guid.GetHashCode();
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
			return _guid.ToString();
		}

		private static void ValidateGuidBytes(ICollection<byte> other)
		{
			other.ThrowIfNull("other");

			if (other.Count != 16)
			{
				throw new ArgumentException("value must be exactly 16 bytes.", "other");
			}
		}
	}
}