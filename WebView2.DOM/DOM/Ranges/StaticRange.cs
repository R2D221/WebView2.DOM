namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/static_range.idl

	public sealed class StaticRange : JsObject
	{
		private StaticRange() { }

		public Node startContainer => Get<Node>();
		public uint startOffset => Get<uint>();
		public Node endContainer => Get<Node>();
		public uint endOffset => Get<uint>();
		public bool collapsed => Get<bool>();
	}
}
