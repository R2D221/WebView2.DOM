namespace WebIdlParser
{
	internal sealed class Boolean : Type
	{
		private Boolean() : base("boolean") { }

		public static Boolean Instance { get; } = new();
	}
}