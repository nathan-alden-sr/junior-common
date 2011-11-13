using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JuniorCommon.Common
{
	/// <summary>
	/// Extensions for the <see cref="Type"/> type.
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// Retrieves all public instance properties on the specified type. <see cref="BindingFlags.FlattenHierarchy"/>, <see cref="BindingFlags.Public"/> and <see cref="BindingFlags.Instance"/> are used.
		/// </summary>
		/// <param name="type">A type.</param>
		/// <returns>All public instance properties on the specified type.</returns>
		public static IEnumerable<PropertyInfo> GetAllPublicInstanceProperties(this Type type)
		{
			return type.GetAllProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
		}

		/// <summary>
		/// Retrieves all properties on the specified type, including interface properties if <paramref name="type"/> is an interface type.
		/// </summary>
		/// <param name="type">A type.</param>
		/// <param name="bindingFlags"></param>
		/// <returns>All properties on the specified type.</returns>
		public static IEnumerable<PropertyInfo> GetAllProperties(this Type type, BindingFlags bindingFlags)
		{
			return type.IsInterface
			       	? GetAllInterfaceProperties(type, bindingFlags)
			       	: type.GetProperties(bindingFlags);
		}

		/// <summary>
		/// Determines if <typeparamref name="TConcrete"/> implements <typeparamref name="TInterface"/>.
		/// </summary>
		/// <typeparam name="TConcrete">The concrete implementation type.</typeparam>
		/// <typeparam name="TInterface">The interface type.</typeparam>
		/// <returns>true if <typeparamref name="TConcrete"/> implements <typeparamref name="TInterface"/>; otherwise, false.</returns>
		public static bool ImplementsInterface<TConcrete, TInterface>()
		{
			return ImplementsInterface(typeof(TConcrete), typeof(TInterface));
		}

		/// <summary>
		/// Determines if a concrete type implements <typeparamref name="TInterface"/>.
		/// </summary>
		/// <typeparam name="TInterface">The interface type.</typeparam>
		/// <param name="concreteType">A concrete type.</param>
		/// <returns>true if <paramref name="concreteType"/> implements <typeparamref name="TInterface"/>; otherwise, false.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="concreteType"/> is null.</exception>
		public static bool ImplementsInterface<TInterface>(this Type concreteType)
		{
			concreteType.ThrowIfNull("concreteType");

			return ImplementsInterface(concreteType, typeof(TInterface));
		}

		/// <summary>
		/// Determines if a concrete type implements an interface type.
		/// </summary>
		/// <param name="concreteType">A concrete type.</param>
		/// <param name="interfaceType">An interface type.</param>
		/// <returns>true if <paramref name="concreteType"/> implements <paramref name="interfaceType"/>; otherwise, false.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="concreteType"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="interfaceType"/> is null.</exception>
		public static bool ImplementsInterface(this Type concreteType, Type interfaceType)
		{
			concreteType.ThrowIfNull("concreteType");
			interfaceType.ThrowIfNull("interfaceType");

			if (!interfaceType.IsInterface)
			{
				throw new ArgumentException("Interface type must be an interface.", "interfaceType");
			}
			if (!interfaceType.IsGenericTypeDefinition)
			{
				return interfaceType.IsAssignableFrom(concreteType);
			}

			return concreteType.GetInterfaces().Any(arg => arg.IsGenericType && arg.GetGenericTypeDefinition() == interfaceType);
		}

		/// <summary>
		/// Determines if the <typeparamref name="TDescendant"/> interface extends the <typeparamref name="TAncestor"/> interface.
		/// </summary>
		/// <typeparam name="TDescendant">An interface type.</typeparam>
		/// <typeparam name="TAncestor">An interface type.</typeparam>
		/// <returns>true if the <typeparamref name="TDescendant"/> interface extends the <typeparamref name="TAncestor"/> interface; otherwise, false.</returns>
		public static bool ExtendsInterface<TDescendant, TAncestor>()
		{
			return ExtendsInterface(typeof(TAncestor), typeof(TDescendant));
		}

		/// <summary>
		/// Determines if the an interface type extends the <typeparamref name="TAncestor"/> interface.
		/// </summary>
		/// <typeparam name="TAncestor">An interface type.</typeparam>
		/// <param name="descendantType">An interface type.</param>
		/// <returns>true if the <paramref name="descendantType"/> interface extends the <typeparamref name="TAncestor"/> interface; otherwise, false.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="descendantType"/> is null.</exception>
		public static bool ExtendsInterface<TAncestor>(this Type descendantType)
		{
			descendantType.ThrowIfNull("descendantType");

			return ExtendsInterface(typeof(TAncestor), descendantType);
		}

		/// <summary>
		/// Determines if the an interface type extends another interface.
		/// </summary>
		/// <param name="descendantType">An interface type.</param>
		/// <param name="ancestorType">An interface type.</param>
		/// <returns>true if the <paramref name="descendantType"/> interface extends the <paramref name="ancestorType"/> interface; otherwise, false.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="descendantType"/> is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="ancestorType"/> is null.</exception>
		public static bool ExtendsInterface(this Type descendantType, Type ancestorType)
		{
			descendantType.ThrowIfNull("descendantType");
			ancestorType.ThrowIfNull("ancestorType");

			if (!ancestorType.IsGenericTypeDefinition)
			{
				return ancestorType.IsAssignableFrom(descendantType);
			}

			return descendantType.GetInterfaces().Any(arg => arg.IsGenericType && arg.GetGenericTypeDefinition() == ancestorType);
		}

		private static IEnumerable<PropertyInfo> GetAllInterfaceProperties(Type type, BindingFlags bindingFlags)
		{
			var propertyInfos = new List<PropertyInfo>();
			var considered = new List<Type>();
			var queue = new Queue<Type>();

			considered.Add(type);
			queue.Enqueue(type);

			while (queue.Count > 0)
			{
				Type subType = queue.Dequeue();

				foreach (Type subInterface in subType.GetInterfaces())
				{
					if (considered.Contains(subInterface))
					{
						continue;
					}

					considered.Add(subInterface);
					queue.Enqueue(subInterface);
				}

				PropertyInfo[] typeProperties = subType.GetProperties(bindingFlags);
				IEnumerable<PropertyInfo> newPropertyInfos = typeProperties.Where(x => !propertyInfos.Contains(x));

				propertyInfos.InsertRange(0, newPropertyInfos);
			}

			return propertyInfos.ToArray();
		}
	}
}