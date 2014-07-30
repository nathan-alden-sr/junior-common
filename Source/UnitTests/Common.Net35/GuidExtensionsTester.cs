using System;

using Junior.Common.Net35;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Net35
{
	public static class GuidExtensionsTester
	{
		[TestFixture]
		public class When_calling_EnsureNotNull_on_non_null_parameter
		{
			[Test]
			public void Must_return_value()
			{
				Guid value = Guid.Parse("306fb37d-ff3c-47ef-8eca-f47f4dfcb3f5");

				Assert.That(value.EnsureNotEmpty("value"), Is.EqualTo(value));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNull_on_null_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				Assert.Throws<ArgumentException>(() => Guid.Empty.EnsureNotEmpty("value"));
			}
		}
	}
}