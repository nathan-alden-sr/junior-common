using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common
{
	public static class ObjectExtensionsTester
	{
		private enum TestEnum
		{
			Value1 = 0,
			Value2 = 1
		}

		[TestFixture]
		public class When_calling_ThrowIfNull_on_non_null_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				object value = 0;

				Assert.DoesNotThrow(() => value.ThrowIfNull("value"));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNull_on_null_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				object value = null;

				Assert.Throws<ArgumentNullException>(() => value.ThrowIfNull("value"));
			}
		}

		[TestFixture]
		public class When_converting_invalid_DateTime_string_to_DateTime
		{
			[Test]
			public void Must_convert_to_null()
			{
				DateTime? result = "value".Convert<DateTime>();

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_DateTime_string_to_DateTime_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				DateTime result = "value".Convert(DateTime.MaxValue);

				Assert.That(result, Is.EqualTo(DateTime.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_bool_string_to_bool
		{
			[Test]
			public void Must_convert_to_null()
			{
				bool? result = "value".Convert<bool>();

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_bool_string_to_bool_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				bool result = "true".Convert(true);

				Assert.That(result, Is.True);
			}
		}

		[TestFixture]
		public class When_converting_invalid_byte_string_to_byte
		{
			[Test]
			public void Must_convert_to_null()
			{
				byte? result = "value".Convert<byte>();

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_byte_string_to_byte_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				byte result = "value".Convert(Byte.MaxValue);

				Assert.That(result, Is.EqualTo(Byte.MaxValue));

				result = "-256".Convert(Byte.MaxValue);
				Assert.That(result, Is.EqualTo(Byte.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_char_string_to_char
		{
			[Test]
			public void Must_convert_to_null()
			{
				char? result = "value".Convert<char>();

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_decimal_string_to_decimal
		{
			[Test]
			public void Must_convert_to_null()
			{
				decimal? result = "value".Convert<decimal>();

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_decimal_string_to_decimal_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				decimal result = "value".Convert(Decimal.MaxValue);

				Assert.That(result, Is.EqualTo(Decimal.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_decimal_string_to_decimal_with_styles_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				decimal result = "value".ToDecimal(NumberStyles.Any, Decimal.MaxValue);

				Assert.That(result, Is.EqualTo(Decimal.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_double_string_to_double
		{
			[Test]
			public void Must_convert_to_null()
			{
				double? result = "value".Convert<double>();

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_double_string_to_double_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				double result = "value".Convert(Double.MaxValue);

				Assert.That(result, Is.EqualTo(Double.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_float_string_to_float
		{
			[Test]
			public void Must_convert_to_null()
			{
				float? result = "value".Convert<float>();

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_float_string_to_float_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				float result = "value".Convert(Single.MaxValue);

				Assert.That(result, Is.EqualTo(Single.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_int_string_to_int
		{
			[Test]
			public void Must_convert_to_null()
			{
				int? result = "value".Convert<int>();
				Assert.That(result, Is.Null);

				result = "-1.1".Convert<int>();
				Assert.That(result, Is.Null);

				result = "1.1".Convert<int>();
				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_int_string_to_int_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				int result = "value".Convert(Int32.MaxValue);
				Assert.That(result, Is.EqualTo(Int32.MaxValue));

				result = "-1.1".Convert(Int32.MaxValue);
				Assert.That(result, Is.EqualTo(Int32.MaxValue));

				result = "1.1".Convert(Int32.MaxValue);
				Assert.That(result, Is.EqualTo(Int32.MaxValue));
			}
		}

		public class When_converting_invalid_long_string_to_long
		{
			[Test]
			public void Must_convert_to_null()
			{
				long? result = "value".Convert<long>();
				Assert.That(result, Is.Null);

				result = "-1.1".Convert<long>();
				Assert.That(result, Is.Null);

				result = "1.1".Convert<long>();
				Assert.That(result, Is.Null);
			}
		}

		public class When_converting_invalid_long_string_to_long_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				long result = "value".Convert(Int64.MaxValue);
				Assert.That(result, Is.EqualTo(Int64.MaxValue));

				result = "-1.1".Convert(Int64.MaxValue);
				Assert.That(result, Is.EqualTo(Int64.MaxValue));

				result = "1.1".Convert(Int64.MaxValue);
				Assert.That(result, Is.EqualTo(Int64.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_sbyte_string_to_sbyte
		{
			[Test]
			public void Must_convert_to_null()
			{
				sbyte? result = "value".Convert<sbyte>();

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_sbyte_string_to_sbyte_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				sbyte result = "value".Convert((sbyte)1);

				Assert.That(result, Is.EqualTo((sbyte)1));
			}
		}

		[TestFixture]
		public class When_converting_invalid_short_string_to_short
		{
			[Test]
			public void Must_convert_to_null()
			{
				short? result = "value".Convert<short>();
				Assert.That(result, Is.Null);

				result = "-1.1".Convert<short>();
				Assert.That(result, Is.Null);

				result = "1.1".Convert<short>();
				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_short_string_to_short_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				short result = "value".Convert(Int16.MaxValue);
				Assert.That(result, Is.EqualTo(Int16.MaxValue));

				result = "-1.1".Convert(Int16.MaxValue);
				Assert.That(result, Is.EqualTo(Int16.MaxValue));

				result = "1.1".Convert(Int16.MaxValue);
				Assert.That(result, Is.EqualTo(Int16.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_uint_string_to_uint
		{
			[Test]
			public void Must_convert_to_null()
			{
				uint? result = "value".Convert<uint>();
				Assert.That(result, Is.Null);

				result = "-1".Convert<uint>();
				Assert.That(result, Is.Null);

				result = "1.1".Convert<uint>();
				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_uint_string_to_uint_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				uint result = "value".Convert(UInt32.MaxValue);
				Assert.That(result, Is.EqualTo(UInt32.MaxValue));

				result = "-1.1".Convert(UInt32.MaxValue);
				Assert.That(result, Is.EqualTo(UInt32.MaxValue));

				result = "1.1".Convert(UInt32.MaxValue);
				Assert.That(result, Is.EqualTo(UInt32.MaxValue));
			}
		}

		public class When_converting_invalid_ulong_string_to_ulong
		{
			[Test]
			public void Must_convert_to_null()
			{
				ulong? result = "value".Convert<ulong>();
				Assert.That(result, Is.Null);

				result = "-1".Convert<ulong>();
				Assert.That(result, Is.Null);

				result = "1.1".Convert<ulong>();
				Assert.That(result, Is.Null);
			}
		}

		public class When_converting_invalid_ulong_string_to_ulong_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				ulong result = "value".Convert(UInt64.MaxValue);
				Assert.That(result, Is.EqualTo(UInt64.MaxValue));

				result = "-1.1".Convert(UInt64.MaxValue);
				Assert.That(result, Is.EqualTo(UInt64.MaxValue));

				result = "1.1".Convert(UInt64.MaxValue);
				Assert.That(result, Is.EqualTo(UInt64.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_ushort_string_to_ushort
		{
			[Test]
			public void Must_convert_to_null()
			{
				ushort? result = "value".Convert<ushort>();
				Assert.That(result, Is.Null);

				result = "-1".Convert<ushort>();
				Assert.That(result, Is.Null);

				result = "1.1".Convert<ushort>();
				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_ushort_string_to_ushort_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				ushort result = "value".Convert(UInt16.MaxValue);
				Assert.That(result, Is.EqualTo(UInt16.MaxValue));

				result = "-1.1".Convert(UInt16.MaxValue);
				Assert.That(result, Is.EqualTo(UInt16.MaxValue));

				result = "1.1".Convert(UInt16.MaxValue);
				Assert.That(result, Is.EqualTo(UInt16.MaxValue));
			}
		}

		[TestFixture]
		public class When_converting_invalid_value_to_enum
		{
			[Test]
			public void Must_convert_to_null()
			{
				Assert.That("".Convert<TestEnum>(), Is.Null);
				Assert.That(Int32.MaxValue.Convert<TestEnum>(), Is.Null);
				Assert.That('0'.Convert<TestEnum>(), Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_value_to_enum_case_insensitive
		{
			[Test]
			public void Must_convert_to_null()
			{
				TestEnum? result = "value".ToEnum<TestEnum>(true);

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_value_to_enum_case_insensitive_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				TestEnum result = "value".ToEnum(TestEnum.Value2, true);

				Assert.That(result, Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_converting_invalid_value_to_enum_case_sensitive
		{
			[Test]
			public void Must_convert_to_null()
			{
				TestEnum? result = "value".ToEnum<TestEnum>(false);

				Assert.That(result, Is.Null);

				result = "value2".ToEnum<TestEnum>(false);

				Assert.That(result, Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_invalid_value_to_enum_case_sensitive_using_default
		{
			[Test]
			public void Must_convert_to_default()
			{
				TestEnum result = "value".ToEnum(TestEnum.Value2, false);

				Assert.That(result, Is.EqualTo(TestEnum.Value2));

				result = "value1".ToEnum(TestEnum.Value2, false);

				Assert.That(result, Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_converting_valid_bool_string_to_bool
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				bool? result = "True".Convert<bool>();

				Assert.That(result, Is.True);

				result = "true".Convert<bool>();
				Assert.That(result, Is.True);

				result = "False".Convert<bool>();
				Assert.That(result, Is.False);

				result = "false".Convert<bool>();
				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_converting_valid_bool_string_to_bool_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				bool result = "True".Convert(false);

				Assert.That(result, Is.True);

				result = "true".Convert(false);
				Assert.That(result, Is.True);

				result = "False".Convert(true);
				Assert.That(result, Is.False);

				result = "false".Convert(true);
				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_converting_valid_byte_string_to_byte
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				byte? result = "1".Convert<byte>();

				Assert.That(result, Is.EqualTo((byte)1));
			}
		}

		[TestFixture]
		public class When_converting_valid_byte_string_to_byte_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				byte result = "1".Convert(Byte.MaxValue);

				Assert.That(result, Is.EqualTo((byte)1));
			}
		}

		[TestFixture]
		public class When_converting_valid_char_string_to_char
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				char? result = "1".Convert<char>();

				Assert.That(result, Is.EqualTo('1'));
			}
		}

		[TestFixture]
		public class When_converting_valid_decimal_string_to_decimal
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				decimal? result = "-1".Convert<decimal>();
				Assert.That(result, Is.EqualTo(-1m));

				result = "-1.1".Convert<decimal>();
				Assert.That(result, Is.EqualTo(-1.1m));

				result = "1".Convert<decimal>();
				Assert.That(result, Is.EqualTo(1m));

				result = "1.1".Convert<decimal>();
				Assert.That(result, Is.EqualTo(1.1m));
			}
		}

		[TestFixture]
		public class When_converting_valid_decimal_string_to_decimal_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				decimal result = "-1".Convert(Decimal.MaxValue);
				Assert.That(result, Is.EqualTo(-1m));

				result = "-1.1".Convert(Decimal.MaxValue);
				Assert.That(result, Is.EqualTo(-1.1m));

				result = "1".Convert(Decimal.MaxValue);
				Assert.That(result, Is.EqualTo(1m));

				result = "1.1".Convert(Decimal.MaxValue);
				Assert.That(result, Is.EqualTo(1.1m));
			}
		}

		[TestFixture]
		public class When_converting_valid_decimal_string_to_decimal_with_styles_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				decimal result = "-1".ToDecimal(NumberStyles.Any, Decimal.MaxValue);

				Assert.That(result, Is.EqualTo(-1));

				result = "-1.1".ToDecimal(NumberStyles.Any, Decimal.MaxValue);
				Assert.That(result, Is.EqualTo(-1.1m));

				result = "1".ToDecimal(NumberStyles.Any, Decimal.MaxValue);
				Assert.That(result, Is.EqualTo(1));

				result = "1.1".ToDecimal(NumberStyles.Any, Decimal.MaxValue);
				Assert.That(result, Is.EqualTo(1.1m));
			}
		}

		[TestFixture]
		public class When_converting_valid_double_string_to_double
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				double? result = "-1".Convert<double>();
				Assert.That(result, Is.EqualTo(-1d));

				result = "-1.1".Convert<double>();
				Assert.That(result, Is.EqualTo(-1.1d));

				result = "1".Convert<double>();
				Assert.That(result, Is.EqualTo(1d));

				result = "1.1".Convert<double>();
				Assert.That(result, Is.EqualTo(1.1d));
			}
		}

		[TestFixture]
		public class When_converting_valid_double_string_to_double_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				double result = "-1".Convert(Double.MaxValue);
				Assert.That(result, Is.EqualTo(-1d));

				result = "-1.1".Convert(Double.MaxValue);
				Assert.That(result, Is.EqualTo(-1.1d));

				result = "1".Convert(Double.MaxValue);
				Assert.That(result, Is.EqualTo(1d));

				result = "1.1".Convert(Double.MaxValue);
				Assert.That(result, Is.EqualTo(1.1d));
			}
		}

		[TestFixture]
		public class When_converting_valid_float_string_to_float
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				float? result = "-1".Convert<float>();
				Assert.That(result, Is.EqualTo(-1f));

				result = "-1.1".Convert<float>();
				Assert.That(result, Is.EqualTo(-1.1f));

				result = "1".Convert<float>();
				Assert.That(result, Is.EqualTo(1f));

				result = "1.1".Convert<float>();
				Assert.That(result, Is.EqualTo(1.1f));
			}
		}

		[TestFixture]
		public class When_converting_valid_float_string_to_float_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				float result = "-1".Convert(Single.MaxValue);
				Assert.That(result, Is.EqualTo(-1f));

				result = "-1.1".Convert(Single.MaxValue);
				Assert.That(result, Is.EqualTo(-1.1f));

				result = "1".Convert(Single.MaxValue);
				Assert.That(result, Is.EqualTo(1f));

				result = "1.1".Convert(Single.MaxValue);
				Assert.That(result, Is.EqualTo(1.1f));
			}
		}

		[TestFixture]
		public class When_converting_valid_int_string_to_int
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				int? result = "-1".Convert<int>();
				Assert.That(result, Is.EqualTo(-1));

				result = "1".Convert<int>();
				Assert.That(result, Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_converting_valid_int_string_to_int_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				int result = "-1".Convert(Int32.MaxValue);
				Assert.That(result, Is.EqualTo(-1));

				result = "1".Convert(Int32.MaxValue);
				Assert.That(result, Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_converting_valid_long_string_to_long
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				long? result = "-1".Convert<long>();
				Assert.That(result, Is.EqualTo(-1L));

				result = "1".Convert(Int64.MaxValue);
				Assert.That(result, Is.EqualTo(1L));
			}
		}

		[TestFixture]
		public class When_converting_valid_long_string_to_long_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				long result = "-1".Convert(Int64.MaxValue);
				Assert.That(result, Is.EqualTo(-1));

				result = "1".Convert(Int64.MaxValue);
				Assert.That(result, Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_converting_valid_sbyte_string_to_sbyte
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				sbyte? result = "-1".Convert<sbyte>();

				Assert.That(result, Is.EqualTo((sbyte)-1));

				result = "1".Convert<sbyte>();
				Assert.That(result, Is.EqualTo((sbyte)1));
			}
		}

		[TestFixture]
		public class When_converting_valid_sbyte_string_to_sbyte_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				sbyte result = "1".Convert(SByte.MaxValue);

				Assert.That(result, Is.EqualTo((sbyte)1));

				result = "-1".Convert(SByte.MaxValue);
				Assert.That(result, Is.EqualTo((sbyte)-1));
			}
		}

		[TestFixture]
		public class When_converting_valid_short_string_to_short
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				short? result = "-1".Convert<short>();
				Assert.That(result, Is.EqualTo((short)-1));

				result = "1".Convert<short>();
				Assert.That(result, Is.EqualTo((short)1));
			}
		}

		[TestFixture]
		public class When_converting_valid_short_string_to_short_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				short result = "-1".Convert(Int16.MaxValue);
				Assert.That(result, Is.EqualTo((short)-1));

				result = "1".Convert(Int16.MaxValue);
				Assert.That(result, Is.EqualTo((short)1));
			}
		}

		[TestFixture]
		public class When_converting_valid_uint_string_to_uint
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				uint? result = "1".Convert<uint>();
				Assert.That(result, Is.EqualTo(1u));
			}
		}

		[TestFixture]
		public class When_converting_valid_uint_string_to_uint_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				uint result = "1".Convert(UInt32.MaxValue);
				Assert.That(result, Is.EqualTo(1u));
			}
		}

		[TestFixture]
		public class When_converting_valid_ulong_string_to_ulong
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				ulong? result = "1".Convert(UInt64.MaxValue);
				Assert.That(result, Is.EqualTo(1ul));
			}
		}

		[TestFixture]
		public class When_converting_valid_ulong_string_to_ulong_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				ulong result = "1".Convert(UInt64.MaxValue);
				Assert.That(result, Is.EqualTo(1ul));
			}
		}

		[TestFixture]
		public class When_converting_valid_ushort_string_to_ushort
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				ushort? result = "1".Convert<ushort>();
				Assert.That(result, Is.EqualTo((ushort)1));
			}
		}

		[TestFixture]
		public class When_converting_valid_ushort_string_to_ushort_using_default
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				ushort result = "1".Convert(UInt16.MaxValue);
				Assert.That(result, Is.EqualTo((ushort)1));
			}
		}

		[TestFixture]
		public class When_converting_valid_value_to_enum
		{
			[Test]
			public void Must_convert_to_enum()
			{
				Assert.That(0.Convert<TestEnum>(), Is.EqualTo(TestEnum.Value1));
				Assert.That("Value1".Convert<TestEnum>(), Is.EqualTo(TestEnum.Value1));
			}
		}

		[TestFixture]
		public class When_converting_valid_value_to_enum_case_insensitive
		{
			[Test]
			public void Must_convert_to_value()
			{
				TestEnum? result = "Value2".ToEnum<TestEnum>(true);

				Assert.That(result, Is.EqualTo(TestEnum.Value2));

				result = "value2".ToEnum<TestEnum>(true);

				Assert.That(result, Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_converting_valid_value_to_enum_case_insensitive_using_default
		{
			[Test]
			public void Must_convert_to_value()
			{
				TestEnum result = "Value1".ToEnum(TestEnum.Value2, true);

				Assert.That(result, Is.EqualTo(TestEnum.Value1));

				result = "value1".ToEnum(TestEnum.Value2, true);

				Assert.That(result, Is.EqualTo(TestEnum.Value1));
			}
		}

		[TestFixture]
		public class When_converting_valid_value_to_enum_case_sensitive
		{
			[Test]
			public void Must_convert_to_value()
			{
				TestEnum? result = "Value2".ToEnum<TestEnum>(false);

				Assert.That(result, Is.EqualTo(TestEnum.Value2));
			}
		}

		[TestFixture]
		public class When_converting_valid_value_to_enum_case_sensitive_using_default
		{
			[Test]
			public void Must_convert_to_value()
			{
				TestEnum result = "Value1".ToEnum(TestEnum.Value2, false);

				Assert.That(result, Is.EqualTo(TestEnum.Value1));
			}
		}

		[TestFixture]
		public class When_creating_if_not_null_chain_with_first_reference_of_not_null
		{
			[Test]
			public void Must_return_lambda_expression()
			{
				Assert.That("value".IfNotNull(@class => @class.ToString()), Is.EqualTo("value"));
			}
		}

		[TestFixture]
		public class When_creating_if_not_null_chain_with_first_reference_of_null
		{
			[Test]
			public void Must_return_null()
			{
				Assert.That(((object)null).IfNotNull(@class => @class.ToString()), Is.Null);
			}
		}

		[TestFixture]
		public class When_determining_if_double_converts_to_enum
		{
			[Test]
			public void Must_fail()
			{
				Assert.That(Double.MaxValue.CanConvert(typeof(TestEnum)), Is.False);
				Assert.That(Double.MaxValue.CanConvert<TestEnum>(), Is.False);
			}
		}

		[TestFixture]
		public class When_determining_if_int_converts_to_double
		{
			[Test]
			public void Must_succeed()
			{
				Assert.That(1.CanConvert(typeof(double)), Is.True);
				Assert.That(1.CanConvert<double>(), Is.True);
			}
		}

		[TestFixture]
		public class When_getting_item_from_enumerable_by_maximum_property_value
		{
			[Test]
			public void Must_get_correct_item()
			{
				IEnumerable<string> items = new[]
				                            	{
				                            		"Test",
				                            		"By",
				                            		"Length"
				                            	};

				Assert.That(items.MaxBy(arg => arg.Length), Is.EqualTo("Length"));
			}
		}

		[TestFixture]
		public class When_getting_item_from_enumerable_by_minimum_property_value
		{
			[Test]
			public void Must_get_correct_item()
			{
				IEnumerable<string> items = new[]
				                            	{
				                            		"Test",
				                            		"By",
				                            		"Length"
				                            	};

				Assert.That(items.MinBy(arg => arg.Length), Is.EqualTo("By"));
			}
		}

		[TestFixture]
		public class When_traversing_and_not_omitting_null
		{
			[Test]
			public void Must_yield_null_as_last_element()
			{
				var exception = new Exception("Test 1", new Exception("Test 2"));

				Assert.That(exception.Traverse(arg => arg.InnerException, false).Last(), Is.Null);
			}
		}

		[TestFixture]
		public class When_traversing_and_omitting_null
		{
			[Test]
			public void Must_not_yield_null_as_last_element()
			{
				var exception = new Exception("Test 1", new Exception("Test 2"));

				Assert.That(exception.Traverse(arg => arg.InnerException).Last(), Is.Not.Null);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_DateTime_string_to_DateTime
		{
			[Test]
			public void Must_convert_to_null()
			{
				DateTime dt;
				bool result = "value".TryConvert(out dt);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_bool_string_to_bool
		{
			[Test]
			public void Must_convert_to_null()
			{
				bool b;
				bool result = "value".TryConvert(out b);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_decimal_string_to_decimal
		{
			[Test]
			public void Must_convert_to_null()
			{
				decimal d;
				bool result = "value".TryConvert(out d);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_double_string_to_double
		{
			[Test]
			public void Must_convert_to_null()
			{
				double d;
				bool result = "value".TryConvert(out d);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_float_string_to_float
		{
			[Test]
			public void Must_convert_to_null()
			{
				float d;
				bool result = "value".TryConvert(out d);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_int_string_to_int
		{
			[Test]
			public void Must_convert_to_null()
			{
				int i;
				bool result = "value".TryConvert(out i);
				Assert.That(result, Is.False);

				result = "-1.1".TryConvert(out i);
				Assert.That(result, Is.False);

				result = "1.1".TryConvert(out i);
				Assert.That(result, Is.False);
			}
		}

		public class When_trying_to_convert_invalid_long_string_to_long
		{
			[Test]
			public void Must_convert_to_null()
			{
				long l;
				bool result = "value".TryConvert(out l);
				Assert.That(result, Is.False);

				result = "-1.1".TryConvert(out l);
				Assert.That(result, Is.False);

				result = "1.1".TryConvert(out l);
				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_sbyte_string_to_sbyte
		{
			[Test]
			public void Must_convert_to_null()
			{
				sbyte sb;
				bool result = "value".TryConvert(out sb);

				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_short_string_to_short
		{
			[Test]
			public void Must_convert_to_null()
			{
				short s;
				bool result = "value".TryConvert(out s);
				Assert.That(result, Is.False);

				result = "-1.1".TryConvert(out s);
				Assert.That(result, Is.False);

				result = "1.1".TryConvert(out s);
				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_uint_string_to_uint
		{
			[Test]
			public void Must_convert_to_null()
			{
				uint i;
				bool result = "value".TryConvert(out i);
				Assert.That(result, Is.False);

				result = "-1.1".TryConvert(out i);
				Assert.That(result, Is.False);

				result = "1.1".TryConvert(out i);
				Assert.That(result, Is.False);
			}
		}

		public class When_trying_to_convert_invalid_ulong_string_to_ulong
		{
			[Test]
			public void Must_convert_to_null()
			{
				ulong l;
				bool result = "value".TryConvert(out l);
				Assert.That(result, Is.False);

				result = "-1.1".TryConvert(out l);
				Assert.That(result, Is.False);

				result = "1.1".TryConvert(out l);
				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_ushort_string_to_ushort
		{
			[Test]
			public void Must_convert_to_null()
			{
				ushort s;
				bool result = "value".TryConvert(out s);
				Assert.That(result, Is.False);

				result = "-1.1".TryConvert(out s);
				Assert.That(result, Is.False);

				result = "1.1".TryConvert(out s);
				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_invalid_value_to_enum
		{
			[Test]
			public void Must_convert_to_null()
			{
				TestEnum testEnum;
				bool result = "".TryConvert(out testEnum);

				Assert.That(result, Is.False);

				result = Int32.MaxValue.TryConvert(out testEnum);
				Assert.That(result, Is.False);

				result = '0'.TryConvert(out testEnum);
				Assert.That(result, Is.False);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_bool_string_to_bool
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				bool b;
				bool result = "True".TryConvert(out b);

				Assert.That(b, Is.True);
				Assert.That(result, Is.True);

				result = "true".TryConvert(out b);
				Assert.That(b, Is.True);
				Assert.That(result, Is.True);

				result = "False".TryConvert(out b);
				Assert.That(b, Is.False);
				Assert.That(result, Is.True);

				result = "false".TryConvert(out b);
				Assert.That(b, Is.False);
				Assert.That(result, Is.True);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_decimal_string_to_decimal
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				decimal d;
				bool result = "-1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(-1m));

				result = "-1.1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(-1.1m));

				result = "1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(1m));

				result = "1.1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(1.1m));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_double_string_to_double
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				double d;
				bool result = "-1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(-1d));

				result = "-1.1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(-1.1d));

				result = "1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(1d));

				result = "1.1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(1.1d));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_float_string_to_float
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				float d;
				bool result = "-1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(-1f));

				result = "-1.1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(-1.1f));

				result = "1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(1f));

				result = "1.1".TryConvert(out d);
				Assert.That(result, Is.True);
				Assert.That(d, Is.EqualTo(1.1f));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_int_string_to_int
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				int i;
				bool result = "-1".TryConvert(out i);
				Assert.That(result, Is.True);
				Assert.That(i, Is.EqualTo(-1));

				result = "1".TryConvert(out i);
				Assert.That(result, Is.True);
				Assert.That(i, Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_long_string_to_long
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				long l;
				bool result = "-1".TryConvert(out l);
				Assert.That(result, Is.True);
				Assert.That(l, Is.EqualTo(-1));

				result = "1".TryConvert(out l);
				Assert.That(result, Is.True);
				Assert.That(l, Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_sbyte_string_to_sbyte
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				sbyte sb;
				bool result = "-1".TryConvert(out sb);

				Assert.That(sb, Is.EqualTo((sbyte)-1));
				Assert.That(result, Is.True);

				result = "1".TryConvert(out sb);
				Assert.That(sb, Is.EqualTo((sbyte)1));
				Assert.That(result, Is.True);
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_short_string_to_short
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				short s;
				bool result = "-1".TryConvert(out s);
				Assert.That(result, Is.True);
				Assert.That(s, Is.EqualTo((short)-1));

				result = "1".TryConvert(out s);
				Assert.That(result, Is.True);
				Assert.That(s, Is.EqualTo((short)1));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_uint_string_to_uint
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				uint i;
				bool result = "1".TryConvert(out i);
				Assert.That(result, Is.True);
				Assert.That(i, Is.EqualTo(1u));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_ulong_string_to_ulong
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				ulong l;
				bool result = "1".TryConvert(out l);
				Assert.That(result, Is.True);
				Assert.That(l, Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_ushort_string_to_ushort
		{
			[Test]
			public void Must_convert_to_string_value()
			{
				ushort s;
				bool result = "1".TryConvert(out s);
				Assert.That(result, Is.True);
				Assert.That(s, Is.EqualTo((ushort)1));
			}
		}

		[TestFixture]
		public class When_trying_to_convert_valid_value_to_enum
		{
			[Test]
			public void Must_convert_to_enum()
			{
				TestEnum testEnum;
				bool result = 0.TryConvert(out testEnum);

				Assert.That(result, Is.True);

				result = "Value1".TryConvert(out testEnum);
				Assert.That(result, Is.True);
			}
		}
	}
}