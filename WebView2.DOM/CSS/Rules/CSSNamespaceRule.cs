namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_namespace_rule.idl

	public sealed class CSSNamespaceRule : CSSRule
	{
		private CSSNamespaceRule() { }

		public string namespaceURI => Get<string>();
		public string prefix => Get<string>();
	}
}
