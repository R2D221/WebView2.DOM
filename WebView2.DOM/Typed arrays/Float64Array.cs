using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class Float64Array : ArrayBufferView
	{
		protected internal Float64Array(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId)
		{
			throw new NotImplementedException();
		}

		public Float64Array() : this(null!, null!) { }
	}
}