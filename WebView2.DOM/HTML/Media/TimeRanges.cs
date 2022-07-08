using NodaTime;
using Savage.Range;
using System.Collections.Immutable;
using System.Linq;

namespace WebView2.DOM
{
	// https://github.com/chromium/chromium/blob/master/third_party/blink/renderer/core/html/time_ranges.idl

	public sealed class TimeRanges : JsObject
	{
		private TimeRanges() { }

		public uint length => Get<uint>();
		public double start(uint index) => Method<double>().Invoke(index);
		public double end(uint index) => Method<double>().Invoke(index);

		public ImmutableArray<Range<Duration>> ToImmutableArray() =>
			Enumerable.Range(0, (int)length)
			.Select(i => (uint)i)
			.Select(i => new Range<Duration>(Duration.FromSeconds(start(i)), Duration.FromSeconds(end(i))))
			.ToImmutableArray();
	}
}