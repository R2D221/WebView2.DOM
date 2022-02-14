using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Markup;

namespace WebView2.Markup
{
	[DebuggerDisplay("Count = {Count}")]
	public abstract class NodeList : /*IList<Node>, */IList
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly List<Node> list = new();

		protected abstract bool Validate(Node node);

		int IList.Add(object? value)
		{
			Node node = value switch
			{
				Node n => n,
				string text => new Text(text),
				_ => throw new Exception(),
			};

			if (Validate(node))
			{
				return ((IList)list).Add(node);
			}
			else
			{
				return -1;
			}
		}

		public int Count => ((ICollection<Node>)list).Count;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsReadOnly => ((ICollection<Node>)list).IsReadOnly;

		public int IndexOf(Node item) => ((IList<Node>)list).IndexOf(item);

		public void Insert(int index, Node item) => ((IList<Node>)list).Insert(index, item);

		public void RemoveAt(int index) => ((IList<Node>)list).RemoveAt(index);

		//public void Add(Node item)
		//{
		//	if (Validate(item))
		//	{
		//		((ICollection<Node>)list).Add(item);
		//	}
		//}

		public void Clear() => ((ICollection<Node>)list).Clear();

		public bool Contains(Node item) => ((ICollection<Node>)list).Contains(item);

		public bool Remove(Node item) => ((ICollection<Node>)list).Remove(item);

		public IEnumerator<Node> GetEnumerator() => ((IEnumerable<Node>)list).GetEnumerator();

		public Node this[int index] { get => ((IList<Node>)list)[index]; set => ((IList<Node>)list)[index] = value; }

		//void ICollection<Node>.CopyTo(Node[] array, int arrayIndex) => ((ICollection<Node>)list).CopyTo(array, arrayIndex);

		object? IList.this[int index] { get => ((IList)list)[index]; set => ((IList)list)[index] = value; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool IList.IsFixedSize => ((IList)list).IsFixedSize;
		bool IList.Contains(object? value) => ((IList)list).Contains(value);
		int IList.IndexOf(object? value) => ((IList)list).IndexOf(value);
		void IList.Insert(int index, object? value) => ((IList)list).Insert(index, value);
		void IList.Remove(object? value) => ((IList)list).Remove(value);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized => ((ICollection)list).IsSynchronized;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot => ((ICollection)list).SyncRoot;
		void ICollection.CopyTo(Array array, int index) => ((ICollection)list).CopyTo(array, index);

		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)list).GetEnumerator();
	}

	public sealed class EmptyNodeList : NodeList
	{
		protected override bool Validate(Node node)
		{
			throw new NotImplementedException();
		}
	}

	[ContentWrapper(typeof(Element))]
	[ContentWrapper(typeof(Text))]
	[WhitespaceSignificantCollection]
	public sealed class DefaultNodeList : NodeList
	{
		public void Add(Node node) => _ = ((IList)this).Add(node);

		protected override bool Validate(Node node) => true;
	}

	public sealed class TextNodeList : NodeList
	{
		protected override bool Validate(Node node)
		{
			if (node is Text)
			{
				return true;
			}
			else
			{
				throw new Exception("Can't insert elements");
			}
		}
	}
}
