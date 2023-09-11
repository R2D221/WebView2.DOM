using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Linq;
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

	public static void Add(NodeBuilder builder, IReadOnlyList<NodeBuilder> list)
	{
		var parent = (Node)builder;

		if (list.Any(child => builder.CanAddChild(child) == false))
		{
			throw new NotSupportedException($"Couldn't append child to node {parent.nodeName}");
		}

		if (list is INotifyCollectionChanged incc)
		{
			var startMarker = parent.appendChild(document.createComment(""));

			foreach (var child in list)
			{
				_ = parent.appendChild(child);
				NodeExtraInfo.AppendChild(parent, child);
			}

			var childNodes = list.Select(x => (Node)x).ToList();

			var endMarker = parent.appendChild(document.createComment(""));

			incc.CollectionChanged += (_, e) =>
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
						throw new IndexOutOfRangeException();

					if (newItems.Length == 1)
					{
						_ = parent.insertBefore(newItems[0], sibling);
						NodeExtraInfo.AppendChild(parent, newItems[0]);
						childNodes.Insert(e.NewStartingIndex, newItems[0]);
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
						childNodes.InsertRange(e.NewStartingIndex, newItems.Select(x => (Node)x));
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

					if (list.Count == 1)
					{
						_ = parent.insertBefore(list[0], endMarker);
						NodeExtraInfo.AppendChild(parent, list[0]);
					}
					else
					{
						var fragment = document.createDocumentFragment();

						foreach (var newItem in list)
						{
							_ = fragment.appendChild(newItem);
							NodeExtraInfo.AppendChild(parent, newItem);
						}

						_ = parent.insertBefore(fragment, endMarker);
						childNodes.AddRange(list.Select(x => (Node)x));
					}

					break;
				}
				}
			};
		}
		else
		{
			foreach (var child in list)
			{
				_ = parent.appendChild(child);
				NodeExtraInfo.AppendChild(parent, child);
			}
		}
	}
}
