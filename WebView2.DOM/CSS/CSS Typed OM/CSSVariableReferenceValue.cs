using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_variable_reference_value.idl

	public class CSSVariableReferenceValue : CSSStyleValue
	{
		protected internal CSSVariableReferenceValue(CoreWebView2 coreWebView, string referenceId) : base(coreWebView, referenceId)
		{
		}

		public CSSVariableReferenceValue(string variable)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(variable);
		public CSSVariableReferenceValue(string variable, CSSUnparsedValue fallback)
			: this(window.Instance.coreWebView, System.Guid.NewGuid().ToString()) =>
			Construct(variable, fallback);

		public string variable { get => Get<string>(); set => Set(value); }
		public CSSUnparsedValue? fallback => Get<CSSUnparsedValue?>();
	}
}
