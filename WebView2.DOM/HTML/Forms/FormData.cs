using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class FormData : JsObject
	{
		protected internal FormData(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
			throw new NotImplementedException();
		}
		public FormData() : this(null!, null!) { }
	}
}
