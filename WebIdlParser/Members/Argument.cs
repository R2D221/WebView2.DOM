using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Argument
	{
		public required TypeWithExtendedAttributes Type { get; init; }
		public required string Name { get; init; }
		public required ImmutableArray<ExtendedAttribute> ExtendedAttributes { get; init; }

		protected virtual string DebuggerDisplay =>
			$"{Type} {Name}";

		public override string ToString() => DebuggerDisplay;
	}
}