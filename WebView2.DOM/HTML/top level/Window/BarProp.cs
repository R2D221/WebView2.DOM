using Microsoft.Web.WebView2.Core;
using SmartAnalyzers.CSharpExtensions.Annotations;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/frame/bar_prop.idl

	public class BarProp : JsObject
	{
		public bool visible => Get<bool>();
	}
}