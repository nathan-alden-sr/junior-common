namespace Junior.Common.Net35
{
	internal class StringHelpers
	{
		public static bool IsNullOrWhiteSpace(string value)
		{
			return value == null || value.Trim().Length == 0;
		}
	}
}