using System;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public sealed class HTMLSourceElement : HTMLElement
	{
		private HTMLSourceElement() { }

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
