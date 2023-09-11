namespace WebView2.DOM.Components;

public abstract class NodeBuilder
{
	public sealed override bool Equals(object? obj) => base.Equals(obj);
	public sealed override int GetHashCode() => base.GetHashCode();
	public sealed override string? ToString() => base.ToString();

	public static Document document { get; set; } = window.document;

	protected abstract Node Node { get; }

	public static implicit operator Node(NodeBuilder builder) => builder.Node;

	internal abstract bool CanAddChild(Node child);
}
