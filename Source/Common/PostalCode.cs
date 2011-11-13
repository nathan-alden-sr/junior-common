using System;
using System.Text.RegularExpressions;

namespace JuniorCommon.Common
{
	/// <summary>
	/// A base class for all postal code implementations.
	/// </summary>
	public abstract class PostalCode<T> : IEquatable<PostalCode<T>>, IComparable<PostalCode<T>>
		where T : PostalCode<T>
	{
		private readonly string _postalCode;

		/// <summary>
		/// Initializes a new instance of the <see cref="PostalCode{T}"/> class.
		/// </summary>
		/// <param name="postalCode">A postal code represented as a string.</param>
		/// <param name="regexPattern">A regular expression pattern for validating <paramref name="postalCode"/>.</param>
		/// <param name="argumentExceptionMessage">An exception message used if the <paramref name="postalCode"/> is invalid.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="postalCode"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="postalCode"/> does not match <paramref name="regexPattern"/>.</exception>
		protected PostalCode(string postalCode, string regexPattern, string argumentExceptionMessage)
		{
			postalCode.ThrowIfNull("postalCode");
			if (!Regex.IsMatch(postalCode, regexPattern))
			{
				throw new ArgumentException(argumentExceptionMessage, "postalCode");
			}

			_postalCode = postalCode;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PostalCode{T}"/> class.
		/// </summary>
		/// <param name="postalCode">A postal code represented as an <see cref="int"/>.</param>
		/// <param name="regexPattern">A regular expression pattern for validating <paramref name="postalCode"/>.</param>
		/// <param name="argumentExceptionMessage">An exception message used if the <paramref name="postalCode"/> is invalid.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="postalCode"/> is null.</exception>
		/// <exception cref="ArgumentException">Thrown when <paramref name="postalCode"/> does not match <paramref name="regexPattern"/>.</exception>
		protected PostalCode(int postalCode, string regexPattern, string argumentExceptionMessage)
			: this(postalCode.ToString(), regexPattern, argumentExceptionMessage)
		{
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(PostalCode<T> other)
		{
			return other == null ? -1 : _postalCode.CompareTo(other._postalCode);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(PostalCode<T> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			return Equals(other._postalCode, _postalCode);
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
			if (obj.GetType() != typeof(PostalCode<T>))
			{
				return false;
			}
			return Equals((PostalCode<T>)obj);
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
			return (_postalCode != null ? _postalCode.GetHashCode() : 0);
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
			return _postalCode;
		}

		/// <summary>
		/// Determines if two <see cref="PostalCode{T}"/> instances represent the same postal code.
		/// </summary>
		/// <param name="left">A <see cref="PostalCode{T}"/>.</param>
		/// <param name="right">A <see cref="PostalCode{T}"/>.</param>
		/// <returns>true if the two <see cref="PostalCode{T}"/> instances are equal; otherwise, false.</returns>
		public static bool operator ==(PostalCode<T> left, PostalCode<T> right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// Determines if a <see cref="PostalCode{T}"/> instance and a <see cref="string"/> represent the same postal code.
		/// </summary>
		/// <param name="left">A <see cref="PostalCode{T}"/>.</param>
		/// <param name="right">A <see cref="string"/>.</param>
		/// <returns>true if the <see cref="PostalCode{T}"/> instance and the <see cref="string"/> are equal; otherwise, false.</returns>
		public static bool operator ==(PostalCode<T> left, string right)
		{
			return Equals(left.ToString(), right);
		}

		/// <summary>
		/// Determines if a <see cref="string"/> and a <see cref="PostalCode{T}"/> instance represent the same postal code.
		/// </summary>
		/// <param name="left">A <see cref="string"/>.</param>
		/// <param name="right">A <see cref="PostalCode{T}"/>.</param>
		/// <returns>true if the <see cref="string"/> and the <see cref="PostalCode{T}"/> instance are equal; otherwise, false.</returns>
		public static bool operator ==(string left, PostalCode<T> right)
		{
			return Equals(left, right.ToString());
		}

		/// <summary>
		/// Determines if a <see cref="PostalCode{T}"/> instance and an <see cref="int"/> represent the same postal code.
		/// </summary>
		/// <param name="left">A <see cref="PostalCode{T}"/>.</param>
		/// <param name="right">A number.</param>
		/// <returns>true if the <see cref="PostalCode{T}"/> instance and the number are equal; otherwise, false.</returns>
		public static bool operator ==(PostalCode<T> left, int right)
		{
			return Equals(Int32.Parse(left.ToString()), right);
		}

		/// <summary>
		/// Determines if an <see cref="int"/> and a <see cref="PostalCode{T}"/> instance represent the same postal code.
		/// </summary>
		/// <param name="left">A number.</param>
		/// <param name="right">A <see cref="PostalCode{T}"/>.</param>
		/// <returns>true if the number and the <see cref="PostalCode{T}"/> instance are equal; otherwise, false.</returns>
		public static bool operator ==(int left, PostalCode<T> right)
		{
			return Equals(left, Int32.Parse(right.ToString()));
		}

		/// <summary>
		/// Determines if two <see cref="PostalCode{T}"/> instances do not represent the same postal code.
		/// </summary>
		/// <param name="left">A <see cref="PostalCode{T}"/>.</param>
		/// <param name="right">A <see cref="PostalCode{T}"/>.</param>
		/// <returns>true if the two <see cref="PostalCode{T}"/> instances are not equal; otherwise, false.</returns>
		public static bool operator !=(PostalCode<T> left, PostalCode<T> right)
		{
			return !Equals(left, right);
		}

		/// <summary>
		/// Determines if a <see cref="PostalCode{T}"/> instance and a <see cref="string"/> do not represent the same postal code.
		/// </summary>
		/// <param name="left">A <see cref="PostalCode{T}"/>.</param>
		/// <param name="right">A <see cref="string"/>.</param>
		/// <returns>true if the <see cref="PostalCode{T}"/> instance and the <see cref="string"/> are not equal; otherwise, false.</returns>
		public static bool operator !=(PostalCode<T> left, string right)
		{
			return !Equals(left.ToString(), right);
		}

		/// <summary>
		/// Determines if a <see cref="string"/> and a <see cref="PostalCode{T}"/> instance do not represent the same postal code.
		/// </summary>
		/// <param name="left">A <see cref="string"/>.</param>
		/// <param name="right">A <see cref="PostalCode{T}"/>.</param>
		/// <returns>true if the <see cref="string"/> and the <see cref="PostalCode{T}"/> instance are not equal; otherwise, false.</returns>
		public static bool operator !=(string left, PostalCode<T> right)
		{
			return !Equals(left, right.ToString());
		}

		/// <summary>
		/// Determines if a <see cref="PostalCode{T}"/> instance and an <see cref="int"/> do not represent the same postal code.
		/// </summary>
		/// <param name="left">A <see cref="PostalCode{T}"/>.</param>
		/// <param name="right">A number.</param>
		/// <returns>true if the <see cref="PostalCode{T}"/> instance and the number are not equal; otherwise, false.</returns>
		public static bool operator !=(PostalCode<T> left, int right)
		{
			return !Equals(Int32.Parse(left), right);
		}

		/// <summary>
		/// Determines if an <see cref="int"/> and a <see cref="PostalCode{T}"/> instance do not represent the same postal code.
		/// </summary>
		/// <param name="left">A number.</param>
		/// <param name="right">A <see cref="PostalCode{T}"/>.</param>
		/// <returns>true if the number and the <see cref="PostalCode{T}"/> instance are not equal; otherwise, false.</returns>
		public static bool operator !=(int left, PostalCode<T> right)
		{
			return !Equals(left, Int32.Parse(right));
		}

		/// <summary>
		/// Implicitly converts from an <see cref="PostalCode{T}"/> to a <see cref="string"/>.
		/// </summary>
		/// <param name="value">A <see cref="PostalCode{T}"/>.</param>
		/// <returns>A <see cref="string"/> representing the specified <see cref="PostalCode{T}"/>.</returns>
		public static implicit operator string(PostalCode<T> value)
		{
			return value._postalCode;
		}

		/// <summary>
		/// Implicitly converts from an <see cref="PostalCode{T}"/> to an <see cref="int"/>.
		/// </summary>
		/// <param name="value">A <see cref="PostalCode{T}"/>.</param>
		/// <returns>A number representing the specified <see cref="PostalCode{T}"/>.</returns>
		public static implicit operator int(PostalCode<T> value)
		{
			return Int32.Parse(value._postalCode);
		}
	}
}