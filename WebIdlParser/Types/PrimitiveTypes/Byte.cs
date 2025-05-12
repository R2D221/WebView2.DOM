namespace WebIdlParser
{
	internal sealed class Byte : Type
	{
		private Byte() : base("byte") { }

		public static Byte Instance { get; } = new();
	}
}