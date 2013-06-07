using System;
using System.Diagnostics;

namespace Junior.Common
{
	/// <summary>
	/// Retrieves random GUIDs. Currently, <see cref="GuidFactory"/> simply returns <see cref="Guid.NewGuid"/>.
	/// </summary>
	[DebuggerStepThrough]
	public class GuidFactory : IGuidFactory
	{
		/// <summary>
		/// Retrieves a random GUID.
		/// </summary>
		/// <returns>A random GUID.</returns>
		public Guid Random()
		{
			return Guid.NewGuid();
		}
	}
}