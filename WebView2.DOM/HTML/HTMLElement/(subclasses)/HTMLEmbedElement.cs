using Microsoft.Web.WebView2.Core;
using System;
using System.Text.Json;

namespace WebView2.DOM
{
	public class HTMLEmbedElement : HTMLElement
	{
		protected internal HTMLEmbedElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Uri src { get => Get<Uri>(); set => Set(value); }
		public string type { get => Get<string>(); set => Set(value); }
		public uint width { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public uint height { get => JsonSerializer.Deserialize<uint>(Get<string>()); set => Set(JsonSerializer.Serialize(value)); }
		public Document? getSVGDocument() => Method<Document?>().Invoke();
	}
}
