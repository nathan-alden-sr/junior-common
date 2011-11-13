using System;
using System.Diagnostics;

namespace Junior.Common
{
	/// <summary>
	/// A pair of values.
	/// </summary>
	[DebuggerDisplay("First = {_first}, Second = {_second}")]
	public class Pair<TFirst, TSecond> : IEquatable<Pair<TFirst, TSecond>>
	{
		private readonly TFirst _first;
		private readonly TSecond _second;

		/// <summary>
		/// Initializes a new instance of the <see cref="Pair{TFirst,TSecond}"/> class.
		/// </summary>
		/// <param name="first">The first value of the pair,</param>
		/// <param name="second">The second value of the pair.</param>
		public Pair(TFirst first, TSecond second)
		{
			_first = first;
			_second = second;
		}

		/// <summary>
		/// Gets the first value of the pair.
		/// </summary>
		public TFirst First
		{
			get
			{
				return _first;
			}
		}

		/// <summary>
		/// Gets the second value of the pair.
		/// </summary>
		public TSecond Second
		{
			get
			{
				return _second;
			}
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(Pair<TFirst, TSecond> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			return Equals(other._first, _first) && Equals(other._second, _second);
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
			if (obj.GetType() != typeof(Pair<TFirst, TSecond>))
			{
				return false;
			}
			return Equals((Pair<TFirst, TSecond>)obj);
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
			unchecked
			{
				return (_first.GetHashCode() * 397) ^ _second.GetHashCode();
			}
		}
	}
}