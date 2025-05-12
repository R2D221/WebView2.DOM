namespace WebIdlParser
{
	internal sealed class Symbol : Type
	{
		private Symbol() : base("symbol") { }

		public static Symbol Instance { get; } = new();
	}
}