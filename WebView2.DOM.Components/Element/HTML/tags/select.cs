using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public sealed class @select : HTMLSelectElementBuilder, IEnumerable
{
	protected override HTMLSelectElement CreateElement()
	{
		var element = document.createHTMLElement(HTMLElementTag.@select);
		element.onchange += (_, e) =>
		{
			foreach (var option in element.options)
			{
				if (HTMLOptionElementBuilder.extraEvents.TryGetValue(option, out var extraEvents))
				{
					extraEvents.selectedChanged?.Invoke(option, e);
				}
			}
		};
		return element;
	}

	internal override bool CanAddChild(Node child)
	{
		return child is HTMLOptionElement
			|| child is HTMLOptGroupElement;
	}

	public void Add(Node child) => ChildNodesHelper.Add(this, child);
	public void Add(IReadOnlyList<NodeBuilder> list) => ChildNodesHelper.Add(this, list);

	public @select this[ChildNodes childNodes]
	{
		get
		{
			foreach (var action in childNodes.actions)
			{
				action(this);
			}
			return this;
		}
	}

	public class ChildNodes : IEnumerable
	{
		internal readonly List<Action<@select>> actions = new();

		public void Add(Node child) => actions.Add(@this => ChildNodesHelper.Add(@this, child));
		public void Add(IReadOnlyList<NodeBuilder> list) => actions.Add(@this => ChildNodesHelper.Add(@this, list));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}


