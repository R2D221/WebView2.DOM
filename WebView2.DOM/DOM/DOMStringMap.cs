namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/dom/dom_string_map.idl

	public class DOMStringMap : JsObject
	{
		public string this[string name]
		{
			get => IndexerGet<string>(name);
			set => IndexerSet(name, value);
		}

		public void Remove(string name) => IndexerDelete(name);
	}
}
