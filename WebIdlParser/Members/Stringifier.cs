using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class Stringifier : Member
	{
		public static Stringifier Instance { get; } = new();

		private Stringifier() { }

		private string DebuggerDisplay =>
			$"stringifier ;";

		public override string ToString() => DebuggerDisplay;
	}
}