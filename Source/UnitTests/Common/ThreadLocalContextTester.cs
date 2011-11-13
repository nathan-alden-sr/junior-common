using JuniorCommon.Common;

using NUnit.Framework;

namespace JuniorCommon.UnitTests.Common
{
	public static class ThreadLocalContextTester
	{
		private class Context : ThreadLocalContext<Context>
		{
		}

		[TestFixture]
		public class When_all_contexts_have_been_disposed
		{
			[Test]
			public void Current_context_Must_be_null()
			{
				using (new Context())
				using (new Context())
				{
				}

				Assert.That(Context.Current, Is.Null);
			}
		}

		[TestFixture]
		public class When_nesting_instances
		{
			[Test]
			public void Current_context_Must_be_innermost_instance()
			{
				using (var outerContext = new Context())
				{
					using (var innerContext = new Context())
					{
						Assert.That(Context.Current, Is.SameAs(innerContext));
					}
					Assert.That(Context.Current, Is.SameAs(outerContext));
				}
			}
		}
	}
}