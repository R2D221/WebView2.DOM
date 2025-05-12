namespace WebIdlParser
{
	internal sealed class DOMString : Type
	{
		private DOMString() : base("DOMString") { }

		public static DOMString Instance { get; } = new();
	}
}