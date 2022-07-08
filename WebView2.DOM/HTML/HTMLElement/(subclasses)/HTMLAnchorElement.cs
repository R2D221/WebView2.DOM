using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace WebView2.DOM
{
	public sealed class HTMLAnchorElement : HTMLElement, HTMLHyperlinkElementUtils
	{
		private HTMLAnchorElement() { }

		// HTMLAnchorElement includes HTMLHyperlinkElementUtils
		public Uri href { get => Get<Uri>(); set => Set(value); }

		public string target { get => Get<string>(); set => Set(value); }
		public string download { get => Get<string>(); set => Set(value); }
		public IReadOnlyList<Uri> ping
		{
			get => Get<string>().Trim()
				.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
				.Select(x => new Uri(x))
				.ToImmutableArray()
				;
			set => Set(string.Join(" ", value));
		}
		public string rel { get => Get<string>(); set => Set(value); }
		public DOMTokenList relList => _relList ??= Get<DOMTokenList>();
		private DOMTokenList? _relList;
		public string hreflang { get => Get<string>(); set => Set(value); }
		public string hrefTranslate { get => Get<string>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }

		public string text { get => Get<string>(); set => Set(value); }

		// Conversion Measurement
		//public string impressionData { get => Get<string>(); set => Set(value); }
		//public string conversionDestination { get => Get<string>(); set => Set(value); }
		//public string reportingOrigin { get => Get<string>(); set => Set(value); }
		//public string impressionExpiry { get => Get<string>(); set => Set(value); }
	}
}
