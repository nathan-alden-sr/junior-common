using System;

namespace Junior.Common
{
	/// <summary>
	/// A United States 5-digit postal code.
	/// </summary>
	public class UnitedStatesFiveDigitPostalCode : PostalCode<UnitedStatesFiveDigitPostalCode>
	{
		/// <summary>
		/// The regular expression pattern used by <see cref="UnitedStatesFiveDigitPostalCode"/>.
		/// </summary>
		public const string RegexPattern = @"^\d{5}$";

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitedStatesFiveDigitPostalCode"/> class.
		/// </summary>
		/// <param name="postalCode">A postal code.</param>
		public UnitedStatesFiveDigitPostalCode(string postalCode)
			: base(postalCode, RegexPattern, "Value must be a United States 5-digit postal code.")
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitedStatesFiveDigitPostalCode"/> class.
		/// </summary>
		/// <param name="postalCode">A postal code.</param>
		public UnitedStatesFiveDigitPostalCode(int postalCode)
			: this(postalCode.ToString())
		{
		}

		/// <summary>
		/// Parses the specified string into a <see cref="UnitedStatesFiveDigitPostalCode"/>.
		/// </summary>
		/// <param name="value">A postal code.</param>
		/// <returns><paramref name="value"/> as a <see cref="UnitedStatesFiveDigitPostalCode"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		public static UnitedStatesFiveDigitPostalCode Parse(string value)
		{
			value.ThrowIfNull("value");

			return new UnitedStatesFiveDigitPostalCode(value);
		}

		/// <summary>
		/// Attempts to parse the specified string into a <see cref="UnitedStatesFiveDigitPostalCode"/>.
		/// </summary>
		/// <param name="value">A postal code.</param>
		/// <param name="result">A <see cref="UnitedStatesFiveDigitPostalCode"/> representing the specified postal code if <paramref name="value"/> is valid; otherwise, null.</param>
		/// <returns>true if the value was successfully parsed; otherwise, false.</returns>
		public static bool TryParse(string value, out UnitedStatesFiveDigitPostalCode result)
		{
			try
			{
				result = new UnitedStatesFiveDigitPostalCode(value);
				return true;
			}
			catch (Exception)
			{
				result = null;
				return false;
			}
		}
	}
}