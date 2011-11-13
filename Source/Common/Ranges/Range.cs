namespace Junior.Common.Ranges
{
	/// <summary>
	/// A range of <typeparamref name="T"/>.
	/// </summary>
	public class Range<T>
	{
		private readonly T _end;
		private readonly T _start;

		/// <summary>
		/// Initializes a new instance of the <see cref="Range{T}"/> class.
		/// </summary>
		/// <param name="start">The start of the range.</param>
		/// <param name="end">The end of the range.</param>
		public Range(T start, T end)
		{
			_start = start;
			_end = end;
		}

		/// <summary>
		/// Gets the start of the range.
		/// </summary>
		public T Start
		{
			get
			{
				return _start;
			}
		}

		/// <summary>
		/// Gets the end of the range.
		/// </summary>
		public T End
		{
			get
			{
				return _end;
			}
		}
	}
}