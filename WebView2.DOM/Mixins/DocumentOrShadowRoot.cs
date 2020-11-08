using System;
using System.Collections.Generic;
using System.Text;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/document_or_shadow_root.idl

	public interface DocumentOrShadowRoot
	{
		// Selection API
		Selection? getSelection();

		// CSSOM View Module
		Element? elementFromPoint(double x, double y);
		IReadOnlyList<Element> elementsFromPoint(double x, double y);
		Element? activeElement { get; }
		StyleSheetList styleSheets { get; } // SameObject

		// PointerLock API
		Element? pointerLockElement { get; }

		// Fullscreen API
		Element? fullscreenElement { get; }
		IReadOnlyList<CSSStyleSheet> adoptedStyleSheets { get; set; }
	}
}
