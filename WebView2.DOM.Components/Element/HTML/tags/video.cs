using System;
using System.Collections;
using System.Collections.Generic;

namespace WebView2.DOM.Components;

public sealed class @video : HTMLVideoElementBuilder, IEnumerable
{
	protected override HTMLVideoElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.video);

	internal override bool CanAddChild(Node child)
	{
		if (element.src.OriginalString is null or "")
		{
			if (child is HTMLSourceElement) { return true; }
		}

		if (child is HTMLTrackElement) { return true; }

		var extraChild = NodeExtraInfo.For(child);

		return extraChild.ContainsMediaElements == false;
	}

	public void Add(string text) => ChildNodesHelper.Add(this, text);
	public void Add(Func<string> text) => ChildNodesHelper.Add(this, text);
	public void Add(Node child) => ChildNodesHelper.Add(this, child);
	public void Add(IEnumerable<NodeBuilder> list) => ChildNodesHelper.Add(this, list);

	public @video this[ChildNodes childNodes]
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
		internal readonly List<Action<@video>> actions = new();

		public void Add(string text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Func<string> text) => actions.Add(@this => ChildNodesHelper.Add(@this, text));
		public void Add(Node child) => actions.Add(@this => ChildNodesHelper.Add(@this, child));
		public void Add(IEnumerable<NodeBuilder> list) => actions.Add(@this => ChildNodesHelper.Add(@this, list));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}


