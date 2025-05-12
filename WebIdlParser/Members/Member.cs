using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Member
	{
		public ImmutableArray<ExtendedAttribute> ExtendedAttributes { get; set; } =
			ImmutableArray<ExtendedAttribute>.Empty;
	}
}