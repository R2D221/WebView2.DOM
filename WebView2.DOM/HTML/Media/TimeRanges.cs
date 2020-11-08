using Savage.Range;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/time_ranges.idl

	public class TimeRanges : JsObject
	{
		public uint length => Get<uint>();
		public double start(uint index) => Method<double>().Invoke(index);
		public double end(uint index) => Method<double>().Invoke(index);

		public ImmutableArray<Range<TimeSpan>> ToImmutableArray() =>
			Enumerable.Range(0, (int)length)
			.Select(i => (uint)i)
			.Select(i => new Range<TimeSpan>(TimeSpan.FromSeconds(start(i)), TimeSpan.FromSeconds(end(i))))
			.ToImmutableArray();
	}
}