using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class AsyncIterable : Member
	{
		public required ImmutableArray<TypeWithExtendedAttributes> TypeArguments { get; init; }
		public required ImmutableArray<Argument>? Arguments { get; init; }

		private string DebuggerDisplay =>
			$"async iterable < {string.Join(" , ", TypeArguments)} > {Arguments switch { null => "", var x => $"( {string.Join(" , ", x)} ) " }};";

		public override string ToString() => DebuggerDisplay;
	}
}