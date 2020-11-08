namespace WebView2.DOM
{
	public enum ScrollBehavior { auto, smooth }

	public enum ScrollLogicalPosition { start, center, end, nearest }

	public class ScrollOptions
	{
		public ScrollBehavior behavior { get; set; }
	}

	public sealed class ScrollIntoViewOptions : ScrollOptions
	{
		public ScrollLogicalPosition block { get; set; } = ScrollLogicalPosition.start;
		public ScrollLogicalPosition inline { get; set; } = ScrollLogicalPosition.nearest;
	}

	public sealed class ScrollToOptions : ScrollOptions
	{
		public double left { get; set; }
		public double top { get; set; }
	}
}
