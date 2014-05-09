namespace Junior.Common
{
	internal class StringHelpers
	{
		public static bool IsNullOrWhiteSpace(string value)
		{
			return value == null || value.Trim().Length == 0;
		}
	}
}