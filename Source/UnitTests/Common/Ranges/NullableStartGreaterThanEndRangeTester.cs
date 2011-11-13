using System;

using Junior.Common.Ranges;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Ranges
{
	public static class NullableStartGreaterThanEndRangeTester
	{
		[TestFixture]
		public class When_specifying_invalid_range
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => new NullableStartGreaterThanEndRange<int>(null, null));
				Assert.Throws<ArgumentException>(() => new NullableStartGreaterThanEndRange<int>(null, 0));
				Assert.Throws<ArgumentException>(() => new NullableStartGreaterThanEndRange<int>(0, 0));
				Assert.Throws<ArgumentException>(() => new NullableStartGreaterThanEndRange<int>(0, 1));
			}
		}

		public class When_specifying_valid_range
		{
			[Test]
			public void Must_not_throw_exception()
			{
				Assert.DoesNotThrow(() => new NullableStartGreaterThanEndRange<int>(1, null));
				Assert.DoesNotThrow(() => new NullableStartGreaterThanEndRange<int>(1, 0));
			}
		}
	}
}