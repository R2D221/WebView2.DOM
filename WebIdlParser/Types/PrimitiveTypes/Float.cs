namespace WebIdlParser
{
	internal sealed class Float : Type
	{
		private Float() : base("float") { }

		public static Float Instance { get; } = new();
	}
}