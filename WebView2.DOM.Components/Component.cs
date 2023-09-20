using System;

namespace WebView2.DOM.Components;

public abstract class Component : NodeBuilder
{
	private readonly Lazy<Node> node;
	protected sealed override Node Node => node.Value;

	protected Component()
	{
		this.node = new(() => Render());
	}

	protected abstract Node Render();
	internal sealed override bool CanAddChild(Node child) => false;
}
