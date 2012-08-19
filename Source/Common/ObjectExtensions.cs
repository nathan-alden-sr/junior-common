using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for the <see cref="object"/> type.
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Converts the specified value to <see cref="Nullable{T}"/>.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <returns><paramref name="value"/> as <see cref="Nullable{T}"/> if the conversion succeeded; otherwise, null.</returns>
		[DebuggerNonUserCode]
		public static T? Convert<T>(this object value)
			where T : struct
		{
			try
			{
				if (value == null)
				{
					return null;
				}

				Type convertType = typeof(T);

				if (convertType.IsEnum)
				{
					Type valueType = value.GetType();

					if (valueType.IsPrimitive && valueType != typeof(char))
					{
						return Enum.IsDefined(convertType, value) ? (T)value : (T?)null;
					}

					var valueAsString = value as string;

					return valueAsString != null ? valueAsString.ToEnum<T>() : null;
				}

				return (T?)System.Convert.ChangeType(value, convertType);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Converts the specified value to <see cref="Nullable{T}"/>.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="defaultValue">The value to return if conversion fails.</param>
		/// <returns><paramref name="value"/> as <see cref="Nullable{T}"/> if the conversion succeeded; otherwise, <paramref name="defaultValue"/>.</returns>
		[DebuggerNonUserCode]
		public static T Convert<T>(this object value, T defaultValue)
			where T : struct
		{
			return Convert<T>(value) ?? defaultValue;
		}

		/// <summary>
		/// Attempts to convert the specified value to <see cref="Nullable{T}"/>.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="result">The converted value, if conversion succeeded; otherwise, default(<typeparamref name="T"/>).</param>
		/// <returns>true if conversion succeeded; otherwise, false.</returns>
		[DebuggerNonUserCode]
		public static bool TryConvert<T>(this object value, out T result)
			where T : struct
		{
			T? t = Convert<T>(value);

			if (t == null)
			{
				result = default(T);
				return false;
			}

			result = t.Value;
			return true;
		}

		/// <summary>
		/// Determines if the specified value can be converted to <typeparamref name="T"/>.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <returns>true if <paramref name="value"/> can be converted to <typeparamref name="T"/>; otherwise, false.</returns>
		[DebuggerNonUserCode]
		public static bool CanConvert<T>(this object value)
			where T : struct
		{
			return value.Convert<T>() != null;
		}

		/// <summary>
		/// Determines if the specified value can be converted to the specified type.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="type">A type.</param>
		/// <returns>true if <paramref name="value"/> can be converted to <paramref name="type"/>; otherwise, false.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> is null.</exception>
		[DebuggerNonUserCode]
		public static bool CanConvert(this object value, Type type)
		{
			type.ThrowIfNull("type");

			try
			{
				System.Convert.ChangeType(value, type);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Invokes the specified delegate if the specified value is not null.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="delegate">A <see cref="Func{TValue,TResult}"/> to invoke if <paramref name="value"/> is not null.</param>
		/// <returns>The result of <paramref name="delegate"/> if <paramref name="value"/> is not null; otherwise, null.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="delegate"/> is null.</exception>
		public static TResult IfNotNull<TValue, TResult>(this TValue value, Func<TValue, TResult> @delegate)
			where TValue : class
		{
			@delegate.ThrowIfNull("delegate");

			return value != null ? @delegate(value) : default(TResult);
		}

		/// <summary>
		/// Invokes the specified delegate if the specified value is not null.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="delegate">A <see cref="Func{TValue,TResult}"/> to invoke if <paramref name="value"/> is not null.</param>
		/// <returns>The result of <paramref name="delegate"/> if <paramref name="value"/> is not null; otherwise, null.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="delegate"/> is null.</exception>
		public static TResult IfNotNull<TValue, TResult>(this TValue? value, Func<TValue, TResult> @delegate)
			where TValue : struct
		{
			@delegate.ThrowIfNull("delegate");

			return value != null ? @delegate(value.Value) : default(TResult);
		}

		/// <summary>
		/// Throws an <see cref="ArgumentNullException"/> if the specified value is null.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <param name="paramName">The value's parameter name.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
		[DebuggerNonUserCode]
		public static void ThrowIfNull(this object value, string paramName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(paramName);
			}
		}

		/// <summary>
		/// Retrieves an enumerable consisting of the single element <paramref name="value"/>.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <returns>An enumerable consisting of the single element <paramref name="value"/></returns>
		public static IEnumerable<T> ToEnumerable<T>(this T value)
		{
			return new[]
				{
					value
				};
		}

		/// <summary>
		/// Traverses a sequence of values returned by a delegate.
		/// </summary>
		/// <param name="value">The first value of the traversal.</param>
		/// <param name="nextDelegate">A <see cref="Func{T,T}"/> that returns the next element in the sequence.</param>
		/// <param name="omitNull">When true, null delegate results are ignored; when false, the traversal ends.</param>
		/// <returns>An enumerable containing all the traversed elements.</returns>
		[DebuggerNonUserCode]
		public static IEnumerable<T> Traverse<T>(this T value, Func<T, T> nextDelegate, bool omitNull = true)
			where T : class
		{
			yield return value;

			T next = nextDelegate(value);

			if (next == null)
			{
				if (!omitNull)
				{
					yield return null;
				}
				yield break;
			}

			foreach (T t in Traverse(next, nextDelegate, omitNull))
			{
				yield return t;
			}
		}
	}
}