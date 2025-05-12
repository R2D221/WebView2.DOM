using System.Collections.Immutable;

namespace WebIdlParser
{
	internal abstract class DictionaryMember
	{
		public required ImmutableArray<ExtendedAttribute> ExtendedAttributes { get; init; }
		public required TypeWithExtendedAttributes Type { get; init; }
		public required string Name { get; init; }
	}

	internal sealed class RequiredDictionaryMember : DictionaryMember { }
	internal sealed class OptionalDictionaryMember : DictionaryMember
	{
		public required string? DefaultValue { get; init; }
	}
}