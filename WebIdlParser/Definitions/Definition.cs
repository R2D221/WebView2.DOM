using System.Collections.Immutable;

namespace WebIdlParser
{
	internal class Definition
	{
		public ImmutableArray<ExtendedAttribute> ExtendedAttributes { get; set; } =
			ImmutableArray<ExtendedAttribute>.Empty;
	}
}