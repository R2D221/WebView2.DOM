namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/character_data.idl

	public partial class CharacterData : Node
	{
		private protected CharacterData() { }

		public string data
		{
			get => Get<string>();
			set => Set(value);
		}

		public uint length => Get<uint>();

		public string substringData(uint offset, uint count) => Method<string>().Invoke(offset, count);

		public void appendData(string data) => Method().Invoke(data);

		public void insertData(uint offset, string data) => Method().Invoke(offset, data);
		public void deleteData(uint offset, uint count) => Method().Invoke(offset, count);
		public void replaceData(uint offset, uint count, string data) => Method().Invoke(offset, count, data);
	}
}