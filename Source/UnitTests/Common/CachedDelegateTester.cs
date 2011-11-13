using JuniorCommon.Common;

using NUnit.Framework;

namespace JuniorCommon.UnitTests.Common
{
	public static class CachedDelegateTester
	{
		[TestFixture]
		public class When_invoking_delegate_for_the_first_time
		{
			[Test]
			public void Must_return_delegate_result()
			{
				var systemUnderTest = new CachedDelegate<string, int>();

				Assert.That(systemUnderTest.Invoke("Key", () => 1), Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_invoking_delegate_with_different_key_as_previous_invocation
		{
			[Test]
			public void Must_execute_delegate()
			{
				var systemUnderTest = new CachedDelegate<string, int>();

				systemUnderTest.Invoke("Key1", () => 1);
				Assert.That(systemUnderTest.Invoke("Key2", () => 2), Is.EqualTo(2));
			}
		}

		[TestFixture]
		public class When_invoking_delegate_with_same_key_as_previous_invocation
		{
			[Test]
			public void Must_return_cached_result()
			{
				var systemUnderTest = new CachedDelegate<string, int>();

				systemUnderTest.Invoke("Key", () => 1);

				Assert.That(systemUnderTest.Invoke("Key", () => 2), Is.EqualTo(1));
			}
		}
	}
}