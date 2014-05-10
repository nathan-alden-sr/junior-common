using System;
using System.Diagnostics;

namespace Junior.Common.Net40
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
		/// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object. A parameter specifies whether the operation is case-sensitive. The return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="value">The <see cref="string"/> representation of the enumeration name or underlying value to convert.</param>
		/// <param name="result">When this method returns, contains an object of type <typeparamref name="T"/> whose value is represented by <paramref name="value"/>. This parameter is passed uninitialized.</param>
		/// <returns>true if the <paramref name="value"/> parameter was converted successfully; otherwise, false.</returns>
		public static bool TryParse(string value, out T result)
		{
			return Enum.TryParse(value, out result);
		}

		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object. A parameter specifies whether the operation is case-sensitive. The return value indicates whether the conversion succeeded.
		/// </summary>
		/// <param name="value">The <see cref="string"/> representation of the enumeration name or underlying value to convert.</param>
		/// <param name="ignoreCase">true to ignore case; false to consider case.</param>
		/// <param name="result">When this method returns, contains an object of type <typeparamref name="T"/> whose value is represented by <paramref name="value"/>. This parameter is passed uninitialized.</param>
		/// <returns>true if the <paramref name="value"/> parameter was converted successfully; otherwise, false.</returns>
		public static bool TryParse(string value, bool ignoreCase, out T result)
		{
			return Enum.TryParse(value, ignoreCase, out result);
		}
	}
}