using System.Xml.Linq;

namespace Junior.Common
{
	/// <summary>
	/// Extensions for the <see cref="XContainer"/> type.
	/// </summary>
	public static class XContainerExtensions
	{
		/// <summary>
		/// Retrieves a child element's value.
		/// </summary>
		/// <param name="container">An <see cref="XContainer"/>.</param>
		/// <param name="elementName">The name of the element to retrieve.</param>
		/// <param name="defaultValue">The value to return if the element was not found.</param>
		/// <returns>the element's value, if found; otherwise, <paramref name="defaultValue"/>.</returns>
		public static T ElementValue<T>(this XContainer container, string elementName, T defaultValue)
			where T : struct
		{
			XElement element = container.Element(elementName);

			return element != null ? element.Value.Convert(defaultValue) : defaultValue;
		}

		/// <summary>
		/// Retrieves a child element's value.
		/// </summary>
		/// <param name="container">An <see cref="XContainer"/>.</param>
		/// <param name="elementName">The name of the element to retrieve.</param>
		/// <param name="defaultValue">The value to return if the element was not found.</param>
		/// <returns>the element's value, if found; otherwise, <paramref name="defaultValue"/>.</returns>
		public static string ElementValue(this XContainer container, string elementName, string defaultValue)
		{
			XElement element = container.Element(elementName);

			return element.IfNotNull(arg => arg.Value) ?? defaultValue;
		}
	}
}