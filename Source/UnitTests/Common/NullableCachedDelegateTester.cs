namespace Junior.Common.UnitTests.Common
{
	public static class NullableCachedDelegateTester
	{
		[TestFixture]
		public class When_invoking_delegate_for_the_first_time
		{
			[Test]
			public void Must_return_delegate_result()
			{
				var systemUnderTest = new NullableCachedDelegate<double, int>();

				Assert.That(systemUnderTest.Invoke(1, () => 1), Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_invoking_delegate_with_different_key_as_previous_invocation
		{
			[Test]
			public void Must_execute_delegate()
			{
				var systemUnderTest = new NullableCachedDelegate<double, int>();

				systemUnderTest.Invoke(1, () => 1);
				Assert.That(systemUnderTest.Invoke(2, () => 2), Is.EqualTo(2));
			}
		}

		[TestFixture]
		public class When_invoking_delegate_with_same_key_as_previous_invocation
		{
			[Test]
			public void Must_return_cached_result()
			{
				var systemUnderTest = new NullableCachedDelegate<double, int>();

				systemUnderTest.Invoke(1, () => 1);

				Assert.That(systemUnderTest.Invoke(1, () => 2), Is.EqualTo(1));
			}
		}
	}
}