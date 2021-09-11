using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	public class HTMLScriptElement : HTMLElement
	{
		protected internal HTMLScriptElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public bool noModule { get => Get<bool>(); set => Set(value); }
		public string charset { get => Get<string>(); set => Set(value); }
		public bool async { get => Get<bool>(); set => Set(value); }
		public bool defer { get => Get<bool>(); set => Set(value); }
		public CrossOrigin? crossOrigin { get => Get<CrossOrigin?>(); set => Set(value); }
		public string text { get => Get<string>(); set => Set(value); }
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
		//[CEReactions, MeasureAs=PriorityHints, RuntimeEnabled=PriorityHints, Reflect, ReflectOnly=("low", "auto", "high"), ReflectMissing="auto", ReflectInvalid="auto"] attribute DOMString importance;

		// Subresource Integrity
		public string integrity { get => Get<string>(); set => Set(value); }
	}
}
