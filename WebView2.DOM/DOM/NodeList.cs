using Microsoft.Web.WebView2.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/node_list.idl

	public abstract class NodeList : JsObject { }

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public partial class NodeList<TNode> : NodeList, IReadOnlyCollection<TNode>
		where TNode : Node
	{
		private protected NodeList() { }

		public int Count => Get<int>("length");

		public IEnumerator<TNode> GetEnumerator() =>
			SymbolMethod<Iterator<TNode>>("iterator").Invoke();
	}
}
