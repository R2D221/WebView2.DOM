namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/html_progress_element.idl

	public sealed class HTMLProgressElement : HTMLElement, ILabelableElement
	{
		private HTMLProgressElement() { }

		public double value { get => Get<double>(); set => Set(value); }
		public double max { get => Get<double>(); set => Set(value); }
		public double position => Get<double>();
		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();
	}
}
