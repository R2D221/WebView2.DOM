using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class GenericType : Type
	{
		public ImmutableArray<TypeWithExtendedAttributes> TypeParameters { get; }

		public GenericType(string name, TypeWithExtendedAttributes type) : base(name)
		{
			TypeParameters = ImmutableArray.Create(type);
		}

		public GenericType(string name, TypeWithExtendedAttributes type0, TypeWithExtendedAttributes type1) : base(name)
		{
			TypeParameters = ImmutableArray.Create(type0, type1);
		}

		public GenericType(string name, TypeWithExtendedAttributes type0, TypeWithExtendedAttributes type1, TypeWithExtendedAttributes type2) : base(name)
		{
			TypeParameters = ImmutableArray.Create(type0, type1, type2);
		}

		public GenericType(string name, params TypeWithExtendedAttributes[] types) : base(name)
		{
			TypeParameters = types.ToImmutableArray();
		}

		public GenericType(string name, ImmutableArray<TypeWithExtendedAttributes> types) : base(name)
		{
			TypeParameters = types;
		}

		protected override string DebuggerDisplay =>
			$"{Name} < {string.Join(" , ", TypeParameters)} >{IsNullable switch { true => " ?", false => "" }}";

		public override string ToString() => DebuggerDisplay;
	}
}