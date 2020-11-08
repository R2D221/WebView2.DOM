namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/non_document_type_child_node.idl

	public interface NonDocumentTypeChildNode
	{
		Element? previousElementSibling { get; }
		Element? nextElementSibling { get; }
	}
}
