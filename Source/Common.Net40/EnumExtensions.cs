using System;
using System.Diagnostics;

using Junior.Common.Net35;

namespace Junior.Common.Net40
{
	/// <summary>
	/// Extensions for enumerations.
	/// </summary>
	[DebuggerStepThrough]
	public static class EnumExtensions
	{
		/// <summary>
		/// Determines if the specified flag is present in the specified enumeration value.
		/// </summary>
		/// <typeparam name="T">A type deriving from <see cref="Enum"/>.</typeparam>
		/// <param name="enum">An enumeration value.</param>
		/// <param name="flag">The enumeration value to check for.</param>
		/// <returns>true if <paramref name="flag"/> exists in <paramref name="enum"/>; otherwise, false.</returns>
		/// <exception cref="InvalidGenericTypeArgumentException">Thrown when <typeparamref name="T"/> is not an enumeration type.</exception>
		public static bool HasFlag<T>(this T @enum, T flag)
			where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new InvalidGenericTypeArgumentException("Generic type must be an enum.", "T");
			}

			// ReSharper disable SuspiciousTypeConversion.Global
			// ReSharper disable ExpressionIsAlwaysNull
			var enumAsEnum = @enum as Enum;
			var flagAsEnum = flag as Enum;
			// ReSharper restore ExpressionIsAlwaysNull
			// ReSharper restore SuspiciousTypeConversion.Global

			return enumAsEnum.HasFlag(flagAsEnum);
		}
	}
}