using System;

using Junior.Common.Ranges;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Ranges
{
	public static class NullableStartLessThanEndRangeTester
	{
		[TestFixture]
		public class When_specifying_invalid_range
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => new NullableStartLessThanEndRange<int>(null, null));
				Assert.Throws<ArgumentException>(() => new NullableStartLessThanEndRange<int>(0, null));
				Assert.Throws<ArgumentException>(() => new NullableStartLessThanEndRange<int>(0, 0));
				Assert.Throws<ArgumentException>(() => new NullableStartLessThanEndRange<int>(1, 0));
			}
		}

		[TestFixture]
		public class When_specifying_valid_range
		{
			[Test]
			public void Must_not_throw_exception()
			{
				Assert.DoesNotThrow(() => new NullableStartLessThanEndRange<int>(null, 1));
				Assert.DoesNotThrow(() => new NullableStartLessThanEndRange<int>(0, 1));
			}
		}
	}
}