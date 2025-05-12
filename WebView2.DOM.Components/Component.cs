using DelegateBindings;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace WebView2.DOM.Components;

public abstract class Component : NodeBuilder
{
	private readonly Lazy<Node> node;
	protected sealed override Node Node => node.Value;

	protected Component()
	{
		this.node = new(() => Render());
	}

	protected abstract Node Render();
	internal sealed override bool CanAddChild(Node child) => false;

	public static Node ForEach<T>(Func<IReadOnlyCollection<T>> itemsSource, Func<T, Node> itemTemplate) =>
		new ItemsComponent<T>(itemsSource, itemTemplate);
}

file sealed class ItemsComponent<T> : Component
{
	private readonly Func<IReadOnlyCollection<T>> itemsSource;
	private readonly Func<T, Node> itemTemplate;

	private readonly Lazy<Node> startMarkerLazy = new(() => document.createComment(""));
	private readonly List<Node> childNodes = new();
	private readonly Lazy<Node> endMarkerLazy = new(() => document.createComment(""));

	private INotifyCollectionChanged? incc = null;

	public ItemsComponent(Func<IReadOnlyCollection<T>> itemsSource, Func<T, Node> itemTemplate)
	{
		this.itemsSource = itemsSource;
		this.itemTemplate = itemTemplate;
	}

	protected override Node Render()
	{
		var fragment = document.createDocumentFragment();

		_ = fragment.appendChild(startMarkerLazy.Value);
		_ = fragment.appendChild(endMarkerLazy.Value);

		_ = DelegateBinder.WhenChanged(itemsSource, items =>
		{
			var parent = startMarkerLazy.Value.parentNode ?? throw new Exception();

			Unsubscribe();

			Clear(parent);
			AddRange(parent, items);

			Subscribe(items);
		});

		return fragment;
	}

	private void Unsubscribe()
	{
		if (incc is not null)
		{
			incc.CollectionChanged -= CollectionChanged;
		}
	}

	private void Subscribe(IReadOnlyCollection<T> items)
	{
		if (items is INotifyCollectionChanged incc)
		{
			this.incc = incc;
			incc.CollectionChanged += CollectionChanged;
		}
	}

	private void CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch(e.Action)
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
			break;
		}
		}

		void AddInternal()
		{
			childNodes.

			var sibling = e.NewStartingIndex switch
			{
				var i when 0 <= i && i < childNodes.Count => childNodes[i],

			}

			//var sibling =
			//	0 <= e.NewStartingIndex && e.NewStartingIndex < childNodes.Count
			//	? childNodes[e.NewStartingIndex] :
			//	e.NewStartingIndex == childNodes.Count
			//	? endMarker :
			//	e.NewStartingIndex == -1
			//	? endMarker :
			//	throw new IndexOutOfRangeException();
		}
	}

	private void AddRange(Node parent, IReadOnlyCollection<T> items)
	{
		if (items.Count == 1)
		{
			var child = itemTemplate(items.Single());

			_ = parent.insertBefore(child, endMarkerLazy.Value);
			NodeExtraInfo.AppendChild(parent, child);
			childNodes.Add(child);
		}
		else
		{
			var fragment = document.createDocumentFragment();

			childNodes.AddRange(items.Select(item =>
			{
				var child = itemTemplate(item);

				_ = fragment.appendChild(child);
				NodeExtraInfo.AppendChild(parent, child);

				return child;
			}));

			_ = parent.insertBefore(fragment, endMarkerLazy.Value);
		}
	}

	private void Clear(Node parent)
	{
		var startMarker = startMarkerLazy.Value;
		var endMarker = endMarkerLazy.Value;

		var current = startMarker.nextSibling;

		while (current is not null && current != endMarker)
		{
			var oldItem = current;
			current = oldItem.nextSibling;
			_ = parent.removeChild(oldItem);
			NodeExtraInfo.RemoveChild(parent, oldItem);
		}

		childNodes.Clear();
	}
}
