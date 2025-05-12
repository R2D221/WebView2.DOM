using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class StringifierAttribute : Attribute
	{
		private new string DebuggerDisplay =>
			$"stringifier {base.DebuggerDisplay}";

		public override string ToString() => DebuggerDisplay;
	}
}