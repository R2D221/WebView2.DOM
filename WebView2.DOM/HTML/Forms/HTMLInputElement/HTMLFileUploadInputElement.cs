using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public class HTMLFileUploadInputElement : HTMLInputElement
	{
		protected internal HTMLFileUploadInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string accept { get => Get<string>(); set => Set(value); }
		public bool multiple { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
		public FileList files { get => Get<FileList>(); set => Set(value); }

		// HTML Media Capture
		public FileUploadCapture capture { get => Get<FileUploadCapture>(); set => Set(value); }
	}

	public enum FileUploadCapture
	{
		_, user, environment
	}
}
