using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebView2.DOM.Components;

public sealed class @fieldset : HTMLFieldSetElementBuilder, IEnumerable
{
	protected override HTMLFieldSetElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.fieldset);

	internal override bool CanAddChild(Node child)
	{
		var extraThis = NodeExtraInfo.For(this);
		var extraChild = NodeExtraInfo.For(child);

		if (extraThis.ChildNodes.Any() == false)
		{
			return child is HTMLElement { tagName: "LEGEND" }
				|| extraChild.IsFlowContent;
		}
		else
		{
			return extraChild.IsFlowContent;
		}
	}

	public void Add(string text) => ChildNodesHelper.Add(this, text);
	public void Add(Func<string> text) => ChildNodesHelper.Add(this, text);
	public void Add(Node child) => ChildNodesHelper.Add(this, child);
	public void Add(IReadOnlyList<NodeBuilder> list) => ChildNodesHelper.Add(this, list);

	public @fieldset this[ChildNodes childNodes]
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
		internal readonly List<Action<@fieldset>> actions = new();

		public void Add(string text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Func<string> text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Node child) => actions.Add(@this => ChildNodesHelper.Add(@this, child));
		public void Add(IReadOnlyList<NodeBuilder> list) => actions.Add(@this => ChildNodesHelper.Add(@this, list));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}


