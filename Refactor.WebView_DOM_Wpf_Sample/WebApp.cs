using static Refactor.WebView2.DOM.Window;

namespace Refactor.WebView2_DOM_Wpf_Sample;

internal static class WebApp
{
	internal static void DOMContentLoaded()
	{
		var document = window.document;

		_ = window.sendTest(document);
	}
}
