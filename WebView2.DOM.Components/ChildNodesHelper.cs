using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using static DelegateBindings.DelegateBinder;

namespace WebView2.DOM.Components;

public static class ChildNodesHelper
{
	private static Document document => NodeBuilder.document;

	public static void Add(NodeBuilder builder, Node child)
	{
		var parent = (Node)builder;
		if (builder.CanAddChild(child) == false)
		{
			throw new NotSupportedException($"Couldn't append child to node {parent.nodeName}");
		}

		_ = parent.appendChild(child);
		NodeExtraInfo.AppendChild(parent, child);
	}

	public static void Add(NodeBuilder builder, string text)
	{
		var parent = (Node)builder;
		var child = document.createTextNode(text);

		if (builder.CanAddChild(child) == false)
		{
			throw new NotSupportedException($"Couldn't append child to node {parent.nodeName}");
		}

		_ = parent.appendChild(child);
		NodeExtraInfo.AppendChild(parent, child);
	}

	public static void Add(NodeBuilder builder, Func<string> text)
	{
		var parent = (Node)builder;
		var child = document.createTextNode("");

		if (builder.CanAddChild(child) == false)
		{
			throw new NotSupportedException($"Couldn't append child to node {parent.nodeName}");
		}

		_ = Bind(() => child.data = text());
		_ = parent.appendChild(child);
		NodeExtraInfo.AppendChild(parent, child);
	}

	public static void Add(NodeBuilder builder, IEnumerable<NodeBuilder> children)
	{
		var parent = (Node)builder;

		if (children.Any(child => builder.CanAddChild(child) == false))
		{
			throw new NotSupportedException($"Couldn't append child to node {parent.nodeName}");
		}

		if (children is INotifyCollectionChanged and IReadOnlyCollection<NodeBuilder>)
		{
			var notifyingChildren = Unsafe.As<INotifyingCollection<NodeBuilder>>(children);

			var startMarker = parent.appendChild(document.createComment(""));

			foreach (var child in notifyingChildren)
			{
				_ = parent.appendChild(child);
				NodeExtraInfo.AppendChild(parent, child);
			}

			var childNodes = notifyingChildren.Select(x => (Node)x).ToList();

			var endMarker = parent.appendChild(document.createComment(""));

			notifyingChildren.CollectionChanged += (_, e) =>
			{
				void AddInternal()
				{
					var newItems =
						e.NewItems!.Cast<NodeBuilder>()
						.ToImmutableArray();

					var sibling =
						0 <= e.NewStartingIndex && e.NewStartingIndex < childNodes.Count
						? childNodes[e.NewStartingIndex] :
						e.NewStartingIndex == childNodes.Count
						? endMarker :
						e.NewStartingIndex == -1
						? endMarker :
						throw new IndexOutOfRangeException();

					if (newItems.Length == 1)
					{
						_ = parent.insertBefore(newItems[0], sibling);
						NodeExtraInfo.AppendChild(parent, newItems[0]);

						if (e.NewStartingIndex == -1)
						{
							childNodes.Add(newItems[0]);
						}
						else
						{
							childNodes.Insert(e.NewStartingIndex, newItems[0]);
						}
					}
					else
					{
						var fragment = document.createDocumentFragment();

						foreach (var newItem in newItems)
						{
							_ = fragment.appendChild(newItem);
							NodeExtraInfo.AppendChild(parent, newItem);
						}

						_ = parent.insertBefore(fragment, sibling);

						if (e.NewStartingIndex == -1)
						{
							childNodes.AddRange(newItems.Select(x => (Node)x));
						}
						else
						{
							childNodes.InsertRange(e.NewStartingIndex, newItems.Select(x => (Node)x));
						}
					}
				}

				void RemoveInternal()
				{
					var oldItems = e.OldItems!.Cast<NodeBuilder>();
					foreach (var oldItem in oldItems)
					{
						_ = parent.removeChild(oldItem);
						NodeExtraInfo.RemoveChild(parent, oldItem);
					}
				}

				switch (e.Action)
				{
				case NotifyCollectionChangedAction.Add:
				{
					AddInternal();
					break;
				}
				case NotifyCollectionChangedAction.Remove:
				{
					RemoveInternal();
					break;
				}
				case NotifyCollectionChangedAction.Replace:
				{
					RemoveInternal();
					AddInternal();
					break;
				}
				case NotifyCollectionChangedAction.Move:
				{
					RemoveInternal();
					AddInternal();
					break;
				}
				case NotifyCollectionChangedAction.Reset:
				{
					var current = startMarker.nextSibling;

					while (current is not null && current != endMarker)
					{
						var oldItem = current;
						current = oldItem.nextSibling;
						_ = parent.removeChild(oldItem);
						NodeExtraInfo.RemoveChild(parent, oldItem);
					}

					childNodes.Clear();

					if (notifyingChildren.Count == 1)
					{
						var child = notifyingChildren.Single();
						_ = parent.insertBefore(child, endMarker);
						NodeExtraInfo.AppendChild(parent, child);
					}
					else
					{
						var fragment = document.createDocumentFragment();

						foreach (var newItem in notifyingChildren)
						{
							_ = fragment.appendChild(newItem);
							NodeExtraInfo.AppendChild(parent, newItem);
						}

						_ = parent.insertBefore(fragment, endMarker);
						childNodes.AddRange(notifyingChildren.Select(x => (Node)x));
					}

					break;
				}
				}
			};
		}
		else
		{
			foreach (var child in children)
			{
				_ = parent.appendChild(child);
				NodeExtraInfo.AppendChild(parent, child);
			}
		}
	}
}
