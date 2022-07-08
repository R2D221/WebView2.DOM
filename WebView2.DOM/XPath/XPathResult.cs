namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/xml/xpath_result.idl

	public enum XPathResultType : ushort
	{
		ANY_TYPE = 0,
		NUMBER_TYPE = 1,
		STRING_TYPE = 2,
		BOOLEAN_TYPE = 3,
		UNORDERED_NODE_ITERATOR_TYPE = 4,
		ORDERED_NODE_ITERATOR_TYPE = 5,
		UNORDERED_NODE_SNAPSHOT_TYPE = 6,
		ORDERED_NODE_SNAPSHOT_TYPE = 7,
		ANY_UNORDERED_NODE_TYPE = 8,
		FIRST_ORDERED_NODE_TYPE = 9,
	}

	public sealed class XPathResult : JsObject
	{
		private XPathResult() { }

		public XPathResultType resultType => Get<XPathResultType>();

		public double numberValue => Get<double>();
		public string stringValue => Get<string>();
		public bool booleanValue => Get<bool>();
		public Node singleNodeValue => Get<Node>();

		public bool invalidIteratorState => Get<bool>();
		public uint snapshotLength => Get<uint>();

		public Node? iterateNext() => Method<Node?>().Invoke();
		public Node? snapshotItem(uint index) => Method<Node?>().Invoke(index);
	}
}
