using System;

using Junior.Common.Ranges;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Ranges
{
	public static class StartLessThanEndRangeTester
	{
		[TestFixture]
		public class When_specifying_invalid_range
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => new StartLessThanEndRange<int>(0, 0));
				Assert.Throws<ArgumentException>(() => new StartLessThanEndRange<int>(1, 0));
			}
		}

		[TestFixture]
		public class When_specifying_valid_range
		{
			[Test]
			public void Must_not_throw_exception()
			{
				Assert.DoesNotThrow(() => new StartLessThanEndRange<int>(0, 1));
			}
		}
	}
}