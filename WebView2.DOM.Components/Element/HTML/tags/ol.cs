using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public sealed class @ol : HTMLOListElementBuilder, IEnumerable
{
	protected override HTMLOListElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.ol);

	internal override bool CanAddChild(Node child)
	{
		return child is HTMLLIElement; // or script or template
	}

	public void Add(Node child) => ChildNodesHelper.Add(this, child);
	public void Add(IEnumerable<NodeBuilder> list) => ChildNodesHelper.Add(this, list);

	public @ol this[ChildNodes childNodes]
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
		internal readonly List<Action<@ol>> actions = new();

		public void Add(Node child) => actions.Add(@this => ChildNodesHelper.Add(@this, child));
		public void Add(IEnumerable<NodeBuilder> list) => actions.Add(@this => ChildNodesHelper.Add(@this, list));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}


