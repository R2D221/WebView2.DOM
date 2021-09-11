using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_transform_value.idl

	// Although the CSS Typed OM spec defines this as a mutable list, it seems to support additions, but
	// not deletions. You can add a new item using this[length] = item, but there's no way to delete
	// such item afterwards.

	// Since this doesn't neatly match any C# interface in the standard library, I decided to implement
	// it as a readonly collection in C#. If people really need the mutability, I can add it back
	// as a request.

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class CSSTransformValue : CSSStyleValue, WebView2.DOM.Collections.IReadOnlyCollection<CSSTransformValue>
	{
		protected internal CSSTransformValue(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public CSSTransformValue(IReadOnlyList<CSSTransformComponent> transforms)
			: this(window.Instance.coreWebView, Guid.NewGuid().ToString()) =>
			Construct(transforms);

		public bool is2D => Get<bool>();
		public DOMMatrix toMatrix() => Method<DOMMatrix>().Invoke();

		public int Count => Get<int>("length");

		public IEnumerator<CSSTransformValue> GetEnumerator() =>
			SymbolMethod<Iterator<CSSTransformValue>>("iterator").Invoke();
	}
}
