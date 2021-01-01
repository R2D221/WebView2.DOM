using Microsoft.Web.WebView2.Core;

namespace WebView2.DOM
{
	public abstract class HTMLInputElementWithSelectableTextBase : HTMLInputElementWithTextBase
	{
		protected internal HTMLInputElementWithSelectableTextBase(CoreWebView2 coreWebView, string referenceId)
			: base(coreWebView, referenceId) { }

		public void select() => Method().Invoke();
		public uint selectionStart { get => Get<uint>(); set => Set(value); }
		public uint selectionEnd { get => Get<uint>(); set => Set(value); }
		public SelectionDirection selectionDirection { get => Get<SelectionDirection>(); set => Set(value); }
		public void setRangeText(string replacement) => Method().Invoke(replacement);
		public void setRangeText(string replacement, uint start, uint end) =>
			Method().Invoke(replacement, start, end);
		public void setRangeText(string replacement, uint start, uint end, SelectionMode selectionMode) =>
			Method().Invoke(replacement, start, end, selectionMode);
		public void setSelectionRange(uint start, uint end) =>
			Method().Invoke(start, end);
		public void setSelectionRange(uint start, uint end, SelectionDirection direction) =>
			Method().Invoke(start, end, direction);
	}
}
