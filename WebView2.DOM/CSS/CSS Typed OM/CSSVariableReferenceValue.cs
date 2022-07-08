using Microsoft.Web.WebView2.Core;
using System;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_variable_reference_value.idl

	public class CSSVariableReferenceValue : CSSStyleValue
	{
		protected internal CSSVariableReferenceValue() { }

		public CSSVariableReferenceValue(string variable) =>
			Construct(variable);
		public CSSVariableReferenceValue(string variable, CSSUnparsedValue fallback) =>
			Construct(variable, fallback);

		public string variable { get => Get<string>(); set => Set(value); }
		public CSSUnparsedValue? fallback => Get<CSSUnparsedValue?>();
	}
}
