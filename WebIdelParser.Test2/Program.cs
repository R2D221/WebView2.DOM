global using p = WebIdelParser.Test2.Program;
using WebView2.DOM;

namespace WebIdelParser.Test2;

internal class Program
{
	static void Main(string[] args)
	{
		//global::OneOf.OneOf<int, string> x;
		_ = typeof(global::WebView2.DOM.SubmitEvent);
		_ = typeof(global::WebView2.DOM.FormDataEvent);
	}
}
