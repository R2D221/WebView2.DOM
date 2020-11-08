namespace WebView2.DOM
{
	public partial class HTMLElement : HTMLOrForeignElement
	{
		public DOMStringMap dataset => _dataset ??= Get<DOMStringMap>();
		private DOMStringMap? _dataset;
		public string nonce { get => Get<string>(); set => Set(value); }

		public bool autofocus { get => Get<bool>(); set => Set(value); }
		public int tabIndex { get => Get<int>(); set => Set(value); }
		public void focus() => Method().Invoke();
		public void focus(FocusOptions options) => Method().Invoke(options);
		public void blur() => Method().Invoke();
	}
}
