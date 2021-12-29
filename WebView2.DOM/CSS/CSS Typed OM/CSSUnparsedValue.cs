using Microsoft.Web.WebView2.Core;
using OneOf;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_unparsed_value.idl

	// Although the CSS Typed OM spec defines this as a mutable list, it seems to support additions, but
	// not deletions. You can add a new item using this[length] = item, but there's no way to delete
	// such item afterwards.

	// Since this doesn't neatly match any C# interface in the standard library, I decided to implement
	// it as a readonly collection in C#. If people really need the mutability, I can add it back
	// as a request.

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public partial class CSSUnparsedValue : CSSStyleValue, IReadOnlyCollection<OneOf<string, CSSVariableReferenceValue>>
	{
		protected internal CSSUnparsedValue(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public CSSUnparsedValue(IReadOnlyList<OneOf<string, CSSVariableReferenceValue>> members)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(members);

		public int Count => Get<int>("length");

		public IEnumerator<OneOf<string, CSSVariableReferenceValue>> GetEnumerator() =>
			SymbolMethod<Iterator<OneOf<string, CSSVariableReferenceValue>>>("iterator").Invoke();
	}
}
