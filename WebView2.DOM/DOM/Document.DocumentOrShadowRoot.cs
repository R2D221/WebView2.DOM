using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace WebView2.DOM
{
	public partial class Document : DocumentOrShadowRoot
	{
		public Element? activeElement => Get<Element?>();
		public StyleSheetList styleSheets => GetCached<StyleSheetList>();
		public Element? pointerLockElement => Get<Element?>();
		public Element? fullscreenElement => Get<Element?>();
		public IReadOnlyList<CSSStyleSheet> adoptedStyleSheets
		{
			get => Get<ImmutableArray<CSSStyleSheet>>();
			set => Set(value);
		}
		public Element? elementFromPoint(double x, double y) => Method<Element?>().Invoke(x, y);
		public IReadOnlyList<Element> elementsFromPoint(double x, double y) => Method<ImmutableArray<Element>>().Invoke(x, y);
		public Selection? getSelection() => Method<Selection?>().Invoke();
	}
}
