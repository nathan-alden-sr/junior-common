namespace Junior.Common.UnitTests.Common
{
	public static class Md5StringTester
	{
		[TestFixture]
		public class When_constructing_Md5String_with_hyphenated_MD5_string_and_HyphenatedHexCharacters_format
		{
			[Test]
			public void Must_create_instance_successfully()
			{
				Assert.DoesNotThrow(() => Md5String.FromMd5("01-23-45-67-89-ab-cd-ef-01-23-45-67-89-AB-CD-EF", Md5StringFormat.HyphenatedHexCharacters));
			}
		}

		[TestFixture]
		public class When_constructing_Md5String_with_hyphenated_MD5_string_and_OptionallyHyphenatedHexCharacters_format
		{
			[Test]
			public void Must_create_instance_successfully()
			{
				Assert.DoesNotThrow(() => Md5String.FromMd5("01-23-45-67-89-ab-cd-ef-01-23-45-67-89-AB-CD-EF", Md5StringFormat.OptionallyHyphenatedHexCharacters));
			}
		}

		[TestFixture]
		public class When_constructing_Md5String_with_non_hyphenated_MD5_string_and_NonHyphenatedHexCharacters_format
		{
			[Test]
			public void Must_create_instance_successfully()
			{
				Assert.DoesNotThrow(() => Md5String.FromMd5("0123456789abcdef0123456789ABCDEF", Md5StringFormat.NonHyphenatedHexCharacters));
			}
		}

		[TestFixture]
		public class When_constructing_Md5String_with_nonhyphenated_MD5_string_and_OptionallyHyphenatedHexCharacters_format
		{
			[Test]
			public void Must_create_instance_successfully()
			{
				Assert.DoesNotThrow(() => Md5String.FromMd5("0123456789abcdef0123456789ABCDEF", Md5StringFormat.OptionallyHyphenatedHexCharacters));
			}
		}

		[TestFixture]
		public class When_testing_if_valid_MD5_string_is_MD5_string
		{
			[Test]
			public void Must_be_valid()
			{
				Assert.That(Md5String.IsMd5String("0123456789abcdef0123456789ABCDEF"), Is.True);
				Assert.That(Md5String.IsMd5String("01-23-45-67-89-ab-cd-ef-01-23-45-67-89-AB-CD-EF"), Is.True);
			}
		}
	}
}