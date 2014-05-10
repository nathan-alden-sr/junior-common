using Junior.Common.Net35;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Net35
{
	public static class FloatToIntTester
	{
		[TestFixture]
		public class When_comparing_floating_point_values_whose_integer_representations_are_equal
		{
			[Test]
			public void Must_be_equal()
			{
				var value1 = new FloatToInt(0f);
				var value2 = new FloatToInt(0f * 1f);

				Assert.That(value1 == value2, Is.True);

				value1 = new FloatToInt(3f * 4f);
				value2 = new FloatToInt(2f * 6f);

				Assert.That(value1 == value2, Is.True);
			}
		}

		[TestFixture]
		public class When_comparing_floating_point_values_whose_integer_representations_are_not_equal
		{
			[Test]
			public void Must_not_be_equal()
			{
				var value1 = new FloatToInt(0f);
				var value2 = new FloatToInt((0f * 1f) + 0.00001f);

				Assert.That(value1 == value2, Is.False);

				value1 = new FloatToInt(3f * 4f);
				value2 = new FloatToInt((2f * 6f) + 0.00001f);

				Assert.That(value1 == value2, Is.False);
			}
		}
	}
}