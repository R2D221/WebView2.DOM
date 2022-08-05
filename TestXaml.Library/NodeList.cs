using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace WebView2.Markup
{
	public abstract class NodeList2<T> : Collection<T>
	{
		protected override void ClearItems()
		{
			base.ClearItems();
		}

		protected override void InsertItem(int index, T item)
		{
			base.InsertItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			base.RemoveItem(index);
		}

		protected override void SetItem(int index, T item)
		{
			base.SetItem(index, item);
		}
	}











	[DebuggerDisplay("Count = {Count}")]
	public abstract class NodeList : /*IList<Node>, */IList
	{
		public static bool IsRunningInVisualStudioDesigner
		{
			get
			{
				// Are we looking at this dialog in the Visual Studio Designer or Blend?
				string? appname = Assembly.GetEntryAssembly()?.FullName;
				return appname?.Contains("WpfSurface") == true;
			}
		}

		public NodeList(Node owner) => this.owner = owner;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Node owner;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly List<Node> list = new();

		protected abstract bool Validate(Node node);

		int IList.Add(object? value)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - IList.Add({value})");
			//}

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

		public int Count
		{
			get
			{
				return ((ICollection<Node>)list).Count;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsReadOnly => ((ICollection<Node>)list).IsReadOnly;

		public int IndexOf(Node item)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - IndexOf({item})");
			//}

			return ((IList<Node>)list).IndexOf(item);
		}

		public void Insert(int index, Node item)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - Insert({index}, {item})");
			//}

			((IList<Node>)list).Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - RemoveAt({index})");
			//}

			((IList<Node>)list).RemoveAt(index);
		}

		//public void Add(Node item)
		//{
		//	if (Validate(item))
		//	{
		//		((ICollection<Node>)list).Add(item);
		//	}
		//}

		public void Clear()
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - Clear()");
			//}

			((ICollection<Node>)list).Clear();
		}

		public bool Contains(Node item)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - Contains({item})");
			//}

			return ((ICollection<Node>)list).Contains(item);
		}

		public bool Remove(Node item)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - Remove({item})");
			//}

			return ((ICollection<Node>)list).Remove(item);
		}

		public IEnumerator<Node> GetEnumerator() => ((IEnumerable<Node>)list).GetEnumerator();

		public Node this[int index]
		{
			get
			{
				//if (IsRunningInVisualStudioDesigner)
				//{
				//	_ = MessageBox.Show($"{owner} - this[{index}]");
				//}

				return ((IList<Node>)list)[index];
			}

			set
			{
				//if (IsRunningInVisualStudioDesigner)
				//{
				//	_ = MessageBox.Show($"{owner} - this[{index}] = {value}");
				//}

				((IList<Node>)list)[index] = value;
			}
		}

		//void ICollection<Node>.CopyTo(Node[] array, int arrayIndex) => ((ICollection<Node>)list).CopyTo(array, arrayIndex);

		object? IList.this[int index]
		{
			get
			{
				//if (IsRunningInVisualStudioDesigner)
				//{
				//	_ = MessageBox.Show($"{owner} - IList.this[{index}]");
				//}

				try
				{
					return ((IList)list)[index];
				}
				catch
				{
					_ = MessageBox.Show($"{owner} - Contents2: [{string.Join(", ", list)}]");
					throw new Exception($"{owner} - Contents2: [{string.Join(", ", list)}]");
					//throw new Exception($"object? this[index={index}]");
				}
			}

			set
			{
				//if (IsRunningInVisualStudioDesigner)
				//{
				//	_ = MessageBox.Show($"{owner} - IList.this[{index}] = {value}");
				//}

				((IList)list)[index] = value;
			}
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool IList.IsFixedSize => ((IList)list).IsFixedSize;
		bool IList.Contains(object? value)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - IList.Contains({value})");
			//}

			return ((IList)list).Contains(value);
		}

		int IList.IndexOf(object? value)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - IList.IndexOf({value})");
			//}

			return ((IList)list).IndexOf(value);
		}

		void IList.Insert(int index, object? value)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - IList.Insert({index}, {value})");
			//}

			((IList)list).Insert(index, value);
		}

		void IList.Remove(object? value)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - IList.Remove({value})");
			//}

			((IList)list).Remove(value);
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized => ((ICollection)list).IsSynchronized;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot => ((ICollection)list).SyncRoot;
		void ICollection.CopyTo(Array array, int index)
		{
			//if (IsRunningInVisualStudioDesigner)
			//{
			//	_ = MessageBox.Show($"{owner} - ICollection.CopyTo({array}, {index})");
			//}

			((ICollection)list).CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)list).GetEnumerator();
	}

	public sealed class EmptyNodeList : NodeList
	{
		public EmptyNodeList(Node owner) : base(owner) { }

		protected override bool Validate(Node node)
		{
			throw new NotSupportedException();
		}
	}

	[ContentWrapper(typeof(Text))]
	[WhitespaceSignificantCollection]
	public sealed class DefaultNodeList : NodeList
	{
		public DefaultNodeList(Node owner) : base(owner) { }

		public void Add(Node node) => _ = ((IList)this).Add(node);

		protected override bool Validate(Node node) => true;
	}

	[ContentWrapper(typeof(Text))]
	[WhitespaceSignificantCollection]
	public sealed class FlowContentNodeList : NodeList
	{
		public FlowContentNodeList(Node owner) : base(owner) { }

		public void Add(FlowContent node) => _ = ((IList)this).Add(node);

		protected override bool Validate(Node node)
		{
			switch (node)
			{
			case FlowContent: return true;

			default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
			}
		}
	}

	[ContentWrapper(typeof(Text))]
	[WhitespaceSignificantCollection]
	public sealed class PhrasingContentNodeList : NodeList
	{
		public PhrasingContentNodeList(Node owner) : base(owner) { }

		public void Add(PhrasingContent node) => _ = ((IList)this).Add(node);

		protected override bool Validate(Node node)
		{
			switch (node)
			{
			case PhrasingContent: return true;

			default: throw new System.Exception($"Can't add child node {node?.GetType().Name ?? "null"} to {this.GetType().Name}");
			}
		}
	}

	public sealed class TextNodeList : NodeList
	{
		public TextNodeList(Node owner) : base(owner) { }

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
