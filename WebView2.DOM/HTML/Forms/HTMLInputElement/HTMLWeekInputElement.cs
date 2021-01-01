using Microsoft.Web.WebView2.Core;
using NodaTime.Text;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	public class HTMLWeekInputElement : HTMLInputElementWithValueBase<IsoWeek>
	{
		public HTMLWeekInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		protected override IPattern<IsoWeek> Pattern => DatesAndTimes.weekPattern;

		public bool readOnly { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
	}
}
