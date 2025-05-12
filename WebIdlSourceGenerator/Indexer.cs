using WebIdlParser;

namespace WebIdlSourceGenerator
{
	internal class Indexer
	{
		public required Getter Getter { get; init; }
		public required Setter? Setter { get; init; }
		public required Deleter? Deleter { get; init; }
	}
}
