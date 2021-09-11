using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public enum PotentialDestination { _, script, style, image, track, font, fetch }

	public class HTMLLinkElement : HTMLElement
	{
		protected internal HTMLLinkElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public bool disabled { get => Get<bool>(); set => Set(value); }
		public Uri href { get => Get<Uri>(); set => Set(value); }
		public CrossOrigin? crossOrigin { get => Get<CrossOrigin?>(); set => Set(value); }
		public string rel { get => Get<string>(); set => Set(value); }
		public DOMTokenList relList => _relList ??= Get<DOMTokenList>();
		private DOMTokenList? _relList;
		public string media { get => Get<string>(); set => Set(value); }
		public string hreflang { get => Get<string>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public PotentialDestination @as { get => Get<PotentialDestination>(); set => Set(value); }
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
		public DOMTokenList sizes => Get<DOMTokenList>();
		//[CEReactions, MeasureAs=PriorityHints, RuntimeEnabled=PriorityHints, Reflect, ReflectOnly=("low", "auto", "high"), ReflectMissing="auto", ReflectInvalid="auto"] attribute DOMString importance;
		public IReadOnlyList<SrcSetItem> imageSrcset
		{
			get => SrcSetItem.Parse(Get<string>());
			set => Set(SrcSetItem.ToString(value));
		}
		public string imageSizes { get => Get<string>(); set => Set(value); }

		// HTMLLinkElement includes LinkStyle
		public StyleSheet? sheet => Get<StyleSheet?>();

		// Subresource Integrity
		public string integrity { get => Get<string>(); set => Set(value); }

		// Subresource loading with Web Bundles
		//[RuntimeEnabled=SubresourceWebBundles, PutForwards=value] readonly attribute DOMTokenList resources;
	}
}
