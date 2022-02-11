namespace WebView2.Markup
{
	public sealed class Attr
	{
		public string? namespaceURI { get; init; }
		public string? prefix { get; init; }
		public string localName { get; init; } = "";
		public string qualifiedName => prefix is null ? localName : $"{prefix}:{localName}";
		public string value { get; init; } = "";
	}
}
