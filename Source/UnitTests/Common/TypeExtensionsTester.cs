using System.Runtime.Serialization;

namespace Junior.Common.UnitTests.Common
{
	public static class TypeExtensionsTester
	{
		private interface IAncestor
		{
		}

		private interface IDescendant : IAncestor
		{
		}

		// ReSharper disable UnusedTypeParameter
		private interface IGenericAncestor<T>
			// ReSharper restore UnusedTypeParameter
		{
		}

		private interface IGenericDescendant : IGenericAncestor<object>
		{
		}

		private interface ITest
		{
		}

		// ReSharper disable UnusedTypeParameter
		private interface ITestGeneric1<T>
			// ReSharper restore UnusedTypeParameter
		{
		}

		// ReSharper disable UnusedTypeParameter
		private interface ITestGeneric2<T>
			// ReSharper restore UnusedTypeParameter
		{
		}

		// ReSharper disable ClassNeverInstantiated.Local
		private class Test1 : ITest
			// ReSharper restore ClassNeverInstantiated.Local
		{
		}

		private class TestGeneric1 : ITestGeneric1<object>
		{
		}

		private class TestGeneric2 : ITestGeneric2<object>
		{
		}

		[TestFixture]
		public class When_determining_if_interface_extends_another_interface_and_interface_does_inherit_interface
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(TypeExtensions.ExtendsInterface<IAncestor, IDescendant>(), Is.True);
			}
		}

		[TestFixture]
		public class When_determining_if_interface_extends_another_interface_and_interface_does_not_inherit_interface
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(TypeExtensions.ExtendsInterface<IAncestor, IFormatter>(), Is.False);
			}
		}

		[TestFixture]
		public class When_determining_if_interface_extends_closed_generic_interface_and_interface_does_extend_closed_generic_interface
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(typeof(IGenericDescendant).ExtendsInterface(typeof(IGenericAncestor<object>)), Is.True);
			}
		}

		[TestFixture]
		public class When_determining_if_interface_extends_closed_generic_interface_and_interface_does_not_extend_closed_generic_interface
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(typeof(IGenericDescendant).ExtendsInterface(typeof(ITestGeneric1<object>)), Is.False);
			}
		}

		[TestFixture]
		public class When_determining_if_interface_extends_open_generic_interface_and_interface_does_extend_open_generic_interface
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(typeof(IGenericDescendant).ExtendsInterface(typeof(IGenericAncestor<>)), Is.True);
			}
		}

		[TestFixture]
		public class When_determining_if_interface_extends_open_generic_interface_and_interface_does_not_extend_open_generic_interface
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(typeof(IGenericDescendant).ExtendsInterface(typeof(ITestGeneric1<>)), Is.False);
			}
		}

		[TestFixture]
		public class When_determining_if_type_implements_closed_generic_interface_and_type_does_implement_closed_generic_interface
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(typeof(TestGeneric1).ImplementsInterface(typeof(ITestGeneric1<object>)), Is.True);
			}
		}

		[TestFixture]
		public class When_determining_if_type_implements_closed_generic_interface_and_type_does_not_implement_closed_generic_interface
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(typeof(TestGeneric2).ImplementsInterface(typeof(ITestGeneric1<object>)), Is.False);
				Assert.That(typeof(object).ImplementsInterface(typeof(ITestGeneric1<object>)), Is.False);
			}
		}

		[TestFixture]
		public class When_determining_if_type_implements_interface_and_type_does_implement_interface
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(TypeExtensions.ImplementsInterface<Test1, ITest>(), Is.True);
			}
		}

		[TestFixture]
		public class When_determining_if_type_implements_interface_and_type_does_not_implement_interface
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(TypeExtensions.ImplementsInterface<object, ITest>(), Is.False);
			}
		}

		[TestFixture]
		public class When_determining_if_type_implements_open_generic_interface_and_type_does_implement_open_generic_interface
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(typeof(TestGeneric1).ImplementsInterface(typeof(ITestGeneric1<>)), Is.True);
			}
		}

		[TestFixture]
		public class When_determining_if_type_implements_open_generic_interface_and_type_does_not_implement_open_generic_interface
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(typeof(TestGeneric2).ImplementsInterface(typeof(ITestGeneric1<>)), Is.False);
				Assert.That(typeof(object).ImplementsInterface(typeof(ITestGeneric1<>)), Is.False);
			}
		}
	}
}