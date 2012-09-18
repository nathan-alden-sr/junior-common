using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common
{
	public static class EnumerableSynchronizerTester
	{
		private static void AssertLists<TItem1, TItem2>(
			EnumerableSynchronizer<TItem1, TItem2> enumerableSynchronizer,
			IEnumerable<TItem1> expectedRemoved,
			IEnumerable<TItem2> expectedAdded,
			IEnumerable<TItem2> expectedCommon)
		{
			Assert.That(enumerableSynchronizer.RemovedElements, Is.EqualTo(expectedRemoved));
			Assert.That(enumerableSynchronizer.AddedElements, Is.EqualTo(expectedAdded));
			Assert.That(enumerableSynchronizer.CommonElements, Is.EqualTo(expectedCommon));
		}

		private static bool Int32StringComparer(int number, string words)
		{
			return number == Convert.ToInt32(words);
		}

		[TestFixture]
		public class When_comparing_enumerables_using_a_custom_comparer
		{
			[Test]
			public void Must_determine_correct_added_items()
			{
				var int32List = new List<int>();
				var stringList = new List<string>(new[] { "5", "7", "9", "11", "13" });

				var enumerableSynchronizer = new EnumerableSynchronizer<int, string>(int32List, stringList, Int32StringComparer);

				AssertLists(enumerableSynchronizer, new List<int>(), stringList, new List<string>());
			}

			[Test]
			public void Must_determine_correct_added_removed_common_items()
			{
				var int32List = new List<int>(new[] { 5, 7, 9, 11, 13, 16, 18 });
				var stringList = new List<string>(new[] { "4", "6", "8", "12", "14", "16", "18" });

				var enumerableSynchronizer = new EnumerableSynchronizer<int, string>(int32List, stringList, Int32StringComparer);

				var expectedRemoved = new List<int>(new[] { 5, 7, 9, 11, 13 });
				var expectedAdded = new List<string>(new[] { "4", "6", "8", "12", "14" });
				var expectedCommon = new List<string>(new[] { "16", "18" });

				AssertLists(enumerableSynchronizer, expectedRemoved, expectedAdded, expectedCommon);
			}

			[Test]
			public void Must_determine_correct_common_items()
			{
				var int32List = new List<int>(new[] { 5, 7, 9, 11, 13 });
				var stringList = new List<string>(new[] { "5", "7", "9", "11", "13" });

				var enumerableSynchronizer = new EnumerableSynchronizer<int, string>(int32List, stringList, Int32StringComparer);

				AssertLists(enumerableSynchronizer, new List<int>(), new List<string>(), stringList);
			}

			[Test]
			public void Must_determine_correct_removed_items()
			{
				var int32List = new List<int>(new[] { 5, 7, 9, 11, 13 });
				var stringList = new List<string>();

				var enumerableSynchronizer = new EnumerableSynchronizer<int, string>(int32List, stringList, Int32StringComparer);

				AssertLists(enumerableSynchronizer, int32List, new List<string>(), new List<string>());
			}

			[Test]
			public void Must_determine_enumerable_contains_same_items_correctly()
			{
				var int32List = new List<int>(new[] { 3, 2, 1 });
				var stringList = new List<string>(new[] { "3", "2", "1" });

				var enumerableSynchronizer = new EnumerableSynchronizer<int, string>(int32List, stringList, Int32StringComparer);

				Assert.That(enumerableSynchronizer.EnumerablesContainSameElements, Is.True);

				stringList.Sort();

				enumerableSynchronizer = new EnumerableSynchronizer<int, string>(int32List, stringList, Int32StringComparer);
				Assert.That(enumerableSynchronizer.EnumerablesContainSameElements, Is.True);

				int32List.Add(4);

				enumerableSynchronizer = new EnumerableSynchronizer<int, string>(int32List, stringList, Int32StringComparer);
				Assert.That(enumerableSynchronizer.EnumerablesContainSameElements, Is.False);
			}
		}

		[TestFixture]
		public class When_comparing_enumerables_using_default_comparer
		{
			[Test]
			public void Must_determine_correct_added_items()
			{
				var int32List1 = new List<int>();
				var int32List2 = new List<int>(new[] { 5, 7, 9, 11, 13 });

				var enumerableSynchronizer = new EnumerableSynchronizer<int>(int32List1, int32List2);

				AssertLists(enumerableSynchronizer, new List<int>(), int32List2, new List<int>());
			}

			[Test]
			public void Must_determine_correct_added_removed_common_items()
			{
				var int32List1 = new List<int>(new[] { 5, 7, 9, 11, 13, 16, 18 });
				var int32List2 = new List<int>(new[] { 4, 6, 8, 12, 14, 16, 18 });

				var enumerableSynchronizer = new EnumerableSynchronizer<int>(int32List1, int32List2);

				var expectedRemoved = new List<int>(new[] { 5, 7, 9, 11, 13 });
				var expectedAdded = new List<int>(new[] { 4, 6, 8, 12, 14 });
				var expectedCommon = new List<int>(new[] { 16, 18 });

				AssertLists(enumerableSynchronizer, expectedRemoved, expectedAdded, expectedCommon);
			}

			[Test]
			public void Must_determine_correct_common_items()
			{
				var int32List1 = new List<int>(new[] { 5, 7, 9, 11, 13 });
				var int32List2 = new List<int>(new[] { 5, 7, 9, 11, 13 });

				var enumerableSynchronizer = new EnumerableSynchronizer<int>(int32List1, int32List2);

				AssertLists(enumerableSynchronizer, new List<int>(), new List<int>(), int32List2);
			}

			[Test]
			public void Must_determine_correct_removed_items()
			{
				var int32List1 = new List<int>(new[] { 5, 7, 9, 11, 13 });
				var int32List2 = new List<int>();

				var enumerableSynchronizer = new EnumerableSynchronizer<int>(int32List1, int32List2);

				AssertLists(enumerableSynchronizer, int32List1, new List<int>(), new List<int>());
			}
		}

		[TestFixture]
		public class When_synchronizing
		{
			[Test]
			public void Must_call_delegates()
			{
				var initialState = new List<int>(new[] { 1, 2, 3 });
				var desiredState = new List<int>(new[] { 3, 4, 5 });
				var removedItems = new List<int>();
				var addedItems = new List<int>();
				var commonItems = new List<int>();

				var enumerableSynchronizer = new EnumerableSynchronizer<int>(initialState, desiredState);

				enumerableSynchronizer.Synchronize(addedItems.Add, removedItems.Add, commonItems.Add);

				Assert.That(removedItems, Is.EqualTo(new List<int>(new[] { 1, 2 })));
				Assert.That(addedItems, Is.EqualTo(new List<int>(new[] { 4, 5 })));
				Assert.That(commonItems, Is.EqualTo(new List<int>(new[] { 3 })));
			}
		}
	}
}