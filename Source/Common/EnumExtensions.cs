using System;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for enumerations.
	/// </summary>
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

			var enumAsEnum = @enum as Enum;
			var flagAsEnum = flag as Enum;

			return enumAsEnum.HasFlag(flagAsEnum);
		}
	}
}