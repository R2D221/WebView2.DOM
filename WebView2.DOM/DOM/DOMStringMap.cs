namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/dom_string_map.idl

	public sealed class DOMStringMap : JsObject
	{
		private DOMStringMap() { }

		public string this[string name]
		{
			get => IndexerGet<string>(name);
			set => IndexerSet(name, value);
		}

		public void Remove(string name) => IndexerDelete(name);
	}
}
