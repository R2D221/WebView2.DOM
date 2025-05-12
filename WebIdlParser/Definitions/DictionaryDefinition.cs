using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class DictionaryDefinition : Definition
	{
		public required string Name { get; init; }
		public required string? Inheritance { get; init; }
		public required ImmutableArray<DictionaryMember> Members { get; init; }

		private string DebuggerDisplay =>
			$"dictionary {Name}{Inheritance switch { null => "", var x => $" : {x}" }} {{ ... }} ;";

		public override string ToString() => DebuggerDisplay;
	}
}