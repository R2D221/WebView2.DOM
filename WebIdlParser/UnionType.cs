using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class UnionType : Type
	{
		public UnionType()
			: base("(union)") { }

		public required ImmutableArray<TypeWithExtendedAttributes> Types { get; init; }
	}
}
