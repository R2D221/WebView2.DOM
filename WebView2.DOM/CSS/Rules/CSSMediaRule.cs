namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_media_rule.idl

	public sealed class CSSMediaRule : CSSConditionRule
	{
		private CSSMediaRule() { }

		public MediaList media => _media ??= Get<MediaList>();
		private MediaList? _media;
	}
}
