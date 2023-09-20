using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public sealed class @table : HTMLTableElementBuilder, IEnumerable
{
	protected override HTMLTableElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.table);

	internal override bool CanAddChild(Node child)
	{
		return child is HTMLTableCaptionElement
			|| child is HTMLTableColElement
			|| child is HTMLTableSectionElement
			|| child is HTMLTableRowElement
			;
	}

	public void Add(Node child) => ChildNodesHelper.Add(this, child);
	public void Add(IEnumerable<NodeBuilder> list) => ChildNodesHelper.Add(this, list);

	public @table this[ChildNodes childNodes]
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
		internal readonly List<Action<@table>> actions = new();

		public void Add(Node child) => actions.Add(@this => ChildNodesHelper.Add(@this, child));
		public void Add(IEnumerable<NodeBuilder> list) => actions.Add(@this => ChildNodesHelper.Add(@this, list));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}


