using System.IO;

namespace WebIdlParser.Test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var windowIdl = File.ReadAllText(@"IDL\Window.idl");
			var parsed = Parser.ParseDefinitions(windowIdl);
			;
		}
	}
}