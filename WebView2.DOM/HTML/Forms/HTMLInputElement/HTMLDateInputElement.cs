using Microsoft.Web.WebView2.Core;
using NodaTime;
using NodaTime.Text;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	public class HTMLDateInputElement : HTMLInputElementWithValueBase<LocalDate>
	{
		public HTMLDateInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		protected override IPattern<LocalDate> Pattern => DatesAndTimes.datePattern;

		public bool readOnly { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
	}
}
