namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/html_meter_element.idl

	public sealed class HTMLMeterElement : HTMLElement, ILabelableElement
	{
		private HTMLMeterElement() { }

		public double value { get => Get<double>(); set => Set(value); }
		public double min { get => Get<double>(); set => Set(value); }
		public double max { get => Get<double>(); set => Set(value); }
		public double low { get => Get<double>(); set => Set(value); }
		public double high { get => Get<double>(); set => Set(value); }
		public double optimum { get => Get<double>(); set => Set(value); }
		public NodeList<HTMLLabelElement> labels => Get<NodeList<HTMLLabelElement>>();
	}
}
