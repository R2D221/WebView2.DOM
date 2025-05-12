namespace WebIdlParser
{
	internal sealed class UnrestrictedDouble : Type
	{
		private UnrestrictedDouble() : base("unrestricted double") { }

		public static UnrestrictedDouble Instance { get; } = new();
	}
}