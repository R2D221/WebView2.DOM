using System;
using System.Text.Json;

namespace WebView2.DOM
{
	public sealed class HTMLEmbedElement : HTMLElement
	{
		private HTMLEmbedElement() { }

		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public uint width { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public uint height { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public Document? getSVGDocument() => Method<Document?>().Invoke();
	}
}
