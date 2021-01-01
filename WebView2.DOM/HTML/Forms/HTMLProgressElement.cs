using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/html_progress_element.idl

	public class HTMLProgressElement : HTMLElement, ILabelableElement
	{
		protected internal HTMLProgressElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public double value { get => Get<double>(); set => Set(value); }
		public double max { get => Get<double>(); set => Set(value); }
		public double position => Get<double>();
		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();
	}
}
