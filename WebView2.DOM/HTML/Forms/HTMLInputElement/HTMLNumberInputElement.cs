using Microsoft.Web.WebView2.Core;
using NodaTime.Text;
using System;
using System.Text.Json;

namespace WebView2.DOM
{
	public class HTMLNumberInputElement : HTMLInputElementWithValueBase<double>
	{
		public HTMLNumberInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		protected override IPattern<double> Pattern => new Pattern<double>
		{
			AppendFormat = null!,
			Format = value => JsonSerializer.Serialize(value),
			Parse = text =>
			{
				try
				{
					return ParseResult<double>.ForValue(JsonSerializer.Deserialize<double>(text));
				}
				catch (Exception ex)
				{
					return ParseResult<double>.ForException(() => ex);
				}
			},
		};

		public string placeholder { get => Get<string>(); set => Set(value); }
		public bool readOnly { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
	}
}
