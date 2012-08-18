using System;
using System.Collections.Generic;

namespace Junior.Common
{
	/// <summary>
	/// Represents a way to map between two values.
	/// </summary>
	/// <typeparam name="TFirst"></typeparam>
	/// <typeparam name="TSecond"></typeparam>
	public interface IPairMapper<TFirst, TSecond> : IEnumerable<Tuple<TFirst, TSecond>>
	{
		/// <summary>
		/// Maps the specified first value to its matching second value.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <returns>The matching second value.</returns>
		TSecond Map(TFirst first);

		/// <summary>
		/// Maps the specified first value to its matching second value, or <paramref name="defaultValue"/> if no matching <paramref name="first"/> was found.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <param name="defaultValue">The value to return if <paramref name="first"/> is not found.</param>
		/// <returns>The matching second value.</returns>
		TSecond Map(TFirst first, TSecond defaultValue);

		/// <summary>
		/// Maps the specified first value to its matching second value.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <returns>The matching second value.</returns>
		TSecond MapFirst(TFirst first);

		/// <summary>
		/// Maps the specified first value to its matching second value, or <paramref name="defaultValue"/> if no matching <paramref name="first"/> was found.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <param name="defaultValue">The value to return if <paramref name="first"/> is not found.</param>
		/// <returns>The matching second value.</returns>
		TSecond MapFirst(TFirst first, TSecond defaultValue);

		/// <summary>
		/// Maps the specified second value to its matching first value.
		/// </summary>
		/// <param name="second">A value.</param>
		/// <returns>The matching first value.</returns>
		TFirst Map(TSecond second);

		/// <summary>
		/// Maps the specified second value to its matching first value, or <paramref name="defaultValue"/> if no matching <paramref name="second"/> was found.
		/// </summary>
		/// <param name="second">A value.</param>
		/// <param name="defaultValue">The value to return if <paramref name="second"/> is not found.</param>
		/// <returns>The matching first value.</returns>
		TFirst Map(TSecond second, TSecond defaultValue);

		/// <summary>
		/// Maps the specified second value to its matching first value.
		/// </summary>
		/// <param name="second">A value.</param>
		/// <returns>The matching first value.</returns>
		TFirst MapSecond(TSecond second);

		/// <summary>
		/// Maps the specified second value to its matching first value, or <paramref name="defaultValue"/> if no matching <paramref name="second"/> was found.
		/// </summary>
		/// <param name="second">A value.</param>
		/// <param name="defaultValue">The value to return if <paramref name="second"/> is not found.</param>
		/// <returns>The matching first value.</returns>
		TFirst MapSecond(TSecond second, TSecond defaultValue);

		/// <summary>
		/// Adds a new pair to the pair mapper.
		/// </summary>
		/// <param name="first">A value.</param>
		/// <param name="second">A value.</param>
		void Add(TFirst first, TSecond second);
	}
}