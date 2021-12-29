//using System;

//namespace WebView2.DOM.Collections
//{
//	public interface IReadOnlyCollection<out T> :
//		System.Collections.Generic.IReadOnlyCollection<T>,
//		System.Collections.ICollection
//	{
//		new int Count { get; }
//		new System.Collections.Generic.IEnumerator<T> GetEnumerator();

//		int System.Collections.Generic.IReadOnlyCollection<T>.Count => Count;

//		int System.Collections.ICollection.Count => Count;
//		bool System.Collections.ICollection.IsSynchronized => false;
//		object System.Collections.ICollection.SyncRoot => null!;
//		void System.Collections.ICollection.CopyTo(Array array, int index) =>
//			throw new NotSupportedException();

//		System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() =>
//			GetEnumerator();

//		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
//			GetEnumerator();
//	}
//}

using OneOf;
using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM
{
	public partial class CSSTransformValue : IReadOnlyCollection<CSSTransformValue>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class CSSUnparsedValue : IReadOnlyCollection<OneOf<string, CSSVariableReferenceValue>>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class CSSStyleDeclaration : IReadOnlyCollection<KeyValuePair<string, string>>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class CSSRuleList : JsObject, IReadOnlyCollection<CSSRule>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class StyleSheetList : IReadOnlyCollection<StyleSheet>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class HTMLCollection<TElement> : IReadOnlyCollection<TElement>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class NamedNodeMap : IReadOnlyCollection<Attr>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class NodeList<TNode> : IReadOnlyCollection<TNode>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class FileList : IReadOnlyCollection<File>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class TextTrackCueList : IReadOnlyCollection<TextTrackCue>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public partial class TextTrackList : EventTarget, IReadOnlyCollection<TextTrack>, ICollection
	{
		bool ICollection.IsSynchronized => false;
		object ICollection.SyncRoot => null!;
		void ICollection.CopyTo(Array array, int index) =>
			throw new NotSupportedException();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}