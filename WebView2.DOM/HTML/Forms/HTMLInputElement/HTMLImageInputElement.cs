using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class HTMLImageInputElement : HTMLInputElement
	{
		protected internal HTMLImageInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public Uri formAction { get => Get<Uri>(); set => Set(value); }
		public Enctype formEnctype { get => Get<Enctype>(); set => Set(value); }
		public Method formMethod { get => Get<Method>(); set => Set(value); }
		public bool formNoValidate { get => Get<bool>(); set => Set(value); }
		public string formTarget { get => Get<string>(); set => Set(value); }

		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string alt { get => Get<string>(); set => Set(value); }
		public uint width { get => Get<uint>(); set => Set(value); }
		public uint height { get => Get<uint>(); set => Set(value); }
	}
}
