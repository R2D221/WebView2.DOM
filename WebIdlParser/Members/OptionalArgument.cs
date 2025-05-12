using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class OptionalArgument : Argument
	{
		public required string? DefaultValue { get; init; }

		protected override string DebuggerDisplay =>
			$"{base.DebuggerDisplay} = {DefaultValue}";

		public override string ToString() => DebuggerDisplay;
	}
}