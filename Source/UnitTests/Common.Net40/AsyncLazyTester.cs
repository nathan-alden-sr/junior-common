using Junior.Common.Net40;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Net40
{
	public static class AsyncLazyTester
	{
		[TestFixture]
		public class When_constructing_instance_with_task_delegate
		{
			[Test]
			public async void Must_initialize_only_once()
			{
				int count = 0;
				var systemUnderTest = new AsyncLazy<int>(() => count++.AsCompletedTask());

#pragma warning disable 168
				int value1 = await systemUnderTest.Value;
				int value2 = await systemUnderTest.Value;
#pragma warning restore 168

				Assert.That(count, Is.EqualTo(1));
			}

			[Test]
			public async void Must_initialize_with_value()
			{
				var systemUnderTest = new AsyncLazy<int>(() => 1.AsCompletedTask());

				Assert.That(await systemUnderTest.Value, Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_constructing_instance_with_value_delegate
		{
			[Test]
			public async void Must_initialize_only_once()
			{
				int count = 0;
				var systemUnderTest = new AsyncLazy<int>(() => count++);

#pragma warning disable 168
				int value1 = await systemUnderTest.Value;
				int value2 = await systemUnderTest.Value;
#pragma warning restore 168

				Assert.That(count, Is.EqualTo(1));
			}

			[Test]
			public async void Must_initialize_with_value()
			{
				var systemUnderTest = new AsyncLazy<int>(() => 1);

				Assert.That(await systemUnderTest.Value, Is.EqualTo(1));
			}
		}
	}
}