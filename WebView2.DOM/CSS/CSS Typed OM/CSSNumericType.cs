using SmartAnalyzers.CSharpExtensions.Annotations;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/css/cssom/css_numeric_type.idl

	public enum CSSNumericBaseType
	{
		length,
		angle,
		time,
		frequency,
		resolution,
		flex,
		percent,
	};

	public record CSSNumericType
	{
#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public int length
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= default;

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public int angle
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= default;

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public int time
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= default;

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public int frequency
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= default;

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public int resolution
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= default;

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public int flex
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= default;

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public int percent
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= default;

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public CSSNumericBaseType percentHint
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= default;
	}
}
