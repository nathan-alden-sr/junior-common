using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Junior.Common.Net35
{
	/// <summary>
	/// An exception thrown when a generic type argument is not supported by a method.
	/// </summary>
	[DebuggerStepThrough]
	public class InvalidGenericTypeArgumentException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidGenericTypeArgumentException"/> class.
		/// </summary>
		public InvalidGenericTypeArgumentException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidGenericTypeArgumentException"/> class.
		/// </summary>
		public InvalidGenericTypeArgumentException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidGenericTypeArgumentException"/> class.
		/// </summary>
		public InvalidGenericTypeArgumentException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidGenericTypeArgumentException"/> class.
		/// </summary>
		public InvalidGenericTypeArgumentException(string message, string argumentName)
			: base(GetMessage(message, argumentName))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidGenericTypeArgumentException"/> class.
		/// </summary>
		public InvalidGenericTypeArgumentException(string message, string argumentName, Exception innerException)
			: base(GetMessage(message, argumentName), innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidGenericTypeArgumentException"/> class.
		/// </summary>
		protected InvalidGenericTypeArgumentException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		private static string GetMessage(string message, string argumentName)
		{
			return String.Format("{0}{1}Argument: {2}", message, Environment.NewLine, argumentName);
		}
	}
}