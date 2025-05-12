using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Constructor : Member
	{
		public required ImmutableArray<Argument> Arguments { get; init; }

		private string DebuggerDisplay =>
			$"constructor ( {string.Join(" , ", Arguments)} ) ;";

		public override string ToString() => DebuggerDisplay;
	}
}