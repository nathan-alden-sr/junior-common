using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Junior.Common
{
	/// <summary>
	/// An email address. <see cref="EmailAddress"/> allows email addresses of any length.
	/// </summary>
	[DebuggerDisplay("{_emailAddress}")]
	[DebuggerStepThrough]
	public class EmailAddress : IEquatable<EmailAddress>, IComparable<EmailAddress>
	{
		/// <summary>
		/// The regular expression pattern used by <see cref="EmailAddress"/>.
		/// </summary>
		public const string RegexPattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";

		private readonly string _emailAddress;

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailAddress"/> class.
		/// </summary>
		/// <param name="emailAddress">An email address.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="emailAddress"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="emailAddress"/> is not a valid email address.</exception>
		public EmailAddress(string emailAddress)
		{
			emailAddress.ThrowIfNull("emailAddress");
			if (!IsEmailAddress(emailAddress))
			{
				throw new ArgumentException("Value must be an email address.", "emailAddress");
			}

			_emailAddress = emailAddress;
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(EmailAddress other)
		{
			return other == null ? -1 : String.CompareOrdinal(_emailAddress, other._emailAddress);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(EmailAddress other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			return Equals(other._emailAddress, _emailAddress);
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
		/// </returns>
		/// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
		/// <filterpriority>2</filterpriority>
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
			if (obj.GetType() != typeof(EmailAddress))
			{
				return false;
			}
			return Equals((EmailAddress)obj);
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
			return (_emailAddress != null ? _emailAddress.GetHashCode() : 0);
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
			return _emailAddress;
		}

		/// <summary>
		/// Parses <paramref name="value"/> to an <see cref="EmailAddress"/>.
		/// </summary>
		/// <param name="value">An email address.</param>
		/// <returns>An <see cref="EmailAddress"/> representing the specified email address.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		public static EmailAddress Parse(string value)
		{
			value.ThrowIfNull("value");

			return new EmailAddress(value);
		}

		/// <summary>
		/// Attempts to parse <paramref name="value"/> to an <see cref="EmailAddress"/>.
		/// </summary>
		/// <param name="value">An email address.</param>
		/// <param name="result">An <see cref="EmailAddress"/> representing the specified email address if <paramref name="value"/> is valid; otherwise, null.</param>
		/// <returns>true if <paramref name="value"/> is a valid email address; otherwise, false.</returns>
		public static bool TryParse(string value, out EmailAddress result)
		{
			try
			{
				result = new EmailAddress(value);
				return true;
			}
			catch (Exception)
			{
				result = null;
				return false;
			}
		}

		/// <summary>
		/// Determines if two <see cref="EmailAddress"/> instances represent the same email address.
		/// </summary>
		/// <param name="left">An <see cref="EmailAddress"/>.</param>
		/// <param name="right">An <see cref="EmailAddress"/>.</param>
		/// <returns>true if the two <see cref="EmailAddress"/> instances are equal; otherwise, false.</returns>
		public static bool operator ==(EmailAddress left, EmailAddress right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// Determines if an <see cref="EmailAddress"/> instance and a <see cref="string"/> represent the same email address.
		/// </summary>
		/// <param name="left">An <see cref="EmailAddress"/>.</param>
		/// <param name="right">An email address.</param>
		/// <returns>true if the <see cref="EmailAddress"/> instance and the <see cref="string"/> are equal; otherwise, false.</returns>
		public static bool operator ==(EmailAddress left, string right)
		{
			return Equals(left.ToString(), right);
		}

		/// <summary>
		/// Determines if a <see cref="string"/> and an <see cref="EmailAddress"/> instance represent the same email address.
		/// </summary>
		/// <param name="left">An email address.</param>
		/// <param name="right">An <see cref="EmailAddress"/>.</param>
		/// <returns>true if the <see cref="string"/> and the <see cref="EmailAddress"/> instance are equal; otherwise, false.</returns>
		public static bool operator ==(string left, EmailAddress right)
		{
			return Equals(left, right.ToString());
		}

		/// <summary>
		/// Determines if two <see cref="EmailAddress"/> instances do not represent the same email address.
		/// </summary>
		/// <param name="left">An <see cref="EmailAddress"/>.</param>
		/// <param name="right">An <see cref="EmailAddress"/>.</param>
		/// <returns>true if the two <see cref="EmailAddress"/> instances are not equal; otherwise, false.</returns>
		public static bool operator !=(EmailAddress left, EmailAddress right)
		{
			return !Equals(left, right);
		}

		/// <summary>
		/// Determines if an <see cref="EmailAddress"/> instance and a <see cref="string"/> do not represent the same email address.
		/// </summary>
		/// <param name="left">An <see cref="EmailAddress"/>.</param>
		/// <param name="right">An email address.</param>
		/// <returns>true if the <see cref="EmailAddress"/> instance and the <see cref="string"/> are not equal; otherwise, false.</returns>
		public static bool operator !=(EmailAddress left, string right)
		{
			return !Equals(left.ToString(), right);
		}

		/// <summary>
		/// Determines if a <see cref="string"/> and an <see cref="EmailAddress"/> instance do not represent the same email address.
		/// </summary>
		/// <param name="left">An email address.</param>
		/// <param name="right">An <see cref="EmailAddress"/>.</param>
		/// <returns>true if the <see cref="string"/> and the <see cref="EmailAddress"/> instance are not equal; otherwise, false.</returns>
		public static bool operator !=(string left, EmailAddress right)
		{
			return !Equals(left, right.ToString());
		}

		/// <summary>
		/// Implicitly converts <paramref name="value"/> to a <see cref="string"/>.
		/// </summary>
		/// <param name="value">An <see cref="EmailAddress"/>.</param>
		/// <returns>An email address as a <see cref="string"/>.</returns>
		public static implicit operator string(EmailAddress value)
		{
			return value._emailAddress;
		}

		private static bool IsEmailAddress(string value)
		{
			return Regex.IsMatch(value, RegexPattern);
		}
	}
}