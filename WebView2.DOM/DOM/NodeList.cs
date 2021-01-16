using Microsoft.Web.WebView2.Core;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/node_list.idl

	public sealed class NodeList : JsObject
	{
		internal NodeList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }
	}

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public class NodeList<TNode> : JsObject, WebView2.DOM.Collections.IReadOnlyCollection<TNode>
		where TNode : Node
	{
		protected internal NodeList(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public static implicit operator NodeList<TNode>(NodeList nodeList) =>
			new NodeList<TNode>(nodeList);

		internal NodeList(NodeList nodeList)
			: base(nodeList.coreWebView, nodeList.referenceId)
		{
			References.Update(target: this);
		}

		public int Count => Get<int>("length");

		public IEnumerator<TNode> GetEnumerator() =>
			SymbolMethod<Iterator<TNode>>("iterator").Invoke();
	}
}
