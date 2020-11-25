using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class Text : CharacterData
	{
		protected internal Text(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public Text splitText(uint offset) => Method<Text>().Invoke(offset);
		public string wholeText => Get<string>();

		public HTMLSlotElement? assignedSlot => Get<HTMLSlotElement?>();
	}
}