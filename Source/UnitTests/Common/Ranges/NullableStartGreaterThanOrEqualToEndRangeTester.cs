using System;

using Junior.Common.Ranges;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Ranges
{
	public static class NullableStartGreaterThanOrEqualToEndRangeTester
	{
		[TestFixture]
		public class When_specifying_invalid_range
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => new NullableStartGreaterThanOrEqualToEndRange<int>(null, 1));
				Assert.Throws<ArgumentException>(() => new NullableStartGreaterThanOrEqualToEndRange<int>(0, 1));
			}
		}

		[TestFixture]
		public class When_specifying_valid_range
		{
			[Test]
			public void Must_not_throw_exception()
			{
				Assert.DoesNotThrow(() => new NullableStartGreaterThanOrEqualToEndRange<int>(null, null));
				Assert.DoesNotThrow(() => new NullableStartGreaterThanOrEqualToEndRange<int>(1, null));
				Assert.DoesNotThrow(() => new NullableStartGreaterThanOrEqualToEndRange<int>(1, 0));
				Assert.DoesNotThrow(() => new NullableStartGreaterThanOrEqualToEndRange<int>(0, 0));
			}
		}
	}
}