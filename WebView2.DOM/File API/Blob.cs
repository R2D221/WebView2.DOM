using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/fileapi/blob.idl

	public class Blob : JsObject
	{
		protected internal Blob(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
			throw new NotImplementedException();
		}

		public Blob() : this(null!, null!) { }
	}
}
