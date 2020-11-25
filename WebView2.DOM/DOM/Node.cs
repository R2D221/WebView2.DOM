using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/node.idl

	public enum NodeType : ushort
	{
		ELEMENT_NODE/*	*/= 1,
		ATTRIBUTE_NODE/*	*/= 2,
		TEXT_NODE/*	*/= 3,
		CDATA_SECTION_NODE/*	*/= 4,
		ENTITY_REFERENCE_NODE/*	*/= 5, // historical
		ENTITY_NODE/*	*/= 6, // historical
		PROCESSING_INSTRUCTION_NODE/*	*/= 7,
		COMMENT_NODE/*	*/= 8,
		DOCUMENT_NODE/*	*/= 9,
		DOCUMENT_TYPE_NODE/*	*/= 10,
		DOCUMENT_FRAGMENT_NODE/*	*/= 11,
		NOTATION_NODE/*	*/= 12, // historical
	}

	[Flags]
	public enum DocumentPosition : ushort
	{
		DISCONNECTED/*	*/= 0b000001,
		PRECEDING/*	*/= 0b000010,
		FOLLOWING/*	*/= 0b000100,
		CONTAINS/*	*/= 0b001000,
		CONTAINED_BY/*	*/= 0b010000,
		IMPLEMENTATION_SPECIFIC/*	*/= 0b100000,
	}

	public class Node : EventTarget
	{
		protected internal Node(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public NodeType nodeType => Get<NodeType>();
		public string nodeName => Get<string>();

		public string? baseURI => Get<string?>();

		public bool isConnected => Get<bool>();
		public Document? ownerDocument => Get<Document?>();
		public Node? parentNode => Get<Node?>();
		public Element? parentElement => Get<Element?>();
		public bool hasChildNodes() => Method<bool>().Invoke();
		public NodeList<Node> childNodes => _childNodes ??= Get<NodeList<Node>>();
		private NodeList<Node>? _childNodes;
		public Node? firstChild => Get<Node?>();
		public Node? lastChild => Get<Node?>();
		public Node? previousSibling => Get<Node?>();
		public Node? nextSibling => Get<Node?>();
		public Node? getRootNode(/*optional GetRootNodeOptions options = {}*/) => Method<Node>().Invoke();

		public string? nodeValue
		{
			get => Get<string?>();
			set => Set(value);
		}

		public string? textContent
		{
			get => Get<string?>();
			set => Set(value);
		}
		public void normalize() => Method().Invoke();

		public Node cloneNode(bool deep) => Method<Node>().Invoke(deep);
		public bool isEqualNode(Node? node) => Method<bool>().Invoke(node);

		public DocumentPosition compareDocumentPosition(Node other) => Method<DocumentPosition>().Invoke(other);
		public bool contains(Node? other) => Method<bool>().Invoke(other);

		public string? lookupPrefix(string? namespaceURI) => Method<string?>().Invoke(namespaceURI);
		public string? lookupNamespaceURI(string? prefix) => Method<string?>().Invoke(prefix);
		public bool isDefaultNamespace(string? namespaceURI) => Method<bool>().Invoke(namespaceURI);

		public Node insertBefore(Node node, Node? child) => Method<Node>().Invoke(node, child);
		public Node appendChild(Node node) => Method<Node>().Invoke(node);
		public Node replaceChild(Node node, Node child) => Method<Node>().Invoke(node, child);
		public Node removeChild(Node child) => Method<Node>().Invoke(child);
	}
}