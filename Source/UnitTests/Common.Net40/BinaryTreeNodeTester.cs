using Junior.Common.Net40;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Net40
{
	public static class BinaryTreeNodeTester
	{
		[TestFixture]
		public class When_attaching_a_left_descendant
		{
			[Test]
			public void Must_set_descendants_ancestor_to_ancestor()
			{
				var root = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.LeftDescendant = systemUnderTest;

				Assert.That(systemUnderTest.Ancestor, Is.SameAs(root));
			}
		}

		[TestFixture]
		public class When_attaching_a_right_descendant
		{
			[Test]
			public void Must_set_descendants_ancestor_to_ancestor()
			{
				var root = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.RightDescendant = systemUnderTest;

				Assert.That(systemUnderTest.Ancestor, Is.SameAs(root));
			}
		}

		[TestFixture]
		public class When_constructing_new_node
		{
			[Test]
			public void Must_construct_root_node()
			{
				var systemUnderTest = new BinaryTreeNode();

				Assert.That(systemUnderTest.Ancestor, Is.Null);
				Assert.That(systemUnderTest.IsRoot, Is.True);
			}

			[Test]
			public void Must_have_no_descendants()
			{
				var systemUnderTest = new BinaryTreeNode();

				Assert.That(systemUnderTest.LeftDescendant, Is.Null);
				Assert.That(systemUnderTest.RightDescendant, Is.Null);
			}

			[Test]
			public void Must_have_zero_depth()
			{
				var systemUnderTest = new BinaryTreeNode();

				Assert.That(systemUnderTest.Depth, Is.EqualTo(0));
			}
		}

		[TestFixture]
		public class When_detaching_a_descendant
		{
			[Test]
			public void Must_set_descendants_ancestor_to_null()
			{
				var root = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.LeftDescendant = systemUnderTest;
				root.LeftDescendant = null;

				Assert.That(systemUnderTest.Ancestor, Is.Null);
			}
		}

		[TestFixture]
		public class When_detaching_a_right_node
		{
			[Test]
			public void Must_set_descendants_ancestor_to_null()
			{
				var root = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.RightDescendant = systemUnderTest;
				root.RightDescendant = null;

				Assert.That(systemUnderTest.Ancestor, Is.Null);
			}
		}

		[TestFixture]
		public class When_replacing_a_left_descendant
		{
			[Test]
			public void Must_set_descendants_ancestor_to_ancestor()
			{
				var root = new BinaryTreeNode();
				var descendant = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.LeftDescendant = descendant;
				root.LeftDescendant = systemUnderTest;

				Assert.That(systemUnderTest.Ancestor, Is.SameAs(root));
			}

			[Test]
			public void Must_set_descendants_ancestor_to_null()
			{
				var root = new BinaryTreeNode();
				var descendant = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.LeftDescendant = descendant;
				root.LeftDescendant = systemUnderTest;

				Assert.That(descendant.Ancestor, Is.Null);
			}
		}

		[TestFixture]
		public class When_replacing_a_right_descendant
		{
			[Test]
			public void Must_set_descendants_ancestor_to_ancestor()
			{
				var root = new BinaryTreeNode();
				var descendant = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.RightDescendant = descendant;
				root.RightDescendant = systemUnderTest;

				Assert.That(systemUnderTest.Ancestor, Is.SameAs(root));
			}

			[Test]
			public void Must_set_replaced_nodes_ancestor_to_null()
			{
				var root = new BinaryTreeNode();
				var descendant = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.RightDescendant = descendant;
				root.RightDescendant = systemUnderTest;

				Assert.That(descendant.Ancestor, Is.Null);
			}
		}

		[TestFixture]
		public class When_retrieving_ancestors
		{
			[Test]
			public void Must_retrieve_correct_ancestors()
			{
				var root = new BinaryTreeNode();
				var descendant = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.LeftDescendant = descendant;
				descendant.RightDescendant = systemUnderTest;

				Assert.That(systemUnderTest.Ancestors, Is.EquivalentTo(new[] { descendant, root }));
			}
		}

		[TestFixture]
		public class When_retrieving_current_plus_ancestors
		{
			[Test]
			public void Must_retrieve_correct_ancestors()
			{
				var root = new BinaryTreeNode();
				var descendant = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.LeftDescendant = descendant;
				descendant.RightDescendant = systemUnderTest;

				Assert.That(systemUnderTest.CurrentPlusAncestors, Is.EquivalentTo(new[] { systemUnderTest, descendant, root }));
			}
		}

		[TestFixture]
		public class When_retrieving_current_plus_descendants
		{
			[Test]
			public void Must_retrieve_correct_descendants()
			{
				var systemUnderTest = new BinaryTreeNode();
				var descendant1 = new BinaryTreeNode();
				var descendant2 = new BinaryTreeNode();

				systemUnderTest.LeftDescendant = descendant1;
				descendant1.RightDescendant = descendant2;

				Assert.That(systemUnderTest.CurrentPlusDescendants, Is.EquivalentTo(new[] { systemUnderTest, descendant1, descendant2 }));
			}
		}

		[TestFixture]
		public class When_retrieving_depth
		{
			[Test]
			public void Must_retrieve_correct_depth()
			{
				var root = new BinaryTreeNode();
				var descendantDepth1 = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();

				root.LeftDescendant = descendantDepth1;
				descendantDepth1.RightDescendant = systemUnderTest;

				Assert.That(systemUnderTest.Depth, Is.EqualTo(2));
			}
		}

		[TestFixture]
		public class When_retrieving_descendants
		{
			[Test]
			public void Must_retrieve_correct_descendants()
			{
				var systemUnderTest = new BinaryTreeNode();
				var descendant1 = new BinaryTreeNode();
				var descendant2 = new BinaryTreeNode();

				systemUnderTest.LeftDescendant = descendant1;
				descendant1.RightDescendant = descendant2;

				Assert.That(systemUnderTest.Descendants, Is.EquivalentTo(new[] { descendant1, descendant2 }));
			}
		}

		[TestFixture]
		public class When_retrieving_height
		{
			[Test]
			public void Must_retrieve_correct_height()
			{
				var systemUnderTest = new BinaryTreeNode();
				var descendant1 = new BinaryTreeNode();
				var descendant2 = new BinaryTreeNode();
				var descendant3 = new BinaryTreeNode();
				var descendant4 = new BinaryTreeNode();
				var descendant5 = new BinaryTreeNode();
				var descendant6 = new BinaryTreeNode();

				systemUnderTest.LeftDescendant = descendant1;
				systemUnderTest.LeftDescendant.LeftDescendant = descendant2;
				systemUnderTest.RightDescendant = descendant3;
				systemUnderTest.RightDescendant.RightDescendant = descendant4;
				systemUnderTest.RightDescendant.RightDescendant.LeftDescendant = descendant5;
				systemUnderTest.RightDescendant.RightDescendant.RightDescendant = descendant6;

				Assert.That(systemUnderTest.Height, Is.EqualTo(3));
			}
		}

		[TestFixture]
		public class When_retrieving_leaves_from_current
		{
			[Test]
			public void Must_retrieve_correct_leaves()
			{
				var root = new BinaryTreeNode();
				var systemUnderTest = new BinaryTreeNode();
				var descendant2 = new BinaryTreeNode();
				var descendant3 = new BinaryTreeNode();
				var descendant4 = new BinaryTreeNode();
				var descendant5 = new BinaryTreeNode();
				var descendant6 = new BinaryTreeNode();

				root.LeftDescendant = systemUnderTest;
				root.LeftDescendant.LeftDescendant = descendant2;
				root.LeftDescendant.RightDescendant = descendant3;
				root.RightDescendant = descendant4;
				root.RightDescendant.RightDescendant = descendant5;
				root.RightDescendant.RightDescendant.LeftDescendant = descendant6;

				Assert.That(systemUnderTest.LeavesFromCurrent, Is.EquivalentTo(new[] { descendant2, descendant3 }));
			}
		}

		[TestFixture]
		public class When_retrieving_leaves_from_root
		{
			[Test]
			public void Must_retrieve_correct_leaves()
			{
				var systemUnderTest = new BinaryTreeNode();
				var descendant1 = new BinaryTreeNode();
				var descendant2 = new BinaryTreeNode();
				var descendant3 = new BinaryTreeNode();
				var descendant4 = new BinaryTreeNode();
				var descendant5 = new BinaryTreeNode();
				var descendant6 = new BinaryTreeNode();

				systemUnderTest.LeftDescendant = descendant1;
				systemUnderTest.LeftDescendant.LeftDescendant = descendant2;
				systemUnderTest.LeftDescendant.RightDescendant = descendant3;
				systemUnderTest.RightDescendant = descendant4;
				systemUnderTest.RightDescendant.RightDescendant = descendant5;
				systemUnderTest.RightDescendant.RightDescendant.LeftDescendant = descendant6;

				Assert.That(systemUnderTest.LeavesFromRoot, Is.EquivalentTo(new[] { descendant2, descendant3, descendant6 }));
			}
		}

		[TestFixture]
		public class When_retrieving_sibling
		{
			[Test]
			public void Must_retrieve_sibling()
			{
				var root = new BinaryTreeNode();
				var descendant1 = new BinaryTreeNode();
				var descendant2 = new BinaryTreeNode();

				root.LeftDescendant = descendant1;
				root.RightDescendant = descendant2;

				Assert.That(descendant1.Sibling, Is.SameAs(descendant2));
				Assert.That(descendant2.Sibling, Is.SameAs(descendant1));
			}
		}

		[TestFixture]
		public class When_retrieving_siblings
		{
			[Test]
			public void Must_retrieve_siblings()
			{
				var root = new BinaryTreeNode();
				var descendant1 = new BinaryTreeNode();
				var descendant2 = new BinaryTreeNode();

				root.LeftDescendant = descendant1;
				root.RightDescendant = descendant2;

				Assert.That(descendant1.CurrentPlusSibling, Is.EquivalentTo(new[] { descendant1, descendant2 }));
				Assert.That(descendant2.CurrentPlusSibling, Is.EquivalentTo(new[] { descendant2, descendant1 }));
			}
		}

		[TestFixture]
		public class When_retrieving_size
		{
			[Test]
			public void Must_retrieve_count_of_current_plus_descendants()
			{
				var systemUnderTest = new BinaryTreeNode();
				var descendant1 = new BinaryTreeNode();
				var descendant2 = new BinaryTreeNode();
				var descendant3 = new BinaryTreeNode();
				var descendant4 = new BinaryTreeNode();
				var descendant5 = new BinaryTreeNode();
				var descendant6 = new BinaryTreeNode();

				systemUnderTest.LeftDescendant = descendant1;
				systemUnderTest.LeftDescendant.LeftDescendant = descendant2;
				systemUnderTest.RightDescendant = descendant3;
				systemUnderTest.RightDescendant.RightDescendant = descendant4;
				systemUnderTest.RightDescendant.RightDescendant.LeftDescendant = descendant5;
				systemUnderTest.RightDescendant.RightDescendant.RightDescendant = descendant6;

				Assert.That(systemUnderTest.Size, Is.EqualTo(7));
			}
		}
	}
}