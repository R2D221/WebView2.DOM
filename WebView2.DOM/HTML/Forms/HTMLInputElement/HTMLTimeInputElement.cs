using Microsoft.Web.WebView2.Core;
using NodaTime;
using NodaTime.Text;
using WebView2.DOM.Microsyntaxes;

namespace WebView2.DOM
{
	public class HTMLTimeInputElement : HTMLInputElementWithValueBase<LocalTime>
	{
		public HTMLTimeInputElement(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		protected override IPattern<LocalTime> Pattern => DatesAndTimes.timePattern;

		public bool readOnly { get => Get<bool>(); set => Set(value); }
		public bool required { get => Get<bool>(); set => Set(value); }
	}
}
