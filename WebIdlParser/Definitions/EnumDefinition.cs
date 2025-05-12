using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class EnumDefinition : Definition
	{
		public required string Name { get; init; }
		public required ImmutableArray<string> Values { get; init; }

		private string DebuggerDisplay =>
			$"enum {Name} {{ ... }} ;";

		public override string ToString() => DebuggerDisplay;
	}
}