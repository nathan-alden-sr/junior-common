using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Junior.Common
{
	/// <summary>
	/// Determines which elements in an initial enumerable have been removed, added or are common in a desired enumerable.
	/// <see cref="EnumerableSynchronizer{T}"/> forces elements have the same type.
	/// </summary>
	public class EnumerableSynchronizer<T> : EnumerableSynchronizer<T, T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EnumerableSynchronizer{T}"/> class.
		/// </summary>
		/// <param name="initialState">The initial enumerable.</param>
		/// <param name="desiredState">The desired enumerable.</param>
		public EnumerableSynchronizer(IEnumerable<T> initialState, IEnumerable<T> desiredState)
			: base(initialState, desiredState)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EnumerableSynchronizer{T}"/> class.
		/// </summary>
		/// <param name="initialState">The initial enumerable.</param>
		/// <param name="desiredState">The desired enumerable.</param>
		/// <param name="equalityDelegate">A delegate used to determine the equality of an initial state element and a desired state element.</param>
		public EnumerableSynchronizer(IEnumerable<T> initialState, IEnumerable<T> desiredState, Func<T, T, bool> equalityDelegate)
			: base(initialState, desiredState, equalityDelegate)
		{
		}
	}

	/// <summary>
	/// Determines which elements in an initial enumerable have been removed, added or are common in a desired enumerable.
	/// </summary>
	public class EnumerableSynchronizer<TItem1, TItem2>
	{
		private readonly List<TItem2> _addedElements;
		private readonly List<TItem2> _commonElements;
		private readonly List<TItem1> _removedElements;

		/// <summary>
		/// Initializes a new instance of the <see cref="EnumerableSynchronizer{TItem1,TItem2}"/> class.
		/// </summary>
		/// <param name="initialState">The initial enumerable.</param>
		/// <param name="desiredState">The desired enumerable.</param>
		public EnumerableSynchronizer(IEnumerable<TItem1> initialState, IEnumerable<TItem2> desiredState)
			: this(initialState, desiredState, DefaultComparer)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EnumerableSynchronizer{TItem1,TItem2}"/> class.
		/// </summary>
		/// <param name="initialState">The initial enumerable.</param>
		/// <param name="desiredState">The desired enumerable.</param>
		/// <param name="equalityDelegate">A delegate used to determine the equality of an initial state element and a desired state element.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="initialState"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="desiredState"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="equalityDelegate"/> is null.</exception>
		public EnumerableSynchronizer(IEnumerable<TItem1> initialState, IEnumerable<TItem2> desiredState, Func<TItem1, TItem2, bool> equalityDelegate)
		{
			initialState.ThrowIfNull("initialState");
			desiredState.ThrowIfNull("desiredState");
			equalityDelegate.ThrowIfNull("equalityDelegate");

			_removedElements = new List<TItem1>();
			_commonElements = new List<TItem2>();
			_addedElements = new List<TItem2>();

			List<TItem1> initialStateList = initialState.ToList();
			List<TItem2> desiredStateList = desiredState.ToList();

			foreach (TItem1 item1 in initialStateList)
			{
				TItem1 tempItem1 = item1;
				bool found = desiredStateList.Any(item2 => equalityDelegate(tempItem1, item2));

				if (!found)
				{
					_removedElements.Add(item1);
				}
			}

			foreach (TItem2 item2 in desiredStateList)
			{
				TItem2 tempItem2 = item2;
				bool found = initialStateList.Any(item1 => equalityDelegate(item1, tempItem2));

				if (found)
				{
					_commonElements.Add(item2);
				}
				else
				{
					_addedElements.Add(item2);
				}
			}
		}

		/// <summary>
		/// Determines if the initial state enumerable and the desired state enumerable contain the same elements.
		/// </summary>
		public bool EnumerablesContainSameElements
		{
			get
			{
				return !RemovedElements.Any() && !AddedElements.Any();
			}
		}

		/// <summary>
		/// Gets the elements removed from the initial state enumerable.
		/// </summary>
		public IEnumerable<TItem1> RemovedElements
		{
			get
			{
				return _removedElements;
			}
		}

		/// <summary>
		/// Gets the elements common to the initial state enumerable and the desired state enumerable.
		/// </summary>
		public IEnumerable<TItem2> CommonElements
		{
			get
			{
				return _commonElements;
			}
		}

		/// <summary>
		/// Gets the elements in the desired state enumerable that do not exist in the initial state enumerable.
		/// </summary>
		public IEnumerable<TItem2> AddedElements
		{
			get
			{
				return _addedElements;
			}
		}

		/// <summary>
		/// Invokes the specified delegates for each type of element.
		/// </summary>
		/// <param name="addedElementDelegate">An <see cref="Action{TItem2}"/> that will be invoked for each added element, or null to not invoke a delegate.</param>
		/// <param name="removedElementDelegate">An <see cref="Action{TItem1}"/> that will be invoked for each removed element, or null to not invoke a delegate.</param>
		/// <param name="commonElementDelegate">An <see cref="Action{TItem2}"/> that will be invoked for each common element, or null to not invoke a delegate.</param>
		public async Task Synchronize(Action<TItem2> addedElementDelegate = null, Action<TItem1> removedElementDelegate = null, Action<TItem2> commonElementDelegate = null)
		{
			await Task.Run(() =>
				{
					if (!EnumerablesContainSameElements)
					{
						if (removedElementDelegate != null)
						{
							foreach (TItem1 removedItem in RemovedElements)
							{
								removedElementDelegate(removedItem);
							}
						}
						if (addedElementDelegate != null)
						{
							foreach (TItem2 addedItem in AddedElements)
							{
								addedElementDelegate(addedItem);
							}
						}
					}
					if (commonElementDelegate == null)
					{
						return;
					}
					foreach (TItem2 commonItem in CommonElements)
					{
						commonElementDelegate(commonItem);
					}
				});
		}

		private static bool DefaultComparer(TItem1 item1, TItem2 item2)
		{
			return item1.Equals(item2);
		}
	}
}