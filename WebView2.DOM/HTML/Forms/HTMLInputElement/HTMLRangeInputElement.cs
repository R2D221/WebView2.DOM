using Microsoft.Web.WebView2.Core;
using NodaTime.Text;
using System;
using System.Text.Json;

namespace WebView2.DOM
{
	public class HTMLRangeInputElement : HTMLInputElementWithValueBase<double>
	{
		public HTMLRangeInputElement(CoreWebView2 coreWebView, string referenceId)
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
	}
}
