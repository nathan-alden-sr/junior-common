using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common
{
	public static class DelegateDictionaryTester
	{
		[TestFixture]
		public class When_clearing_cached_values
		{
			[Test]
			public void Must_clear_all_cached_values_but_not_delegates()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key1", arg => 0 },
					{ "Key2", arg => 1 },
					{ "Key3", arg => 2 }
				};

#pragma warning disable 168
				int value1 = systemUnderTest["Key1"];
				int value3 = systemUnderTest["Key3"];
#pragma warning restore 168

				systemUnderTest.ClearCachedValues();

				Assert.That(systemUnderTest.DelegateCount, Is.EqualTo(3));
				Assert.That(systemUnderTest.CachedValueCount, Is.EqualTo(0));
			}
		}

		[TestFixture]
		public class When_clearing_everything
		{
			[Test]
			public void Must_clear_all_delegates_and_cached_values()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key1", arg => 0 },
					{ "Key2", arg => 1 },
					{ "Key3", arg => 2 }
				};

#pragma warning disable 168
				int value1 = systemUnderTest["Key1"];
				int value3 = systemUnderTest["Key3"];
#pragma warning restore 168

				systemUnderTest.ClearAll();

				Assert.That(systemUnderTest.DelegateCount, Is.EqualTo(0));
				Assert.That(systemUnderTest.CachedValueCount, Is.EqualTo(0));
			}
		}

		[TestFixture]
		public class When_enumerating_dictionary
		{
			[Test]
			public void Must_invoke_uncached_delegates_and_return_all_keyvaluepairs()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key1", arg => 0 },
					{ "Key2", arg => 1 },
					{ "Key3", arg => 2 }
				};

#pragma warning disable 168
				int value1 = systemUnderTest["Key1"];
				int value3 = systemUnderTest["Key3"];
#pragma warning restore 168

				KeyValuePair<string, int>[] pairs = systemUnderTest.ToArray();

				Assert.That(pairs[0].Key, Is.EqualTo("Key1"));
				Assert.That(pairs[0].Value, Is.EqualTo(0));
				Assert.That(pairs[1].Key, Is.EqualTo("Key2"));
				Assert.That(pairs[1].Value, Is.EqualTo(1));
				Assert.That(pairs[2].Key, Is.EqualTo("Key3"));
				Assert.That(pairs[2].Value, Is.EqualTo(2));
			}
		}

		[TestFixture]
		public class When_removing_key
		{
			[Test]
			public void Must_remove_delegate_and_cached_value()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key", arg => 1 }
				};

#pragma warning disable 168
				int value = systemUnderTest["Key"];
#pragma warning restore 168

				systemUnderTest.Remove("Key");

				Assert.That(systemUnderTest.DelegateCount, Is.EqualTo(0));
				Assert.That(systemUnderTest.CachedValueCount, Is.EqualTo(0));
			}
		}

		[TestFixture]
		public class When_retrieving_all_values
		{
			[Test]
			public void Must_invoke_uncached_delegates_and_return_all_values()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key1", arg => 0 },
					{ "Key2", arg => 1 },
					{ "Key3", arg => 2 }
				};

#pragma warning disable 168
				int value1 = systemUnderTest["Key1"];
				int value3 = systemUnderTest["Key3"];
#pragma warning restore 168

				Assert.That(systemUnderTest.AllValues, Is.EquivalentTo(new[] { 0, 1, 2 }));
			}
		}

		[TestFixture]
		public class When_retrieving_cached_values
		{
			[Test]
			public void Must_return_only_previously_cached_values()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key1", arg => 0 },
					{ "Key2", arg => 1 },
					{ "Key3", arg => 2 }
				};

#pragma warning disable 168
				int value1 = systemUnderTest["Key1"];
				int value3 = systemUnderTest["Key3"];
#pragma warning restore 168

				Assert.That(systemUnderTest.CachedValues, Is.EquivalentTo(new[] { 0, 2 }));
			}
		}

		[TestFixture]
		public class When_retrieving_delegate_count
		{
			[Test]
			public void Must_return_count_of_all_items_added()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key1", arg => 0 },
					{ "Key2", arg => 1 },
					{ "Key3", arg => 2 }
				};

				Assert.That(systemUnderTest.DelegateCount, Is.EqualTo(3));
			}
		}

		[TestFixture]
		public class When_retrieving_keys
		{
			[Test]
			public void Must_return_all_keys_added()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key1", arg => 0 },
					{ "Key2", arg => 1 },
					{ "Key3", arg => 2 }
				};

				Assert.That(systemUnderTest.Keys, Is.EquivalentTo(new[] { "Key1", "Key2", "Key3" }));
			}
		}

		[TestFixture]
		public class When_retrieving_value_after_adding_delegate
		{
			[Test]
			public void Must_return_delegate_result()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key", arg => 1 }
				};

				Assert.That(systemUnderTest["Key"], Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_retrieving_value_count
		{
			[Test]
			public void Must_return_count_of_all_items_accessed()
			{
				var systemUnderTest = new DelegateDictionary<string, int>
				{
					{ "Key1", arg => 0 },
					{ "Key2", arg => 1 },
					{ "Key3", arg => 2 }
				};

#pragma warning disable 168
				int value1 = systemUnderTest["Key1"];
				int value3 = systemUnderTest["Key3"];
#pragma warning restore 168

				Assert.That(systemUnderTest.CachedValueCount, Is.EqualTo(2));
			}
		}

		[TestFixture]
		public class When_retrieving_value_multiple_times_while_supplying_a_delegate
		{
			[Test]
			public void Must_call_delegate_only_once()
			{
				const string key = "Key";
				var systemUnderTest = new DelegateDictionary<string, int>();
				int count = 0;
				Func<string, int> @delegate = arg =>
				{
					count++;
					return 1;
				};

#pragma warning disable 168
				int value1 = systemUnderTest[key, @delegate];
				int value2 = systemUnderTest[key, @delegate];
#pragma warning restore 168

				Assert.That(count, Is.EqualTo(1));
			}
		}

		[TestFixture]
		public class When_retrieving_value_while_supplying_a_delegate
		{
			[Test]
			public void Must_return_delegate_result()
			{
				var systemUnderTest = new DelegateDictionary<string, int>();

				Assert.That(systemUnderTest["Key", arg => 1], Is.EqualTo(1));
			}
		}
	}
}