using System;

namespace Junior.Common
{
	/// <summary>
	/// Represents a way to retrieve random GUIDs.
	/// </summary>
	public interface IGuidFactory
	{
		/// <summary>
		/// Retrieves a random GUID.
		/// </summary>
		/// <returns>A random GUID.</returns>
		Guid Random();
	}
}