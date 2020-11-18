using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/css_media_rule.idl

	public class CSSMediaRule : CSSConditionRule
	{
		public MediaList media => _media ??= Get<MediaList>();
		private MediaList? _media;
	}
}
