namespace WebView2.DOM
{
	public class Text : CharacterData
	{
		public Text splitText(uint offset) => Method<Text>().Invoke(offset);
		public string wholeText => Get<string>();

		public HTMLSlotElement? assignedSlot => Get<HTMLSlotElement?>();
	}
}