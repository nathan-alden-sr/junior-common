using System.Threading.Tasks;

namespace Junior.Common
{
	internal static class TaskHelpers
	{
		public static Task Empty()
		{
			return FromResult<object>(null);
		}

		public static Task<T> FromResult<T>(T result)
		{
			var completionSource = new TaskCompletionSource<T>();

			completionSource.SetResult(result);

			return completionSource.Task;
		}
	}
}