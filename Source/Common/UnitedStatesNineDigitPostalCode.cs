using System;
using System.Globalization;

namespace Junior.Common
{
	/// <summary>
	/// A United States 9-digit postal code.
	/// </summary>
	public class UnitedStatesNineDigitPostalCode : PostalCode<UnitedStatesNineDigitPostalCode>
	{
		/// <summary>
		/// The regular expression pattern used by <see cref="UnitedStatesNineDigitPostalCode"/>.
		/// </summary>
		public const string RegexPattern = @"^\d{5}-?\d{4}$";

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitedStatesNineDigitPostalCode"/> class.
		/// </summary>
		/// <param name="postalCode">A postal code.</param>
		public UnitedStatesNineDigitPostalCode(string postalCode)
			: base(postalCode, RegexPattern, "Value must be a United States 9-digit postal code.")
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitedStatesNineDigitPostalCode"/> class.
		/// </summary>
		/// <param name="postalCode">A postal code.</param>
		public UnitedStatesNineDigitPostalCode(int postalCode)
			: this(postalCode.ToString(CultureInfo.InvariantCulture))
		{
		}

		/// <summary>
		/// Parses the specified string into a <see cref="UnitedStatesNineDigitPostalCode"/>.
		/// </summary>
		/// <param name="value">A postal code.</param>
		/// <returns><paramref name="value"/> as a <see cref="UnitedStatesNineDigitPostalCode"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		public static UnitedStatesNineDigitPostalCode Parse(string value)
		{
			value.ThrowIfNull("value");

			return new UnitedStatesNineDigitPostalCode(value);
		}

		/// <summary>
		/// Attempts to parse the specified string into a <see cref="UnitedStatesNineDigitPostalCode"/>.
		/// </summary>
		/// <param name="value">A postal code.</param>
		/// <param name="result">A <see cref="UnitedStatesNineDigitPostalCode"/> representing the specified postal code if <paramref name="value"/> is valid; otherwise, null.</param>
		/// <returns>true if the value was successfully parsed; otherwise, false.</returns>
		public static bool TryParse(string value, out UnitedStatesNineDigitPostalCode result)
		{
			try
			{
				result = new UnitedStatesNineDigitPostalCode(value);
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