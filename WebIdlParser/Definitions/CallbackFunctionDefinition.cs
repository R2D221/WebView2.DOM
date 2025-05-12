using System.Collections.Immutable;
using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class CallbackFunctionDefinition : Definition
	{
		public required string Name { get; init; }
		public required Type ReturnType { get; init; }
		public required ImmutableArray<Argument> Arguments { get; init; }

		private string DebuggerDisplay =>
			$"callback {Name} = {ReturnType} ( {string.Join(" , ", Arguments)} ) ;";

		public override string ToString() => DebuggerDisplay;
	}
}