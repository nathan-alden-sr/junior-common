using System.Threading.Tasks;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for the <see cref="object"/> type.
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Retrieves a completed task with the specified value.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <typeparam name="T">A type.</typeparam>
		/// <returns>
		/// A completed <see cref="Task{T}"/> whose result is <paramref name="value"/>.
		/// </returns>
		public static Task<T> AsCompletedTask<T>(this T value)
		{
			return TaskHelpers.FromResult(value);
		}
	}
}