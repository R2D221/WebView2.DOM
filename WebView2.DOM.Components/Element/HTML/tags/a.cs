using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public sealed class @a : HTMLAnchorElementBuilder, IEnumerable
{
	protected override HTMLAnchorElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.a);

	internal override bool CanAddChild(Node child)
	{
		var extraChild = NodeExtraInfo.For(child);

		return (extraChild.ContainsInteractiveContent == false)
			&& (extraChild.ContainsA == false)
			// && descendants don't have tabindex
			;
	}

	public void Add(string text) => ChildNodesHelper.Add(this, text);
	public void Add(Func<string> text) => ChildNodesHelper.Add(this, text);
	public void Add(Node child) => ChildNodesHelper.Add(this, child);
	public void Add(IReadOnlyList<NodeBuilder> list) => ChildNodesHelper.Add(this, list);

	public @a this[ChildNodes childNodes]
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
		internal readonly List<Action<@a>> actions = new();

		public void Add(string text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Func<string> text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Node child) => actions.Add(@this => ChildNodesHelper.Add(@this, child));
		public void Add(IReadOnlyList<NodeBuilder> list) => actions.Add(@this => ChildNodesHelper.Add(@this, list));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}
