using SmartAnalyzers.CSharpExtensions.Annotations;

namespace WebView2.DOM
{
	public enum ScrollBehavior { auto, smooth }

	public enum ScrollLogicalPosition { start, center, end, nearest }

	public record ScrollOptions
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public ScrollBehavior behavior
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= ScrollBehavior.auto;
	}

	public record ScrollIntoViewOptions : ScrollOptions
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public ScrollLogicalPosition block
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= ScrollLogicalPosition.start;

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public ScrollLogicalPosition inline
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= ScrollLogicalPosition.nearest;
	}

	public record ScrollToOptions : ScrollOptions
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public double left
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= 0;

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public double top
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= 0;
	}
}
