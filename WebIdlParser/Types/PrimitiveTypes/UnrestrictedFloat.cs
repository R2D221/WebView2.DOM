namespace WebIdlParser
{
	internal sealed class UnrestrictedFloat : Type
	{
		private UnrestrictedFloat() : base("unrestricted float") { }

		public static UnrestrictedFloat Instance { get; } = new();
	}
}