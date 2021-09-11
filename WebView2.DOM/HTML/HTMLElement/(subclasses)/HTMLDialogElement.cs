using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLDialogElement : HTMLElement
	{
		protected internal HTMLDialogElement(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public bool open { get => Get<bool>(); set => Set(value); }
		public string returnValue { get => Get<string>(); set => Set(value); }
		public void show() => Method().Invoke();
		public void showModal() => Method().Invoke();
		public void close() => Method().Invoke();
		public void close(string returnValue) => Method().Invoke(returnValue);
	}
}
