using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Iterable : Member
	{
		public required ImmutableArray<TypeWithExtendedAttributes> TypeArguments { get; init; }

		private string DebuggerDisplay =>
			$"iterable < {string.Join(" , ", TypeArguments)} > ;";

		public override string ToString() => DebuggerDisplay;
	}
}