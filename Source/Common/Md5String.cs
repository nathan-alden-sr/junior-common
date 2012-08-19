using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Junior.Common
{
	/// <summary>
	/// Compares and converts MD5 strings.
	/// </summary>
	[DebuggerDisplay("{_md5}")]
	public class Md5String : IEquatable<Md5String>, IComparable<Md5String>
	{
		/// <summary>
		/// The regular expression pattern used by <see cref="EmailAddress"/> to validate hyphenated MD5 strings.
		/// </summary>
		public const string HyphenatedRegexPattern = "^([0-9A-Fa-f]{2}-){15}([0-9A-Fa-f]{2})$";
		/// <summary>
		/// The regular expression pattern used by <see cref="EmailAddress"/> to validate non-hyphenated MD5 strings.
		/// </summary>
		public const string NonHyphenatedRegexPattern = "^[0-9A-Fa-f]{32}$";
		/// <summary>
		/// The regular expression pattern used by <see cref="EmailAddress"/> to validate hyphenated and non-hyphenated MD5 strings.
		/// </summary>
		public const string OptionallyHyphenatedRegexPattern = "^([0-9A-Fa-f]{2}-?){15}([0-9A-Fa-f]{2})$";

		private readonly string _md5;

		private Md5String(string md5)
		{
			_md5 = md5;
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(Md5String other)
		{
			return other != null ? String.CompareOrdinal(_md5, other._md5) : -1;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(Md5String other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			return Equals(other._md5, _md5);
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
		/// </returns>
		/// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != typeof(Md5String))
			{
				return false;
			}
			return Equals((Md5String)obj);
		}

		/// <summary>
		/// Hashes the specified value and returns an <see cref="Md5String"/>.
		/// </summary>
		/// <param name="value">A value to hash.</param>
		/// <returns>an <see cref="Md5String"/> containing the hashed value.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		public static Md5String FromNonHashed(string value)
		{
			value.ThrowIfNull("value");

			return new Md5String(value.ToMd5HexString());
		}

		/// <summary>
		/// Validates the specified MD5 string and returns an <see cref="Md5String"/>.
		/// </summary>
		/// <param name="value">An MD5 string.</param>
		/// <param name="format">The allowed formats for <paramref name="value"/>.</param>
		/// <returns>an <see cref="Md5String"/> containing <paramref name="value"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown if <paramref name="value"/> does not validate against <paramref name="format"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="format"/> has an unexpected value.</exception>
		public static Md5String FromMd5(string value, Md5StringFormat format)
		{
			value.ThrowIfNull("value");

			value = value.ToLowerInvariant();

			switch (format)
			{
				case Md5StringFormat.HyphenatedHexCharacters:
					if (!IsHyphenatedMd5String(value))
					{
						throw new ArgumentException("Value must be a string of hyphenated hexadecimal characters.", "value");
					}
					return new Md5String(value.Replace("-", ""));
				case Md5StringFormat.NonHyphenatedHexCharacters:
					if (!IsNonHyphenatedMd5String(value))
					{
						throw new ArgumentException("Value must be a string of non-hyphenated hexadecimal characters.", "value");
					}
					return new Md5String(value);
				case Md5StringFormat.OptionallyHyphenatedHexCharacters:
					if (!IsOptionallyHyphenatedMd5String(value))
					{
						throw new ArgumentException("Value must be a string of hyphenated or non-hyphenated hexadecimal characters.", "value");
					}
					return new Md5String(value.Replace("-", ""));
				default:
					throw new ArgumentOutOfRangeException("format", format, "Unexpected format.");
			}
		}

		/// <summary>
		/// Serves as a hash function for a particular type. 
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			return (_md5 != null ? _md5.GetHashCode() : 0);
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override string ToString()
		{
			return _md5;
		}

		/// <summary>
		/// Determines if the specified string is a valid MD5 string.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <returns>true if <paramref name="value"/> is an MD5 string; otherwise, false.</returns>
		public static bool IsMd5String(string value)
		{
			return value != null && IsOptionallyHyphenatedMd5String(value);
		}

		/// <summary>
		/// Determines if two <see cref="Md5String"/> instances represent the same MD5 string.
		/// </summary>
		/// <param name="left">A <see cref="Md5String"/>.</param>
		/// <param name="right">A <see cref="Md5String"/>.</param>
		/// <returns>true if the two <see cref="Md5String"/> instances are equal; otherwise, false.</returns>
		public static bool operator ==(Md5String left, Md5String right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// Determines if two <see cref="Md5String"/> instances do not represent the same MD5 string.
		/// </summary>
		/// <param name="left">A <see cref="Md5String"/>.</param>
		/// <param name="right">A <see cref="Md5String"/>.</param>
		/// <returns>true if the two <see cref="Md5String"/> instances are not equal; otherwise, false.</returns>
		public static bool operator !=(Md5String left, Md5String right)
		{
			return !Equals(left, right);
		}

		/// <summary>
		/// Implicitly converts from an <see cref="Md5String"/> to a <see cref="string"/>.
		/// </summary>
		/// <param name="value">An <see cref="Md5String"/>.</param>
		/// <returns>A <see cref="string"/> representing the specified <see cref="Md5String"/>.</returns>
		public static implicit operator string(Md5String value)
		{
			return value._md5;
		}

		private static bool IsHyphenatedMd5String(string value)
		{
			return Regex.IsMatch(value, HyphenatedRegexPattern);
		}

		private static bool IsNonHyphenatedMd5String(string value)
		{
			return Regex.IsMatch(value, NonHyphenatedRegexPattern);
		}

		private static bool IsOptionallyHyphenatedMd5String(string value)
		{
			return Regex.IsMatch(value, OptionallyHyphenatedRegexPattern);
		}
	}
}