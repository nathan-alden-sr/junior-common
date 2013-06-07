using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Junior.Common
{
	/// <summary>
	/// Maps between two values.
	/// </summary>
	[DebuggerStepThrough]
	public class PairMapper<TFirst, TSecond> : IPairMapper<TFirst, TSecond>
	{
		private readonly List<Tuple<TFirst, TSecond>> _mapper = new List<Tuple<TFirst, TSecond>>();

		/// <summary>
		/// Initializes a new instance of the <see cref="PairMapper{TFirst,TSecond}"/> class. The instance initially contains no pairs.
		/// </summary>
		public PairMapper()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PairMapper{TFirst,TSecond}"/> class.
		/// </summary>
		/// <param name="pairs">An array of <see cref="Tuple{TFirst,TSecond}"/> instances with which to populate the pair mapper.</param>
		public PairMapper(params Tuple<TFirst, TSecond>[] pairs)
		{
			pairs.ThrowIfNull("pairs");

			_mapper.AddRange(pairs);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PairMapper{TFirst,TSecond}"/> class.
		/// </summary>
		/// <param name="pairs">An enumerable of <see cref="Tuple{TFirst,TSecond}"/> instances with which to populate the pair mapper.</param>
		public PairMapper(IEnumerable<Tuple<TFirst, TSecond>> pairs)
		{
			pairs.ThrowIfNull("pairs");

			_mapper.AddRange(pairs);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public IEnumerator<Tuple<TFirst, TSecond>> GetEnumerator()
		{
			return _mapper.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// Maps the specified first value to its matching second value.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <returns>The matching second value.</returns>
		public TSecond Map(TFirst first)
		{
			return MapFirst(first);
		}

		/// <summary>
		/// Maps the specified first value to its matching second value, or <paramref name="defaultValue"/> if no matching <paramref name="first"/> was found.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <param name="defaultValue">The value to return if <paramref name="first"/> is not found.</param>
		/// <returns>The matching second value.</returns>
		public TSecond Map(TFirst first, TSecond defaultValue)
		{
			return MapFirst(first, defaultValue);
		}

		/// <summary>
		/// Maps the specified first value to its matching second value.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <returns>The matching second value.</returns>
		public TSecond MapFirst(TFirst first)
		{
			try
			{
				return _mapper.Where(pair => Equals(pair.Item1, first)).Select(pair => pair.Item2).First();
			}
			catch (InvalidOperationException)
			{
				// ReSharper disable CompareNonConstrainedGenericWithNull
				throw new ArgumentOutOfRangeException("first", ((object)first).IfNotNull(arg => arg.ToString()), "First value not found.");
				// ReSharper restore CompareNonConstrainedGenericWithNull
			}
		}

		/// <summary>
		/// Maps the specified first value to its matching second value, or <paramref name="defaultValue"/> if no matching <paramref name="first"/> was found.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <param name="defaultValue">The value to return if <paramref name="first"/> is not found.</param>
		/// <returns>The matching second value.</returns>
		public TSecond MapFirst(TFirst first, TSecond defaultValue)
		{
			object second = _mapper.Where(pair => Equals(pair.Item1, first)).Select(pair => pair.Item2).FirstOrDefault();

			return (TSecond)(second ?? defaultValue);
		}

		/// <summary>
		/// Maps the specified second value to its matching first value.
		/// </summary>
		/// <param name="second">A value.</param>
		/// <returns>The matching first value.</returns>
		public TFirst Map(TSecond second)
		{
			return MapSecond(second);
		}

		/// <summary>
		/// Maps the specified second value to its matching first value, or <paramref name="defaultValue"/> if no matching <paramref name="second"/> was found.
		/// </summary>
		/// <param name="second">A value.</param>
		/// <param name="defaultValue">The value to return if <paramref name="second"/> is not found.</param>
		/// <returns>The matching first value.</returns>
		public TFirst Map(TSecond second, TSecond defaultValue)
		{
			return MapSecond(second, defaultValue);
		}

		/// <summary>
		/// Maps the specified second value to its matching first value.
		/// </summary>
		/// <param name="second">A value.</param>
		/// <returns>The matching first value.</returns>
		public TFirst MapSecond(TSecond second)
		{
			try
			{
				return _mapper.Where(pair => Equals(pair.Item2, second)).Select(pair => pair.Item1).First();
			}
			catch (InvalidOperationException)
			{
				// ReSharper disable CompareNonConstrainedGenericWithNull
				throw new ArgumentOutOfRangeException("second", ((object)second).IfNotNull(arg => arg.ToString()), "Second value not found.");
				// ReSharper restore CompareNonConstrainedGenericWithNull
			}
		}

		/// <summary>
		/// Maps the specified second value to its matching first value, or <paramref name="defaultValue"/> if no matching <paramref name="second"/> was found.
		/// </summary>
		/// <param name="second">A value.</param>
		/// <param name="defaultValue">The value to return if <paramref name="second"/> is not found.</param>
		/// <returns>The matching first value.</returns>
		public TFirst MapSecond(TSecond second, TSecond defaultValue)
		{
			object first = _mapper.Where(pair => Equals(pair.Item2, second)).Select(pair => pair.Item1).FirstOrDefault();

			return (TFirst)(first ?? defaultValue);
		}

		/// <summary>
		/// Adds a new pair to the pair mapper.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <param name="second">A value.</param>
		public void Add(TFirst first, TSecond second)
		{
			_mapper.Add(new Tuple<TFirst, TSecond>(first, second));
		}
	}
}