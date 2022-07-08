using System;
using System.Text.Json;

namespace WebView2.DOM
{
	public sealed class HTMLIFrameElement : HTMLElement
	{
		private HTMLIFrameElement() { }

		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string srcdoc { get => Get<string>(); set => Set(value); }
		public string name { get => Get<string>(); set => Set(value); }
		public DOMTokenList sandbox => Get<DOMTokenList>();
		public bool allowFullscreen { get => Get<bool>(); set => Set(value); }
		public bool disallowDocumentAccess { get => Get<bool>(); set => Set(value); }
		public uint width { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public uint height { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }

		public Document? contentDocument => Get<Document?>();
		public Window? contentWindow => Get<Window?>();
		public Document? getSVGDocument() => Method<Document?>().Invoke();
		public ReferrerPolicy referrerPolicy { get => Get<ReferrerPolicy>(); set => Set(value); }
		// https://w3c.github.io/webappsec-csp/embedded/#dom-htmliframeelement-csp
		public string csp { get => Get<string>(); set => Set(value); }

		// Feature Policy
		//[CEReactions, Reflect] attribute DOMString allow;
		//// https://w3c.github.io/webappsec-feature-policy/#the-policy-object
		//readonly attribute FeaturePolicy featurePolicy;

		//// Document Policy
		//[RuntimeEnabled=DocumentPolicyNegotiation, CEReactions, Reflect] attribute DOMString policy;

		public LazyLoading loading { get => Get<LazyLoading>(); set => Set(value); }

		//// Trust Tokens request parameters (https://github.com/wicg/trust-token-api)
		//[RuntimeEnabled=TrustTokens, SecureContext, Reflect, MeasureAs=TrustTokenIframe] attribute DOMString trustToken;
	}
}
