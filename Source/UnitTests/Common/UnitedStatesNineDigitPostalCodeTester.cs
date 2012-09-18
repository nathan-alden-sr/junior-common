using System;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common
{
	public static class UnitedStatesNineDigitPostalCodeTester
	{
		[TestFixture]
		public class When_constructing_with_invalid_postal_code_integer
		{
			[Test]
			[TestCase(-1)]
			[TestCase(99999999)]
			[TestCase(1000000000)]
			[TestCase(12345)]
			public void Must_throw_exception(int postalCode)
			{
				Assert.Throws<ArgumentException>(() => new UnitedStatesNineDigitPostalCode(postalCode));
			}
		}

		[TestFixture]
		public class When_constructing_with_invalid_postal_code_string
		{
			[Test]
			[TestCase("")]
			[TestCase("abcdefghi")]
			[TestCase("12345678a")]
			[TestCase("a12345678")]
			[TestCase("12345")]
			[TestCase("12345678")]
			[TestCase("1234567890")]
			[TestCase("12345-67890")]
			[TestCase("1234-6789")]
			public void Must_throw_exception(string postalCode)
			{
				Assert.Throws<ArgumentException>(() => new UnitedStatesNineDigitPostalCode(postalCode));
			}
		}

		[TestFixture]
		public class When_constructing_with_valid_postal_code
		{
			[Test]
			[TestCase("000000000")]
			[TestCase("123456789")]
			[TestCase("999999999")]
			[TestCase("00000-0000")]
			[TestCase("12345-6789")]
			[TestCase("99999-9999")]
			public void Must_not_throw_exception(string postalCode)
			{
				Assert.DoesNotThrow(() => new UnitedStatesNineDigitPostalCode(postalCode));
			}
		}
	}
}