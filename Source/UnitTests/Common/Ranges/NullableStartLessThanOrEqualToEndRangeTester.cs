using System;

using Junior.Common.Ranges;

namespace Junior.Common.UnitTests.Common.Ranges
{
	public static class NullableStartLessThanOrEqualToEndRangeTester
	{
		[TestFixture]
		public class When_specifying_invalid_range
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => new NullableStartLessThanOrEqualToEndRange<int>(1, null));
				Assert.Throws<ArgumentException>(() => new NullableStartLessThanOrEqualToEndRange<int>(1, 0));
			}
		}

		[TestFixture]
		public class When_specifying_valid_range
		{
			[Test]
			public void Must_not_throw_exception()
			{
				Assert.DoesNotThrow(() => new NullableStartLessThanOrEqualToEndRange<int>(null, null));
				Assert.DoesNotThrow(() => new NullableStartLessThanOrEqualToEndRange<int>(null, 1));
				Assert.DoesNotThrow(() => new NullableStartLessThanOrEqualToEndRange<int>(0, 1));
				Assert.DoesNotThrow(() => new NullableStartLessThanOrEqualToEndRange<int>(1, 1));
			}
		}
	}
}