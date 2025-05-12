using System.Diagnostics;

namespace WebIdlParser
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal class ExtendedAttributeWildcard : ExtendedAttribute
	{
		private string DebuggerDisplay =>
			$"[ {Name} = * ]";

		public override string ToString() => DebuggerDisplay;
	}
}