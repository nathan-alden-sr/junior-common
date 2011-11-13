using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for the <see cref="string"/> class.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Hashes a string using the MD5 algorithm.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <returns>The MD5-hashed value without hyphens.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		[DebuggerNonUserCode]
		public static string ToMd5HexString(this string value)
		{
			value.ThrowIfNull("value");

			MD5 md5 = MD5.Create();
			byte[] buffer = Encoding.UTF8.GetBytes(value);
			byte[] md5Buffer = md5.ComputeHash(buffer);

			return BitConverter.ToString(md5Buffer).Replace("-", "").ToLower();
		}

		/// <summary>
		/// Returns null if the specified string is equal to <see cref="string.Empty"/>; otherwise, returns <paramref name="value"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <returns>null if <paramref name="value"/> is equal to <see cref="string.Empty"/>; otherwise, <paramref name="value"/>.</returns>
		[DebuggerNonUserCode]
		public static string EmptyToNull(this string value)
		{
			return value == "" ? null : value;
		}

		/// <summary>
		/// Returns null if the specified string is equal to <see cref="string.Empty"/> or consists of all whitespace characters; otherwise, returns <paramref name="value"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <returns>null if <paramref name="value"/> is equal to <see cref="string.Empty"/> or consists of all whitespace characters; otherwise, <paramref name="value"/>.</returns>
		[DebuggerNonUserCode]
		public static string EmptyOrWhiteSpaceToNull(this string value)
		{
			return value != null ? (value.Any(t => !Char.IsWhiteSpace(t)) ? value : null) : null;
		}

		/// <summary>
		/// Returns the specified string as a <see cref="decimal"/> if the string is a valid <see cref="decimal"/> in the specified style; otherwise, returns null.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="numberStyles">Number styles to allow during conversion.</param>
		/// <returns><paramref name="value"/> as a <see cref="decimal"/> if the string is a valid <see cref="decimal"/> in the specified style; otherwise, null.</returns>
		[DebuggerNonUserCode]
		public static decimal? ToDecimal(this string value, NumberStyles numberStyles)
		{
			decimal result;

			return TryToDecimal(value, numberStyles, out result) ? (decimal?)result : null;
		}

		/// <summary>
		/// Returns the specified string as a <see cref="decimal"/> if the string is a valid <see cref="decimal"/> in the specified style; otherwise, returns <paramref name="defaultValue"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="numberStyles">Number styles to allow during conversion.</param>
		/// <param name="defaultValue">The value to return if <paramref name="value"/> cannot be converted to a <see cref="decimal"/>.</param>
		/// <returns><paramref name="value"/> as a <see cref="decimal"/> if the string is a valid <see cref="decimal"/> in the specified style; otherwise, null.</returns>
		[DebuggerNonUserCode]
		public static decimal ToDecimal(this string value, NumberStyles numberStyles, decimal defaultValue)
		{
			decimal result;

			return TryToDecimal(value, numberStyles, out result) ? result : defaultValue;
		}

		/// <summary>
		/// Attempts to convert the specified string to a <see cref="decimal"/> in the specified style.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="numberStyles">Number styles to allow during conversion.</param>
		/// <param name="result">The converted string, if conversion succeeded; otherwise, default(<see cref="decimal"/>).</param>
		/// <returns>true if conversion succeeded; otherwise, false.</returns>
		[DebuggerNonUserCode]
		public static bool TryToDecimal(this string value, NumberStyles numberStyles, out decimal result)
		{
			return Decimal.TryParse(value, numberStyles, null, out result);
		}

		/// <summary>
		/// Determines if the specified string can be converted to a <see cref="decimal"/> in the specified style.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="numberStyles">Number styles to allow during testing.</param>
		/// <returns>true if <paramref name="value"/> can be converted to <see cref="decimal"/>; otherwise, false.</returns>
		[DebuggerNonUserCode]
		public static bool CanToDecimal(this string value, NumberStyles numberStyles)
		{
			decimal t;

			return value.TryToDecimal(numberStyles, out t);
		}

		/// <summary>
		/// Returns the specified string as <typeparamref name="T"/> if the string is a valid <typeparamref name="T"/>; otherwise, returns null.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <returns><paramref name="value"/> as <typeparamref name="T"/> if the string is a valid <typeparamref name="T"/>; otherwise, null.</returns>
		[DebuggerNonUserCode]
		public static T? ToEnum<T>(this string value)
			where T : struct
		{
			return ToEnum<T>(value, false);
		}

		/// <summary>
		/// Returns the specified string as <typeparamref name="T"/> if the string is a valid <typeparamref name="T"/>; otherwise, returns null.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="ignoreCase">Determines if case must be ignored.</param>
		/// <returns><paramref name="value"/> as <typeparamref name="T"/> if the string is a valid <typeparamref name="T"/>; otherwise, null.</returns>
		[DebuggerNonUserCode]
		public static T? ToEnum<T>(this string value, bool ignoreCase)
			where T : struct
		{
			if (String.IsNullOrWhiteSpace(value))
			{
				return null;
			}

			try
			{
				return Enum<T>.Parse(value, ignoreCase);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Returns the specified string as <typeparamref name="T"/> if the string is a valid <typeparamref name="T"/>; otherwise, returns <paramref name="defaultValue"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="defaultValue">The value to return if <paramref name="value"/> cannot be converted to <typeparamref name="T"/>.</param>
		/// <returns><paramref name="value"/> converted to <typeparamref name="T"/> if conversion succeeded; otherwise, <paramref name="defaultValue"/>.</returns>
		[DebuggerNonUserCode]
		public static T ToEnum<T>(this string value, T defaultValue)
			where T : struct
		{
			return ToEnum(value, defaultValue, false);
		}

		/// <summary>
		/// Returns the specified string as <typeparamref name="T"/> if the string is a valid <typeparamref name="T"/>; otherwise, returns <paramref name="defaultValue"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="defaultValue">The value to return if <paramref name="value"/> cannot be converted to <typeparamref name="T"/>.</param>
		/// <param name="ignoreCase">Determines if case must be ignored.</param>
		/// <returns><paramref name="value"/> converted to <typeparamref name="T"/> if conversion succeeded; otherwise, <paramref name="defaultValue"/>.</returns>
		[DebuggerNonUserCode]
		public static T ToEnum<T>(this string value, T defaultValue, bool ignoreCase)
			where T : struct
		{
			if (String.IsNullOrWhiteSpace(value))
			{
				return defaultValue;
			}

			try
			{
				return Enum<T>.Parse(value, ignoreCase);
			}
			catch
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// Attempts to convert the specified string to <typeparamref name="T"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="result">The converted string, if conversion succeeded; otherwise, default(<typeparamref name="T"/>).</param>
		/// <returns>true if conversion succeeded; otherwise, false.</returns>
		[DebuggerNonUserCode]
		public static bool TryToEnum<T>(this string value, out T result)
			where T : struct
		{
			T? t = ToEnum<T>(value);

			if (t == null)
			{
				result = default(T);
				return false;
			}

			result = t.Value;
			return true;
		}

		/// <summary>
		/// Attempts to convert the specified string to <typeparamref name="T"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="ignoreCase">Determines if case must be ignored.</param>
		/// <param name="result">The converted string, if conversion succeeded; otherwise, default(<typeparamref name="T"/>).</param>
		/// <returns>true if conversion succeeded; otherwise, false.</returns>
		[DebuggerNonUserCode]
		public static bool TryToEnum<T>(this string value, bool ignoreCase, out T result)
			where T : struct
		{
			T? t = ToEnum<T>(value, ignoreCase);

			if (t == null)
			{
				result = default(T);
				return false;
			}

			result = t.Value;
			return true;
		}

		/// <summary>
		/// Determines if the specified string can be converted to <typeparamref name="T"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <returns>true if <paramref name="value"/> can be converted to <typeparamref name="T"/>; otherwise, false.</returns>
		[DebuggerNonUserCode]
		public static bool CanToEnum<T>(this string value)
			where T : struct
		{
			T t;

			return value.TryToEnum(out t);
		}

		/// <summary>
		/// Determines if the specified string can be converted to <typeparamref name="T"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/>.</param>
		/// <param name="ignoreCase">Determines if case must be ignored.</param>
		/// <returns>true if <paramref name="value"/> can be converted to <typeparamref name="T"/>; otherwise, false.</returns>
		[DebuggerNonUserCode]
		public static bool CanToEnum<T>(this string value, bool ignoreCase)
			where T : struct
		{
			T t;

			return value.TryToEnum(ignoreCase, out t);
		}
	}
}