namespace WebIdlParser
{
	internal sealed class Octet : Type
	{
		private Octet() : base("octet") { }

		public static Octet Instance { get; } = new();
	}
}