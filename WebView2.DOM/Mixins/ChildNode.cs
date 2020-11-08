using OneOf;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/child_node.idl

	public interface ChildNode
	{
		void before(params OneOf<Node, string>[] nodes);
		void after(params OneOf<Node, string>[] nodes);
		void replaceWith(params OneOf<Node, string>[] nodes);
		void remove();
	}
}
