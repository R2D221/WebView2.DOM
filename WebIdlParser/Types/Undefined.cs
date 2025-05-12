namespace WebIdlParser
{
	internal sealed class Undefined : Type
	{
		private Undefined() : base("undefined") { }

		public static Undefined Instance { get; } = new();
	}
}