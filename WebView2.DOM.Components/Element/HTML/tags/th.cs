using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public sealed class @th : HTMLTableCellElementBuilder, IEnumerable
{
	/// <summary>
	/// Specifies which cells the header cell applies to
	/// </summary>
	public AttributeBuilder<TableHeaderCellScope> scope
	{
		get => new(value => element.scope = value);
		set => element.scope = value.GetConstantValue();
	}

	/// <summary>
	/// Alternative label to use for the header cell when referencing the cell in other contexts
	/// </summary>
	public AttributeBuilder<string> abbr
	{
		get => new(value => element.abbr = value);
		set => element.abbr = value.GetConstantValue();
	}

	protected override HTMLTableCellElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.th);

	internal override bool CanAddChild(Node child)
	{
		var extraChild = NodeExtraInfo.For(child);
		return extraChild.IsFlowContent
			&& (extraChild.ContainsHeader is false)
			&& (extraChild.ContainsFooter is false)
			&& (extraChild.ContainsSectioningContent is false)
			&& (extraChild.ContainsHeadingContent is false)
			;
	}

	public void Add(string text) => ChildNodesHelper.Add(this, text);
	public void Add(Func<string> text) => ChildNodesHelper.Add(this, text);
	public void Add(Node child) => ChildNodesHelper.Add(this, child);
	public void Add(IReadOnlyList<NodeBuilder> list) => ChildNodesHelper.Add(this, list);

	public @th this[ChildNodes childNodes]
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
		internal readonly List<Action<@th>> actions = new();

		public void Add(string text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Func<string> text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Node child) => actions.Add(@this => ChildNodesHelper.Add(@this, child));
		public void Add(IReadOnlyList<NodeBuilder> list) => actions.Add(@this => ChildNodesHelper.Add(@this, list));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}


