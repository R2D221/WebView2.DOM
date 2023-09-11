namespace WebView2.DOM.Components;

public abstract class Component : NodeBuilder
{
	private readonly Node node;
	protected sealed override Node Node => node;

	protected Component()
	{
		this.node = Render();
	}

	protected abstract Node Render();
}
