using Microsoft.Web.WebView2.Core;
using NodaTime;
using NodaTime.Text;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	public class HTMLMonthInputElement : HTMLInputElementWithValueBase<YearMonth>
	{
		public HTMLMonthInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		protected override IPattern<YearMonth> Pattern => DatesAndTimes.monthPattern;

		public bool readOnly { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
	}
}
