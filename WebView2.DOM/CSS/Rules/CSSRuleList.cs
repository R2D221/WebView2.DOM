using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_rule_list.idl

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public partial class CSSRuleList : JsObject, IReadOnlyCollection<CSSRule>
	{
		protected internal CSSRuleList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		//public CSSRule this[uint index] =>
		//	IndexerGet<CSSRule?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));

		public int Count => Get<int>("length");

		public IEnumerator<CSSRule> GetEnumerator() =>
			SymbolMethod<Iterator<CSSRule>>("iterator").Invoke();
	}
}
