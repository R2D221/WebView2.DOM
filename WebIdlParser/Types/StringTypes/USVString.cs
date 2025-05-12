namespace WebIdlParser
{
	internal sealed class USVString : Type
	{
		private USVString() : base("USVString") { }

		public static USVString Instance { get; } = new();
	}
}