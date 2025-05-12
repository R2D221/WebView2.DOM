using System;

namespace WebView2.DOM
{
	public class DOMException : Exception
	{
		public DOMException() { }
		public DOMException(string? message) : base(message) { }
		public DOMException(string message, Exception innerException) : base(message, innerException) { }
	}
}
