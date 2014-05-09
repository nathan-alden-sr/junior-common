namespace Junior.Common
{
	/// <summary>
	/// MD5 string formats.
	/// </summary>
	public enum Md5StringFormat
	{
		/// <summary>
		/// Non-hyphenated hexadecimal characters.
		/// </summary>
		NonHyphenatedHexCharacters,
		/// <summary>
		/// Hyphenated hexadecimal characters.
		/// </summary>
		HyphenatedHexCharacters,
		/// <summary>
		/// Hyphenated and non-hyphenated hexadecimal characters.
		/// </summary>
		OptionallyHyphenatedHexCharacters
	}
}