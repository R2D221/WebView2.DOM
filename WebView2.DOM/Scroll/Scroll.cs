using System.Text.Json.Serialization;

namespace WebView2.DOM
{
	public enum ScrollBehavior { auto, smooth }

	public enum ScrollLogicalPosition { start, center, end, nearest }

	[JsonConverter(typeof(Converter))]
	public record ScrollOptions : JsDictionary
	{
		private class Converter : Converter<ScrollOptions> { }

		public ScrollBehavior behavior
		{
			get => Get<ScrollBehavior>(defaultValue: ScrollBehavior.auto);
			init => Set(value);
		}
	}

	[JsonConverter(typeof(Converter))]
	public record ScrollIntoViewOptions : ScrollOptions
	{
		private class Converter : Converter<ScrollIntoViewOptions> { }

		public ScrollLogicalPosition block
		{
			get => Get<ScrollLogicalPosition>(defaultValue: ScrollLogicalPosition.start);
			init => Set(value);
		}

		public ScrollLogicalPosition inline
		{
			get => Get<ScrollLogicalPosition>(defaultValue: ScrollLogicalPosition.nearest);
			init => Set(value);
		}
	}

	[JsonConverter(typeof(Converter))]
	public record ScrollToOptions : ScrollOptions
	{
		private class Converter : Converter<ScrollToOptions> { }

		public double left
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}

		public double top
		{
			get => Get<double>(defaultValue: 0);
			init => Set(value);
		}
	}
}
