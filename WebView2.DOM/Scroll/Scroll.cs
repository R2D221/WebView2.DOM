namespace WebView2.DOM
{
	public enum ScrollBehavior { auto, smooth }

	public enum ScrollLogicalPosition { start, center, end, nearest }

	public record ScrollOptions
	{
		public ScrollBehavior behavior { get; init; } = ScrollBehavior.auto;
	}

	public record ScrollIntoViewOptions : ScrollOptions
	{
		public ScrollLogicalPosition block { get; init; } = ScrollLogicalPosition.start;

		public ScrollLogicalPosition inline { get; init; } = ScrollLogicalPosition.nearest;
	}

	public record ScrollToOptions : ScrollOptions
	{
		public double left { get; init; } = 0;

		public double top { get; init; } = 0;
	}
}
