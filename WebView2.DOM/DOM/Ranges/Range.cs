using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/range.idl

	public enum BoundaryPointsComparison : ushort
	{
		START_TO_START = 0,
		START_TO_END = 1,
		END_TO_END = 2,
		END_TO_START = 3,
	}

	public class Range : JsObject
	{
		protected internal Range(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Node startContainer => Get<Node>();
		public uint startOffset => Get<uint>();
		public Node endContainer => Get<Node>();
		public uint endOffset => Get<uint>();
		public bool collapsed => Get<bool>();
		public Node commonAncestorContainer => Get<Node>();

		public void setStart(Node node, uint offset) => Method().Invoke(node, offset);
		public void setEnd(Node node, uint offset) => Method().Invoke(node, offset);
		public void setStartBefore(Node node) => Method().Invoke(node);
		public void setStartAfter(Node node) => Method().Invoke(node);
		public void setEndBefore(Node node) => Method().Invoke(node);
		public void setEndAfter(Node node) => Method().Invoke(node);
		public void collapse(bool toStart = false) => Method().Invoke(toStart);
		public void selectNode(Node node) => Method().Invoke(node);
		public void selectNodeContents(Node node) => Method().Invoke(node);

		public short compareBoundaryPoints(BoundaryPointsComparison how, Range sourceRange) =>
			Method<short>().Invoke(how, sourceRange);

		public void deleteContents() => Method().Invoke();
		public DocumentFragment extractContents() => Method<DocumentFragment>().Invoke();
		public DocumentFragment cloneContents() => Method<DocumentFragment>().Invoke();
		public void insertNode(Node node) => Method().Invoke(node);
		public void surroundContents(Node newParent) => Method().Invoke(newParent);

		public Range cloneRange() => Method<Range>().Invoke();
		public void detach() => Method().Invoke();

		public bool isPointInRange(Node node, uint offset) => Method<bool>().Invoke(node, offset);
		public short comparePoint(Node node, uint offset) => Method<short>().Invoke(node, offset);

		public bool intersectsNode(Node node) => Method<bool>().Invoke(node);

		// CSSOM View Module
		public IReadOnlyList<DOMRect> getClientRects() => Method<ImmutableList<DOMRect>>().Invoke();
		public DOMRect getBoundingClientRect() => Method<DOMRect>().Invoke();

		// DOM Parsing and Serialization
		//public DocumentFragment createContextualFragment(string fragment) => Method<DocumentFragment>().Invoke(fragment);

		// Non-standard API
		//public void expand(string unit = "") => Method().Invoke(unit);
	}
}