using SmartAnalyzers.CSharpExtensions.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;

namespace WebView2.DOM
{
	public record SrcSetItem
	{
		[InitOnly]
		public Uri src
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}

#if !NET5_0_OR_GREATER
		[InitOnlyOptional]
#endif
		public int? width
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
		public double? density
		{
			get;
#if NET5_0_OR_GREATER
			init;
#else
			set;
#endif
		}
			= default;

		public static IReadOnlyList<SrcSetItem> Parse(string value) =>
			value.Split(',')
			.Select(item => item.Trim())
			.Select(item => item.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries))
			.Select(parts => new SrcSetItem
			{
				src = new Uri(parts[0], UriKind.RelativeOrAbsolute),
				width =
					parts.Length > 1 && parts[1].EndsWith("w") ? int.Parse(parts[1][0..^1], NumberStyles.None, CultureInfo.InvariantCulture) :
					default(int?),
				density =
					parts.Length > 2 && parts[2].EndsWith("x") ? double.Parse(parts[2][0..^1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture) :
					parts.Length > 1 && parts[1].EndsWith("x") ? double.Parse(parts[1][0..^1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture) :
					default(double?),
			})
			.ToImmutableArray();

		public static string ToString(IReadOnlyList<SrcSetItem> value) =>
			string.Join(",",
				value.Select(item => new[]
				{
					item.src.ToString(),
					item.width?.ToString(CultureInfo.InvariantCulture),
					item.density?.ToString(CultureInfo.InvariantCulture)
				}.Where(x => x != null))
				.Select(parts => string.Join(' ', parts))
			);
	}
}
