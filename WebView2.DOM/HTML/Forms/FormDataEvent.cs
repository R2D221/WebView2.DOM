using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/form_data_event.idl

	public class FormDataEvent : Event
	{
		protected internal FormDataEvent(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public FormData formData => Get<FormData>();
	}
}
