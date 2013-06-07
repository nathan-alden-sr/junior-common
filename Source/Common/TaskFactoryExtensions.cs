using System.Diagnostics;
using System.Threading.Tasks;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for the <see cref="TaskFactory"/> and <see cref="TaskFactory{TResult}"/> types.
	/// </summary>
	[DebuggerStepThrough]
	public static class TaskFactoryExtensions
	{
		/// <summary>Retrieves a <see cref="Task"/> with a null result.</summary>
		/// <param name="taskFactory">A task factory.</param>
		/// <returns>A <see cref="Task"/> whose result is null.</returns>
		public static Task Empty(this TaskFactory taskFactory)
		{
			return Task.FromResult((object)null);
		}

		/// <summary>Retrieves a <see cref="Task{T}"/> with a null result.</summary>
		/// <param name="taskFactory">A task factory.</param>
		/// <returns>A <see cref="Task{T}"/> whose result is null.</returns>
		public static Task<T> Empty<T>(this TaskFactory<T> taskFactory)
			where T : class
		{
			return Task.FromResult((T)null);
		}
	}
}