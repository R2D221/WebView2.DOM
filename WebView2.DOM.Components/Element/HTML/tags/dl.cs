using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public sealed class @dl : HTMLDListElementBuilder, IEnumerable
{
	protected override HTMLDListElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.dl);

	internal override bool CanAddChild(Node child)
	{
		return child is HTMLElement { tagName: "DT" or "DD" };

		// optionally intermixed with <script> and <template> elements.
	}

	public void Add(Node child) => ChildNodesHelper.Add(this, child);
	public void Add(IEnumerable<NodeBuilder> list) => ChildNodesHelper.Add(this, list);

	public @dl this[ChildNodes childNodes]
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
		internal readonly List<Action<@dl>> actions = new();

		public void Add(Node child) => actions.Add(@this => ChildNodesHelper.Add(@this, child));
		public void Add(IEnumerable<NodeBuilder> list) => actions.Add(@this => ChildNodesHelper.Add(@this, list));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}


