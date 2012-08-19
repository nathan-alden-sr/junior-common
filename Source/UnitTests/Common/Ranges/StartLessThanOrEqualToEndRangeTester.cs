using System;

using Junior.Common.Ranges;

namespace Junior.Common.UnitTests.Common.Ranges
{
	public static class StartLessThanOrEqualToEndRangeTester
	{
		[TestFixture]
		public class When_specifying_invalid_range
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => new StartLessThanOrEqualToEndRange<int>(1, 0));
			}
		}

		[TestFixture]
		public class When_specifying_valid_range
		{
			[Test]
			public void Must_not_throw_exception()
			{
				Assert.DoesNotThrow(() => new StartLessThanOrEqualToEndRange<int>(0, 1));
				Assert.DoesNotThrow(() => new StartLessThanOrEqualToEndRange<int>(1, 1));
			}
		}
	}
}