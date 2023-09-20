using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebView2.DOM.Components;

public sealed class @datalist : HTMLDataListElementBuilder, IEnumerable
{
	protected override HTMLDataListElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.datalist);

	internal override bool CanAddChild(Node child)
	{
		var extraThis = NodeExtraInfo.For(this);
		var extraChild = NodeExtraInfo.For(child);

		if (extraThis.ChildNodes.Any() == false)
		{
			return child is HTMLOptionElement
				|| extraChild.IsPhrasingContent;
		}
		else if (extraThis.ChildNodes.First() is HTMLOptionElement)
		{
			return child is HTMLOptionElement;
		}
		else
		{
			return extraChild.IsPhrasingContent;
		}
	}

	public void Add(string text) => ChildNodesHelper.Add(this, text);
	public void Add(Func<string> text) => ChildNodesHelper.Add(this, text);
	public void Add(Node child) => ChildNodesHelper.Add(this, child);
	public void Add(IEnumerable<NodeBuilder> list) => ChildNodesHelper.Add(this, list);

	public @datalist this[ChildNodes childNodes]
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
		internal readonly List<Action<@datalist>> actions = new();

		public void Add(string text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Func<string> text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Node child) => actions.Add(@this => ChildNodesHelper.Add(@this, child));
		public void Add(IEnumerable<NodeBuilder> list) => actions.Add(@this => ChildNodesHelper.Add(@this, list));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}


