using System.Globalization;

namespace Junior.Common.UnitTests.Common
{
	public static class StringExtensionsTester
	{
		private enum TestEnum
		{
			// ReSharper disable UnusedMember.Local
			Value1,
			// ReSharper restore UnusedMember.Local
			Value2
		}

		[TestFixture]
		public class When_converting_invalid_decimal_string_to_decimal
		{
			[Test]
			public void Must_fail()
			{
				Assert.That("".ToDecimal(NumberStyles.Any), Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_decimal_string_to_decimal_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				Assert.That("".ToDecimal(NumberStyles.Any, 1m), Is.EqualTo(1m));
			}
		}

		[TestFixture]
		public class When_converting_invalid_enum_string_to_enum
		{
			[Test]
			public void Must_fail()
			{
				Assert.That("value".ToEnum<TestEnum>(), Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_enum_string_to_enum_case_insensitive
		{
			[Test]
			public void Must_fail()
			{
				Assert.That("value".ToEnum<TestEnum>(true), Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_enum_string_to_enum_case_insensitive_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				Assert.That("value".ToEnum(TestEnum.Value1, true), Is.EqualTo(TestEnum.Value1));
			}
		}

		[TestFixture]
		public class When_converting_invalid_enum_string_to_enum_case_sensitive
		{
			[Test]
			public void Must_fail()
			{
				Assert.That("value1".ToEnum<TestEnum>(false), Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_enum_string_to_enum_case_sensitive_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				Assert.That("Value1".ToEnum(TestEnum.Value1, false), Is.EqualTo(TestEnum.Value1));
			}
		}

		[TestFixture]
		public class When_converting_invalid_enum_string_to_enum_using_default
		{
			[Test]
			public void Must_fail()
			{
				Assert.That("value".ToEnum(TestEnum.Value1), Is.EqualTo(TestEnum.Value1));
			}
		}

		[TestFixture]
		public class When_converting_string_to_hex_MD5_string
		{
			[Test]
			public void Must_get_correct_hex_MD5_string()
			{
				const string systemUnderTest = "password";
				string md5HexString = systemUnderTest.ToMd5HexString();

				Assert.That(md5HexString, Is.EqualTo("5f4dcc3b5aa765d61d8327deb882cf99"));
			}
		}

		[TestFixture]
		public class When_converting_valid_decimal_string_to_decimal
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				Assert.That("123.45".ToDecimal(NumberStyles.AllowDecimalPoint), Is.EqualTo(123.45m));
			}
		}

		[TestFixture]
		public class When_converting_valid_decimal_string_to_decimal_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				Assert.That("123.45".ToDecimal(NumberStyles.AllowDecimalPoint, 1m), Is.EqualTo(123.45m));
			}
		}

		[TestFixture]
		public class When_converting_valid_enum_string_to_enum
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				Assert.That("Value2".ToEnum<TestEnum>(), Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_converting_valid_enum_string_to_enum_case_insensitive
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				Assert.That("Value2".ToEnum<TestEnum>(true), Is.EqualTo(TestEnum.Value2));
				Assert.That("value2".ToEnum<TestEnum>(true), Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_converting_valid_enum_string_to_enum_case_insensitive_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				Assert.That("Value2".ToEnum(TestEnum.Value1, true), Is.EqualTo(TestEnum.Value2));
				Assert.That("value2".ToEnum(TestEnum.Value1, true), Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_converting_valid_enum_string_to_enum_case_sensitive
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				Assert.That("Value2".ToEnum<TestEnum>(false), Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_converting_valid_enum_string_to_enum_case_sensitive_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				Assert.That("Value2".ToEnum<TestEnum>(false), Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_converting_valid_enum_string_to_enum_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				Assert.That("Value2".ToEnum(TestEnum.Value1), Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_determining_if_a_valid_decimal_string_can_convert_to_decimal
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That("123.45".CanToDecimal(NumberStyles.AllowDecimalPoint), Is.True);
			}
		}

		[TestFixture]
		public class When_determining_if_a_valid_enum_string_can_convert_to_enum
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That("Value2".CanToEnum<TestEnum>(), Is.True);
				Assert.That("Value2".CanToEnum<TestEnum>(true), Is.True);
				Assert.That("value2".CanToEnum<TestEnum>(true), Is.True);
				Assert.That("Value2".CanToEnum<TestEnum>(false), Is.True);
			}
		}

		[TestFixture]
		public class When_determining_if_an_invalid_decimal_string_can_convert_to_decimal
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That("".CanToDecimal(NumberStyles.Any), Is.False);
			}
		}

		[TestFixture]
		public class When_determining_if_an_invalid_enum_string_can_convert_to_enum
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That("value2".CanToEnum<TestEnum>(), Is.False);
				Assert.That("".CanToEnum<TestEnum>(), Is.False);
				Assert.That("".CanToEnum<TestEnum>(true), Is.False);
				Assert.That("value2".CanToEnum<TestEnum>(false), Is.False);
				Assert.That("".CanToEnum<TestEnum>(false), Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_empty_string_to_null_using_emptyorwhitespacetonull
		{
			[Test]
			public void Must_convert_to_null()
			{
				Assert.That("".EmptyOrWhiteSpaceToNull(), Is.Null);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_empty_string_to_null_using_emptytonull
		{
			[Test]
			public void Must_convert_to_null()
			{
				Assert.That("".EmptyToNull(), Is.Null);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_decimal_string_to_decimal
		{
			[Test]
			public void Must_fail()
			{
				decimal d;
				bool result = "".TryToDecimal(NumberStyles.Any, out d);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_enum_string_to_enum
		{
			[Test]
			public void Must_fail()
			{
				TestEnum testEnum;
				bool result = "value".TryToEnum(out testEnum);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_enum_string_to_enum_case_insensitive
		{
			[Test]
			public void Must_fail()
			{
				TestEnum testEnum;
				bool result = "value".TryToEnum(true, out testEnum);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_enum_string_to_enum_case_sensitive
		{
			[Test]
			public void Must_fail()
			{
				TestEnum testEnum;
				bool result = "value1".TryToEnum(false, out testEnum);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_non_empty_string_to_null_using_emptyorwhitespacetonull
		{
			[Test]
			public void Must_not_convert_to_null()
			{
				Assert.That("test".EmptyToNull(), Is.EqualTo("test"));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_non_empty_string_to_null_using_emptytonull
		{
			[Test]
			public void Must_Not_convert_to_null()
			{
				Assert.That(" ".EmptyToNull(), Is.EqualTo(" "));
				Assert.That("test".EmptyToNull(), Is.EqualTo("test"));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_decimal_string_to_decimal
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				decimal d;
				bool result = "123.45".TryToDecimal(NumberStyles.AllowDecimalPoint, out d);

				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(123.45m));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_enum_string_to_enum
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				TestEnum testEnum;
				bool result = "Value2".TryToEnum(out testEnum);

				Assert.That(result, Is.True);
				Assert.That(testEnum, Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_enum_string_to_enum_case_insensitive
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				TestEnum testEnum;
				bool result = "Value2".TryToEnum(true, out testEnum);

				Assert.That(result, Is.True);
				Assert.That(testEnum, Is.EqualTo(TestEnum.Value2));

				result = "value2".TryToEnum(true, out testEnum);
				Assert.That(result, Is.True);
				Assert.That(testEnum, Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_enum_string_to_enum_case_sensitive
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				TestEnum testEnum;
				bool result = "Value2".TryToEnum(false, out testEnum);

				Assert.That(result, Is.True);
				Assert.That(testEnum, Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_white_space_string_to_null_emptyorwhitespacetonull
		{
			[Test]
			public void Must_convert_to_null()
			{
				Assert.That(" ".EmptyOrWhiteSpaceToNull(), Is.Null);
			}
		}
	}
}