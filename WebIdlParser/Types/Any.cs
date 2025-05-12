namespace WebIdlParser
{
	internal sealed class Any : Type
	{
		private Any() : base("any") { }

		public static Any Instance { get; } = new();
	}
}