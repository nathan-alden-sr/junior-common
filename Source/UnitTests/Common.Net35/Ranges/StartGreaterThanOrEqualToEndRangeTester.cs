﻿using System;

using Junior.Common.Net35.Ranges;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Net35.Ranges
{
	public static class StartGreaterThanOrEqualToEndRangeTester
	{
		[TestFixture]
		public class When_specifying_invalid_range
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => new StartGreaterThanOrEqualToEndRange<int>(0, 1));
			}
		}

		[TestFixture]
		public class When_specifying_valid_range
		{
			[Test]
			public void Must_not_throw_exception()
			{
				Assert.DoesNotThrow(() => new StartGreaterThanOrEqualToEndRange<int>(1, 0));
				Assert.DoesNotThrow(() => new StartGreaterThanOrEqualToEndRange<int>(0, 0));
			}
		}
	}
}