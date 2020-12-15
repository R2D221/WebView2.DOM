using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class ArrayBufferView : JsObject
	{
		protected internal ArrayBufferView(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId)
		{
			throw new NotImplementedException();
		}

		public ArrayBufferView() : this(null!, null!) { }
	}
}