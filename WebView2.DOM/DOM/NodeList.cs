using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/node_list.idl

	public sealed class NodeList : JsObject { }

	[DebuggerTypeProxy(typeof(JsCollectionProxy))]
	public sealed class NodeList<TNode> : JsObject, ICollection<TNode>, IReadOnlyCollection<TNode>
		where TNode : Node
	{
		public static implicit operator NodeList<TNode>(NodeList nodeList) =>
			new NodeList<TNode>(nodeList);

		internal NodeList(NodeList nodeList)
		{
			References.Swap(source: nodeList, target: this);
		}

		public TNode this[uint index] =>
			IndexerGet<TNode?>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		public uint length => Get<uint>();

		public Iterator<TNode> GetEnumerator() =>
			SymbolMethod<Iterator<TNode>>("iterator").Invoke();

		int IReadOnlyCollection<TNode>.Count => (int)length;
		int ICollection<TNode>.Count => (int)length;
		bool ICollection<TNode>.IsReadOnly => true;
		void ICollection<TNode>.Add(TNode item) => throw new NotSupportedException();
		void ICollection<TNode>.Clear() => throw new NotSupportedException();
		bool ICollection<TNode>.Contains(TNode item) => this.Any(x => x == item);
		void ICollection<TNode>.CopyTo(TNode[] array, int arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
		bool ICollection<TNode>.Remove(TNode item) => throw new NotSupportedException();
		IEnumerator<TNode> IEnumerable<TNode>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
