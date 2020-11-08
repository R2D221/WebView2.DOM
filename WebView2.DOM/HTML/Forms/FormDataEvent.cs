namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/forms/form_data_event.idl

	public class FormDataEvent : Event
	{
		public FormData formData => Get<FormData>();
	}
}
