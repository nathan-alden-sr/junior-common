using System;

namespace Junior.Common.UnitTests.Common
{
	public static class UnitedStatesFiveDigitPostalCodeTester
	{
		[TestFixture]
		public class When_constructing_with_invalid_postal_code_integer
		{
			[Test]
			[TestCase(-1)]
			[TestCase(1000)]
			[TestCase(9999)]
			[TestCase(100000)]
			public void Must_throw_exception(int postalCode)
			{
				Assert.Throws<ArgumentException>(() => new UnitedStatesFiveDigitPostalCode(postalCode));
			}
		}

		[TestFixture]
		public class When_constructing_with_invalid_postal_code_string
		{
			[Test]
			[TestCase("")]
			[TestCase("abcde")]
			[TestCase("1234a")]
			[TestCase("12345a")]
			[TestCase("a12345")]
			[TestCase("12345-6789")]
			[TestCase("123456789")]
			public void Must_throw_exception(string postalCode)
			{
				Assert.Throws<ArgumentException>(() => new UnitedStatesFiveDigitPostalCode(postalCode));
			}
		}

		[TestFixture]
		public class When_constructing_with_valid_postal_code
		{
			[Test]
			[TestCase("00000")]
			[TestCase("12345")]
			[TestCase("99999")]
			public void Must_not_throw_exception(string postalCode)
			{
				Assert.DoesNotThrow(() => new UnitedStatesFiveDigitPostalCode(postalCode));
			}
		}
	}
}