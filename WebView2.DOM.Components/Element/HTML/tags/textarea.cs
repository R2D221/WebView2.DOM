using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebView2.DOM.Components;

public sealed class @textarea : HTMLTextAreaElementBuilder, IEnumerable
{
	private TwoWayAttributeBuilder<string> value
	{
		get => new(() => element.value, x => element.onchange += x);
		set => element.value = value.GetConstantValue();
	}

	protected override HTMLTextAreaElement CreateElement() =>
		document.createHTMLElement(HTMLElementTag.textarea);

	internal override bool CanAddChild(Node child)
	{
		return child is Text;
	}

	public void Add(string text) => this.value = text;
	public void Add(Expression<Func<string>> text) => this.value.Add(text);

	public @textarea this[ChildNodes childNodes]
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
		internal readonly List<Action<@textarea>> actions = new();

		public void Add(string text) => actions.Add(@this => @this.value = text);
		public void Add(Expression<Func<string>> text) => actions.Add(@this => @this.value.Add(text));

		IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}


