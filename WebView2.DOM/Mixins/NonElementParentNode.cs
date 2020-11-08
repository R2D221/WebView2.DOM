using System;
using System.Collections.Generic;
using System.Text;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/non_element_parent_node.idl

	interface NonElementParentNode
	{
		Element? getElementById(string elementId);
	}
}
