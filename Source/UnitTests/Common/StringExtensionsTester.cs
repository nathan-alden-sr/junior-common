using System;
using System.Globalization;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common
{
	public static class StringExtensionsTester
	{
		private enum TestEnum
		{
			Value1,
			Value2
		}

		[TestFixture]
		public class When_calling_EnsureNotEmpty_on_empty_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => "".EnsureNotEmpty("value"));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotEmpty_on_valid_parameter
		{
			[Test]
			[TestCase("foo")]
			[TestCase("a")]
			[TestCase(" ")]
			[TestCase(null)]
			public void Must_return_value(string value)
			{
				Assert.That(value.EnsureNotEmpty("value"), Is.EqualTo(value));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNullOrEmpty_on_empty_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => "".EnsureNotNullOrEmpty("value"));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNullOrEmpty_on_null_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentNullException>(() => ((string)null).EnsureNotNullOrEmpty("value"));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNullOrEmpty_on_valid_parameter
		{
			[Test]
			[TestCase("foo")]
			[TestCase("a")]
			[TestCase(" ")]
			public void Must_return_value(string value)
			{
				Assert.That(value.EnsureNotNullOrEmpty("value"), Is.EqualTo(value));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNullOrWhitespace_on_empty_or_whitespace_parameter
		{
			[Test]
			[TestCase("")]
			[TestCase(" ")]
			public void Must_throw_exception(string value)
			{
				Assert.Throws<ArgumentException>(() => value.EnsureNotNullOrWhitespace("value"));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNullOrWhitespace_on_null_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentNullException>(() => ((string)null).EnsureNotNullOrWhitespace("value"));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNullOrWhitespace_on_valid_parameter
		{
			[Test]
			[TestCase("foo")]
			[TestCase("a")]
			public void Must_return_value(string value)
			{
				Assert.That(value.EnsureNotNullOrWhitespace("value"), Is.EqualTo(value));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotWhitespace_on_empty_or_whitespace_parameter
		{
			[Test]
			[TestCase("")]
			[TestCase(" ")]
			public void Must_throw_exception(string value)
			{
				Assert.Throws<ArgumentException>(() => value.EnsureNotWhitespace("value"));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotWhitespace_on_valid_parameter
		{
			[Test]
			[TestCase("foo")]
			[TestCase("a")]
			[TestCase(null)]
			public void Must_return_value(string value)
			{
				Assert.That(value.EnsureNotWhitespace("value"), Is.EqualTo(value));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfEmpty_on_empty_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => "".ThrowIfEmpty("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfEmpty_on_valid_parameter
		{
			[Test]
			[TestCase("foo")]
			[TestCase("a")]
			[TestCase(" ")]
			[TestCase(null)]
			public void Must_not_throw_exception(string value)
			{
				Assert.DoesNotThrow(() => value.ThrowIfEmpty("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNullOrEmpty_on_empty_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => "".ThrowIfNullOrEmpty("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNullOrEmpty_on_null_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentNullException>(() => ((string)null).ThrowIfNullOrEmpty("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNullOrEmpty_on_valid_parameter
		{
			[Test]
			[TestCase("foo")]
			[TestCase("a")]
			[TestCase(" ")]
			public void Must_not_throw_exception(string value)
			{
				Assert.DoesNotThrow(() => value.ThrowIfNullOrEmpty("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNullOrWhitespace_on_empty_or_whitespace_parameter
		{
			[Test]
			[TestCase("")]
			[TestCase(" ")]
			public void Must_throw_exception(string value)
			{
				Assert.Throws<ArgumentException>(() => value.ThrowIfNullOrWhitespace("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNullOrWhitespace_on_null_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentNullException>(() => ((string)null).ThrowIfNullOrWhitespace("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNullOrWhitespace_on_valid_parameter
		{
			[Test]
			[TestCase("foo")]
			[TestCase("a")]
			public void Must_not_throw_exception(string value)
			{
				Assert.DoesNotThrow(() => value.ThrowIfNullOrWhitespace("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfWhitespace_on_empty_or_whitespace_parameter
		{
			[Test]
			[TestCase("")]
			[TestCase(" ")]
			public void Must_throw_exception(string value)
			{
				Assert.Throws<ArgumentException>(() => value.ThrowIfWhitespace("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfWhitespace_on_valid_parameter
		{
			[Test]
			[TestCase("foo")]
			[TestCase("a")]
			[TestCase(null)]
			public void Must_not_throw_exception(string value)
			{
				Assert.DoesNotThrow(() => value.ThrowIfWhitespace("value"));
			}
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
		public class When_trimming_the_end_of_a_string
		{
			[Test]
			[TestCase("FooBar", "Bar", "Foo")]
			[TestCase("FooBar", "Bar2", "FooBar")]
			[TestCase("FooBar", "", "FooBar")]
			public void Must_trim_value_correctly(string value, string trimString, string expected)
			{
				Assert.That(value.TrimEnd(trimString), Is.EqualTo(expected));
			}
		}

		[TestFixture]
		public class When_trimming_the_end_of_a_string_and_ignoring_case
		{
			[Test]
			[TestCase("FooBar", "bar", "Foo")]
			[TestCase("FooBar", "Bar", "Foo")]
			[TestCase("FooBar", "bar2", "FooBar")]
			[TestCase("FooBar", "bar2", "FooBar")]
			[TestCase("FooBar", "", "FooBar")]
			public void Must_trim_value_correctly(string value, string trimString, string expected)
			{
				Assert.That(value.TrimEnd(trimString, true, CultureInfo.InvariantCulture), Is.EqualTo(expected));
			}
		}

		[TestFixture]
		public class When_trimming_the_end_of_a_string_and_using_a_comparison_type
		{
			[Test]
			[TestCase("FooBar", "bar", "Foo")]
			[TestCase("FooBar", "Bar", "Foo")]
			[TestCase("FooBar", "bar2", "FooBar")]
			[TestCase("FooBar", "bar2", "FooBar")]
			[TestCase("FooBar", "", "FooBar")]
			public void Must_trim_value_correctly(string value, string trimString, string expected)
			{
				Assert.That(value.TrimEnd(trimString, StringComparison.OrdinalIgnoreCase), Is.EqualTo(expected));
			}
		}

		[TestFixture]
		public class When_trimming_the_start_of_a_string
		{
			[Test]
			[TestCase("FooBar", "Foo", "Bar")]
			[TestCase("FooBar", "Foo2", "FooBar")]
			[TestCase("FooBar", "", "FooBar")]
			public void Must_trim_value_correctly(string value, string trimString, string expected)
			{
				Assert.That(value.TrimStart(trimString), Is.EqualTo(expected));
			}
		}

		[TestFixture]
		public class When_trimming_the_start_of_a_string_and_ignoring_case
		{
			[Test]
			[TestCase("FooBar", "foo", "Bar")]
			[TestCase("FooBar", "Foo", "Bar")]
			[TestCase("FooBar", "foo2", "FooBar")]
			[TestCase("FooBar", "Foo2", "FooBar")]
			[TestCase("FooBar", "", "FooBar")]
			public void Must_trim_value_correctly(string value, string trimString, string expected)
			{
				Assert.That(value.TrimStart(trimString, true, CultureInfo.InvariantCulture), Is.EqualTo(expected));
			}
		}

		[TestFixture]
		public class When_trimming_the_start_of_a_string_and_using_a_comparison_type
		{
			[Test]
			[TestCase("FooBar", "foo", "Bar")]
			[TestCase("FooBar", "Foo", "Bar")]
			[TestCase("FooBar", "foo2", "FooBar")]
			[TestCase("FooBar", "Foo2", "FooBar")]
			[TestCase("FooBar", "", "FooBar")]
			public void Must_trim_value_correctly(string value, string trimString, string expected)
			{
				Assert.That(value.TrimStart(trimString, StringComparison.OrdinalIgnoreCase), Is.EqualTo(expected));
			}
		}

		[TestFixture]
		public class When_truncating_string
		{
			[Test]
			[TestCase("value", 10, "value")]
			[TestCase("value", 5, "value")]
			[TestCase("value", 3, "val")]
			[TestCase("value", 0, "")]
			public void Must_truncate_correctly(string value, int length, string expected)
			{
				Assert.That(value.Truncate(length), Is.EqualTo(expected));
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