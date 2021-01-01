using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public abstract class HTMLInputElementWithTextBase : HTMLInputElement
	{
		protected internal HTMLInputElementWithTextBase(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public string autocomplete { get => Get<string>(); set => Set(value); }
		public int minLength { get => Get<int>(); set => Set(value); }
		public int maxLength { get => Get<int>(); set => Set(value); }
		public string pattern { get => Get<string>(); set => Set(value); }
		public string placeholder { get => Get<string>(); set => Set(value); }
		public bool readOnly { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
		public uint size { get => Get<uint>(); set => Set(value); }
	}
}
