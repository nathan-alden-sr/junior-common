using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Junior.Common
{
	/// <summary>
	/// A node in a binary tree. <see cref="BinaryTreeNode{TBinaryTreeNode,TValue}"/> allows the consumer to specify the actual node type and
	/// the type of value nodes contain. To retrieve an immutable binary tree, reference an instance as
	/// <see cref="IImmutableBinaryTreeNode{TBinaryTreeNode,TValue}"/>.
	/// </summary>
	[DebuggerStepThrough]
	public class BinaryTreeNode<TBinaryTreeNode, TValue> : IImmutableBinaryTreeNode<TBinaryTreeNode, TValue>
		where TBinaryTreeNode : BinaryTreeNode<TBinaryTreeNode, TValue>
	{
		private TBinaryTreeNode _leftDescendant;
		private TBinaryTreeNode _rightDescendant;

		/// <summary>
		/// Gets or sets the current node's value.
		/// </summary>
		public TValue Value
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the left descendant node of the current node.
		/// </summary>
		public TBinaryTreeNode LeftDescendant
		{
			get
			{
				return _leftDescendant;
			}
			set
			{
				if (_leftDescendant != null)
				{
					_leftDescendant.Ancestor = null;
				}
				if (value != null)
				{
					value.Ancestor = (TBinaryTreeNode)this;
				}
				_leftDescendant = value;
			}
		}

		/// <summary>
		/// Gets or sets the right descendant node of the current node.
		/// </summary>
		public TBinaryTreeNode RightDescendant
		{
			get
			{
				return _rightDescendant;
			}
			set
			{
				if (_rightDescendant != null)
				{
					_rightDescendant.Ancestor = null;
				}
				if (value != null)
				{
					value.Ancestor = (TBinaryTreeNode)this;
				}
				_rightDescendant = value;
			}
		}

		/// <summary>
		/// Gets the root node.
		/// </summary>
		public TBinaryTreeNode Root
		{
			get
			{
				return !IsRoot ? Ancestor.Root : (TBinaryTreeNode)this;
			}
		}

		/// <summary>
		/// Gets the ancestor node of the current node.
		/// </summary>
		public TBinaryTreeNode Ancestor
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets all ancestor nodes of the current node.
		/// </summary>
		public IEnumerable<TBinaryTreeNode> Ancestors
		{
			get
			{
				TBinaryTreeNode node = Ancestor;

				while (node != null)
				{
					yield return node;

					node = node.Ancestor;
				}
			}
		}

		/// <summary>
		/// Gets all ancestor nodes of the current node, including the current node.
		/// </summary>
		public IEnumerable<TBinaryTreeNode> CurrentPlusAncestors
		{
			get
			{
				var nodes = new List<TBinaryTreeNode>
				            {
					            (TBinaryTreeNode)this
				            };

				nodes.AddRange(Ancestors);

				return nodes;
			}
		}

		/// <summary>
		/// Gets all descendant nodes of the current node.
		/// </summary>
		public IEnumerable<TBinaryTreeNode> Descendants
		{
			get
			{
				var nodes = new List<TBinaryTreeNode>();

				if (_leftDescendant != null)
				{
					nodes.Add(_leftDescendant);
					nodes.AddRange(_leftDescendant.Descendants);
				}
				if (_rightDescendant != null)
				{
					nodes.Add(_rightDescendant);
					nodes.AddRange(_rightDescendant.Descendants);
				}

				return nodes;
			}
		}

		/// <summary>
		/// Gets all descendant nodes of the current node, including the current node.
		/// </summary>
		public IEnumerable<TBinaryTreeNode> CurrentPlusDescendants
		{
			get
			{
				var nodes = new List<TBinaryTreeNode>
				            {
					            (TBinaryTreeNode)this
				            };

				nodes.AddRange(Descendants);

				return nodes;
			}
		}

		/// <summary>
		/// Gets the sibling node of the current node.
		/// </summary>
		public TBinaryTreeNode Sibling
		{
			get
			{
				return Ancestor.IfNotNull(arg => arg.LeftDescendant == this ? arg.RightDescendant : arg.LeftDescendant);
			}
		}

		/// <summary>
		/// Gets the sibling node of the current node, including the current node.
		/// </summary>
		public IEnumerable<TBinaryTreeNode> CurrentPlusSibling
		{
			get
			{
				yield return (TBinaryTreeNode)this;

				TBinaryTreeNode node = Sibling;

				if (node != null)
				{
					yield return node;
				}
			}
		}

		/// <summary>
		/// Gets all leaf nodes from the root.
		/// </summary>
		public IEnumerable<TBinaryTreeNode> LeavesFromRoot
		{
			get
			{
				return Root.LeavesFromCurrent;
			}
		}

		/// <summary>
		/// Gets all leaf nodes from the current node.
		/// </summary>
		public IEnumerable<TBinaryTreeNode> LeavesFromCurrent
		{
			get
			{
				var nodes = new List<TBinaryTreeNode>();

				if (_leftDescendant != null)
				{
					nodes.AddRange(_leftDescendant.LeavesFromCurrent);
				}
				if (_rightDescendant != null)
				{
					nodes.AddRange(_rightDescendant.LeavesFromCurrent);
				}
				if (IsLeaf)
				{
					nodes.Add((TBinaryTreeNode)this);
				}

				return nodes;
			}
		}

		/// <summary>
		/// Gets the depth of the current node. The root node is always depth 0.
		/// </summary>
		public int Depth
		{
			get
			{
				int depth = 0;
				TBinaryTreeNode node = Ancestor;

				while (node != null)
				{
					depth++;
					node = node.Ancestor;
				}

				return depth;
			}
		}

		/// <summary>
		/// Gets the deepest depth for all nodes in the tree.
		/// </summary>
		public int Height
		{
			get
			{
				return Root.CurrentPlusDescendants.MaxBy(node => node.Depth).Depth;
			}
		}

		/// <summary>
		/// Gets a count of descendant nodes from the current node, plus the current node.
		/// </summary>
		public int Size
		{
			get
			{
				return CurrentPlusDescendants.Count();
			}
		}

		/// <summary>
		/// Determines if the current node is the root node. A root node has no ancestor.
		/// </summary>
		public bool IsRoot
		{
			get
			{
				return Ancestor == null;
			}
		}

		/// <summary>
		/// Determines if the current node is a leaf node. A leaf node has no descendants.
		/// </summary>
		public bool IsLeaf
		{
			get
			{
				return _leftDescendant == null && _rightDescendant == null;
			}
		}
	}

	/// <summary>
	/// A binary tree whose value type is <see cref="object"/>.
	/// </summary>
	public class BinaryTreeNode : BinaryTreeNode<BinaryTreeNode, object>
	{
	}
}