namespace WebView2.DOM
{
	public sealed class HTMLDialogElement : HTMLElement
	{
		private HTMLDialogElement() { }

		public bool open { get => Get<bool>(); set => Set(value); }
		public string returnValue { get => Get<string>(); set => Set(value); }
		public void show() => Method().Invoke();
		public void showModal() => Method().Invoke();
		public void close() => Method().Invoke();
		public void close(string returnValue) => Method().Invoke(returnValue);
	}
}
