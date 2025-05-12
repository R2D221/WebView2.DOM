using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class TypeWithExtendedAttributes
	{
		public TypeWithExtendedAttributes(Type type)
		{
			Type = type;
			ExtendedAttributes = ImmutableArray<ExtendedAttribute>.Empty;
		}

		public TypeWithExtendedAttributes(Type type, ImmutableArray<ExtendedAttribute> extendedAttributes)
		{
			Type = type;
			ExtendedAttributes = extendedAttributes;
		}

		public Type Type { get; }
		public ImmutableArray<ExtendedAttribute> ExtendedAttributes { get; }

		private string DebuggerDisplay =>
			$"{Type}";

		public override string ToString() => DebuggerDisplay;
	}
}