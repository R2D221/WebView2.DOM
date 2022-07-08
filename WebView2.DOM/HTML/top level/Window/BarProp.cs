namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/bar_prop.idl

	public sealed class BarProp : JsObject
	{
		private BarProp() { }

		public bool visible => Get<bool>();
	}
}