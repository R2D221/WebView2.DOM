using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class File : Blob
	{
		protected internal File(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
			throw new NotImplementedException();
		}
		public File() : this(null!, null!) { }
	}
}
