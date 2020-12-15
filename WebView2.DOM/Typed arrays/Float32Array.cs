using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class Float32Array : ArrayBufferView
	{
		protected internal Float32Array(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId)
		{
			throw new NotImplementedException();
		}

		public Float32Array() : this(null!, null!) { }
	}
}