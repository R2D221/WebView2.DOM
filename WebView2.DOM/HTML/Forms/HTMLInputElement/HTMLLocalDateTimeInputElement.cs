using Microsoft.Web.WebView2.Core;
using NodaTime;
using NodaTime.Text;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	public class HTMLLocalDateTimeInputElement : HTMLInputElementWithValueBase<LocalDateTime>
	{
		public HTMLLocalDateTimeInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		protected override IPattern<LocalDateTime> Pattern => DatesAndTimes.localDateAndTimePattern;

		public bool readOnly { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
	}
}
