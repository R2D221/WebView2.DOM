using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class InheritAttribute : Attribute
	{
		protected override string DebuggerDisplay =>
			$"inherit {base.DebuggerDisplay}";

		public override string ToString() => DebuggerDisplay;
	}
}