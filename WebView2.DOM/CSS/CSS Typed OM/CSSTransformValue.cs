﻿using Microsoft.Web.WebView2.Core;
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
	public partial class CSSTransformValue : CSSStyleValue, IReadOnlyCollection<CSSTransformComponent>
	{
		protected internal CSSTransformValue() { }

		public CSSTransformValue(IReadOnlyList<CSSTransformComponent> transforms) =>
			Construct(transforms);

		public bool is2D => Get<bool>();
		public DOMMatrix toMatrix() => Method<DOMMatrix>().Invoke();

		public int Count => Get<int>("length");

		public IEnumerator<CSSTransformComponent> GetEnumerator() =>
			SymbolMethod<Iterator<CSSTransformComponent>>("iterator").Invoke();
	}
}
