using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public class HTMLSourceElement : HTMLElement
	{
		protected internal HTMLSourceElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }

		public IReadOnlyList<SrcSetItem> srcset
		{
			get => SrcSetItem.Parse(Get<string>());
			set => Set(SrcSetItem.ToString(value));
		}
		public string sizes { get => Get<string>(); set => Set(value); }
		public string media { get => Get<string>(); set => Set(value); }
	}
}
