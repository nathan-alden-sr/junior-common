using Junior.Common.Net35;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Net35
{
	public static class DoubleToLongTester
	{
		[TestFixture]
		public class When_comparing_floating_point_values_whose_integer_representations_are_equal
		{
			[Test]
			public void Must_be_equal()
			{
				var value1 = new DoubleToLong(0.0);
				var value2 = new DoubleToLong(0.0 * 1.0);

				Assert.That(value1 == value2, Is.True);

				value1 = new DoubleToLong(3.0 * 4.0);
				value2 = new DoubleToLong(2.0 * 6.0);

				Assert.That(value1 == value2, Is.True);
			}
		}

		[TestFixture]
		public class When_comparing_floating_point_values_whose_integer_representations_are_not_equal
		{
			[Test]
			public void Must_not_be_equal()
			{
				var value1 = new DoubleToLong(0.0);
				var value2 = new DoubleToLong((0.0 * 1.0) + 0.00001);

				Assert.That(value1 == value2, Is.False);

				value1 = new DoubleToLong(3.0 * 4.0);
				value2 = new DoubleToLong((2.0 * 6.0) + 0.00001);

				Assert.That(value1 == value2, Is.False);
			}
		}
	}
}