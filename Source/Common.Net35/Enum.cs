using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Junior.Common.Net35
{
	/// <summary>
	/// Generic wrapper for several <see cref="Enum"/> methods.
	/// </summary>
	/// <typeparam name="T">An enum type.</typeparam>
	[DebuggerStepThrough]
	public static class Enum<T>
		where T : struct
	{
		/// <summary>
		/// Retrieves the name of the constant in the <typeparamref name="T"/> that has the specified value.
		/// </summary>
		/// <param name="value">The value of a particular enumerated constant in terms of its underlying type.</param>
		/// <returns>A <see cref="string"/> containing the name of the enumerated constant in <typeparamref name="T"/> whose value is <paramref name="value"/>; or null if no such constant is found.</returns>
		public static string GetName<TValue>(TValue value)
		{
			return Enum.GetName(typeof(T), value);
		}

		/// <summary>
		/// Retrieves an enumerable of the names of the constants in a specified enumeration.
		/// </summary>
		/// <returns>An enumerable of the names of the constants in <typeparamref name="T"/>.</returns>
		public static IEnumerable<string> GetNames()
		{
			return Enum.GetNames(typeof(T));
		}

		/// <summary>
		/// Retrieves the underlying type of <typeparamref name="T"/>.
		/// </summary>
		/// <returns>The underlying type of <typeparamref name="T"/>.</returns>
		public static Type GetUnderlyingType()
		{
			return Enum.GetUnderlyingType(typeof(T));
		}

		/// <summary>
		/// Retrieves an enumerable of the values of the constants in <typeparamref name="T"/>.
		/// </summary>
		/// <returns>An enumerable that contains the values of the constants in <typeparamref name="T"/>.</returns>
		public static IEnumerable<T> GetValues()
		{
			return Enum.GetValues(typeof(T)).Cast<T>();
		}

		/// <summary>
		/// Indicates whether a constant with a specified value exists in <typeparamref name="T"/>.
		/// </summary>
		/// <param name="value">The value or name of a constant in <typeparamref name="T"/>.</param>
		/// <returns>true if a constant in <typeparamref name="T"/> has a value equal to <paramref name="value"/>; otherwise, false.</returns>
		public static bool IsDefined<TValue>(TValue value)
		{
			return Enum.IsDefined(typeof(T), value);
		}

		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object. A parameter specifies whether the operation is case-insensitive.
		/// </summary>
		/// <param name="value">A <see cref="string"/> containing the name or value to convert.</param>
		/// <param name="ignoreCase">true to ignore case; false to regard case.</param>
		/// <returns>An object of type <typeparamref name="T"/> whose value is represented by <paramref name="value"/>.</returns>
		public static T Parse(string value, bool ignoreCase = false)
		{
			return (T)Enum.Parse(typeof(T), value, ignoreCase);
		}

		/// <summary>
		/// Converts the specified object with an integer value to an enumeration member.
		/// </summary>
		/// <param name="value">The value convert to an enumeration member.</param>
		/// <returns>An enumeration object whose value is <paramref name="value"/>.</returns>
		public static T ToObject<TValue>(TValue value)
		{
			return (T)Enum.ToObject(typeof(T), value);
		}
	}
}