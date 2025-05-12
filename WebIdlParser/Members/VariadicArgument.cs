using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class VariadicArgument : Argument
	{
		protected override string DebuggerDisplay =>
			$"[ {string.Join(" , ", ExtendedAttributes)} ] {Type} ... {Name}";

		public override string ToString() => DebuggerDisplay;
	}
}