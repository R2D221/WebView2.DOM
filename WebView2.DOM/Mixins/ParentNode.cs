using OneOf;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/parent_node.idl

	public interface ParentNode
	{
		HTMLCollection<Element> children { get; } // SameObject
		Element? firstElementChild { get; }
		Element? lastElementChild { get; }
		uint childElementCount { get; }

		void prepend(params OneOf<Node, string>[] nodes);
		void append(params OneOf<Node, string>[] nodes);
		//void replaceChildren((Node or DOMString or TrustedScript)... nodes);

		Element? querySelector(string selectors);
		NodeList<Element> querySelectorAll(string selectors);
	}
}
