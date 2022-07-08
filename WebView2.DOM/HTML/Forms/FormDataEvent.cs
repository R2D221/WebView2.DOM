namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/form_data_event.idl

	public sealed class FormDataEvent : Event
	{
		private FormDataEvent() { }

		public FormData formData => Get<FormData>();
	}
}
