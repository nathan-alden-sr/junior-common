using System;

using Junior.Common.Net40;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Net40
{
	public static class ResettableLazyTester
	{
		[TestFixture]
		public class When_resetting_internal_lazy_instance
		{
			[SetUp]
			public void SetUp()
			{
				_resettableLazy = new ResettableLazy<Lazy<int>, int>(() => new Lazy<int>(() => 0));
			}

			private ResettableLazy<Lazy<int>, int> _resettableLazy;

			[Test]
			public void Must_reset_instance()
			{
				// ReSharper disable once UnusedVariable
				int value = _resettableLazy.Value;

				Assert.That(_resettableLazy.IsValueCreated, Is.True);

				_resettableLazy.Reset();

				Assert.That(_resettableLazy.IsValueCreated, Is.False);
			}
		}
	}
}