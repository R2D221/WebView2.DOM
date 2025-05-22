using Refactor.WebView2.DOM.Interop;

namespace Refactor.WebView2.DOM;

public sealed class Window : EventTarget
{
	public static Window window => BrowsingContext.GlobalObject.GetCached<Window>("window");

	private Window() { }

	public string? prompt(string message = "", string defaultValue = "")
	{
		//=> Method<string?>().Invoke(message, defaultValue);
		return JS.Invoke(message, defaultValue);
	}
}
