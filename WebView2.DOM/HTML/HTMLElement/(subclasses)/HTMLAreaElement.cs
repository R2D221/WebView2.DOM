using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;

namespace WebView2.DOM
{
	public enum Shape { _, circle, @default, poly, rect }

	public sealed class HTMLAreaElement : HTMLElement, HTMLHyperlinkElementUtils
	{
		private HTMLAreaElement() { }

		// HTMLAnchorElement includes HTMLHyperlinkElementUtils
		public Uri href { get => Get<Uri>(); set => Set(value); }

		public string alt { get => Get<string>(); set => Set(value); }
		public IReadOnlyList<double> coords
		{
			get => Get<string>().Trim()
				.Split(',')
				.Select(x => double.Parse(x, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, CultureInfo.InvariantCulture))
				.ToImmutableArray();
			set => Set(string.Join(",", value.Select(x => x.ToString(CultureInfo.InvariantCulture))));
		}
		public string download { get => Get<string>(); set => Set(value); }
		public Shape shape { get => Get<Shape>(); set => Set(value); }
		public string target { get => Get<string>(); set => Set(value); }
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
		public DOMTokenList relList => GetCached<DOMTokenList>();
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
	}
}
