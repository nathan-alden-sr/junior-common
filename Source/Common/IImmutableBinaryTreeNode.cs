using System.Collections.Generic;

namespace JuniorCommon.Common
{
	/// <summary>
	/// Represents an immutable node in a binary tree. <see cref="IImmutableBinaryTreeNode{TBinaryTreeNode,TValue}"/> allows the consumer to specify
	/// the actual node type and the type of value nodes contain.
	/// </summary>
	public interface IImmutableBinaryTreeNode<out TBinaryTreeNode, out TValue>
		where TBinaryTreeNode : class, IImmutableBinaryTreeNode<TBinaryTreeNode, TValue>
	{
		/// <summary>
		/// Gets or sets the current node's value.
		/// </summary>
		TValue Value
		{
			get;
		}
		/// <summary>
		/// Gets or sets the left descendant node of the current node.
		/// </summary>
		TBinaryTreeNode LeftDescendant
		{
			get;
		}
		/// <summary>
		/// Gets or sets the right descendant node of the current node.
		/// </summary>
		TBinaryTreeNode RightDescendant
		{
			get;
		}
		/// <summary>
		/// Gets the root node.
		/// </summary>
		TBinaryTreeNode Root
		{
			get;
		}
		/// <summary>
		/// Gets the ancestor node of the current node.
		/// </summary>
		TBinaryTreeNode Ancestor
		{
			get;
		}
		/// <summary>
		/// Gets all ancestor nodes of the current node.
		/// </summary>
		IEnumerable<TBinaryTreeNode> Ancestors
		{
			get;
		}
		/// <summary>
		/// Gets all ancestor nodes of the current node, including the current node.
		/// </summary>
		IEnumerable<TBinaryTreeNode> CurrentPlusAncestors
		{
			get;
		}
		/// <summary>
		/// Gets all descendant nodes of the current node.
		/// </summary>
		IEnumerable<TBinaryTreeNode> Descendants
		{
			get;
		}
		/// <summary>
		/// Gets all descendant nodes of the current node, including the current node.
		/// </summary>
		IEnumerable<TBinaryTreeNode> CurrentPlusDescendants
		{
			get;
		}
		/// <summary>
		/// Gets the sibling node of the current node.
		/// </summary>
		TBinaryTreeNode Sibling
		{
			get;
		}
		/// <summary>
		/// Gets the sibling node of the current node, including the current node.
		/// </summary>
		IEnumerable<TBinaryTreeNode> CurrentPlusSibling
		{
			get;
		}
		/// <summary>
		/// Gets all leaf nodes from the root.
		/// </summary>
		IEnumerable<TBinaryTreeNode> LeavesFromRoot
		{
			get;
		}
		/// <summary>
		/// Gets all leaf nodes from the current node.
		/// </summary>
		IEnumerable<TBinaryTreeNode> LeavesFromCurrent
		{
			get;
		}
		/// <summary>
		/// Gets the depth of the current node. The root node is always depth 0.
		/// </summary>
		int Depth
		{
			get;
		}
		/// <summary>
		/// Gets the deepest depth for all nodes in the tree.
		/// </summary>
		int Height
		{
			get;
		}
		/// <summary>
		/// Gets a count of descendant nodes from the current node, plus the current node.
		/// </summary>
		int Size
		{
			get;
		}
		/// <summary>
		/// Determines if the current node is the root node. A root node has no ancestor.
		/// </summary>
		bool IsRoot
		{
			get;
		}
		/// <summary>
		/// Determines if the current node is a leaf node. A leaf node has no descendants.
		/// </summary>
		bool IsLeaf
		{
			get;
		}
	}
}