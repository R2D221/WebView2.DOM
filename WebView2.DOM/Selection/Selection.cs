using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/editing/selection.idl

	public class Selection : JsObject
	{
		protected internal Selection(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Node? anchorNode => Get<Node?>();
		public uint anchorOffset => Get<uint>();
		public Node? focusNode => Get<Node?>();
		public uint focusOffset => Get<uint>();
		public bool isCollapsed => Get<bool>();
		public uint rangeCount => Get<uint>();
		public string type => Get<string>();
		public Range getRangeAt(uint index) => Method<Range>().Invoke(index);
		public void addRange(Range range) => Method().Invoke(range);
		public void removeRange(Range range) => Method().Invoke(range);
		public void removeAllRanges() => Method().Invoke();
		public void empty() => Method().Invoke();
		public void collapse(Node? node, uint offset = 0) => Method().Invoke(node, offset);
		public void setPosition(Node? node, uint offset = 0) => Method().Invoke(node, offset);
		public void collapseToStart() => Method().Invoke();
		public void collapseToEnd() => Method().Invoke();
		public void extend(Node node, uint offset = 0) => Method().Invoke(node, offset);
		public void setBaseAndExtent(Node anchorNode, uint anchorOffset, Node focusNode, uint focusOffset) =>
			Method().Invoke(anchorNode, anchorOffset, focusNode, focusOffset);
		public void selectAllChildren(Node node) => Method().Invoke(node);
		public void deleteFromDocument() => Method().Invoke();
		public bool containsNode(Node node, bool allowPartialContainment = false) => Method<bool>().Invoke(node, allowPartialContainment);

		// Non-standard APIs

		//public Node? baseNode => Get<Node?>();
		//public uint baseOffset => Get<uint>();
		//public Node? extentNode => Get<Node?>();
		//public uint extentOffset => Get<uint>();

		public void modify(string alter, string direction, string granularity) =>
			Method().Invoke(alter, direction, granularity);
	}
}