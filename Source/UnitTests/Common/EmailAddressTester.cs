using NUnit.Framework;

namespace Junior.Common.UnitTests.Common
{
	public static class EmailAddressTester
	{
		[TestFixture]
		public class When_testing_email_address_with_uppercase_letters
		{
			[Test]
			public void Must_not_throw_exception()
			{
				Assert.That(() => new EmailAddress("Foo.Bar@Baz.com"), Throws.Nothing);
			}
		}
	}
}