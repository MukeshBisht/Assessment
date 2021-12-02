using System;

namespace Import.Core.Exceptions
{
	public class ImportException : Exception
	{
		public ImportException() { }
		public ImportException(string message) : base(message) { }
		public ImportException(string message, Exception innerException) : base(message, innerException) { }
	}
}
