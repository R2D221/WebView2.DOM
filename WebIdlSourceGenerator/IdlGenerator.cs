using Microsoft.CodeAnalysis;
using System.Diagnostics;
using WebIdlParser;

namespace WebIdlSourceGenerator
{
	[Generator]
	public sealed class IdlGenerator : IIncrementalGenerator
	{
		// https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md#authoring-a-cache-friendly-generator

		void IIncrementalGenerator.Initialize(IncrementalGeneratorInitializationContext context)
		{
			var definitionsWithFileNames =
				context.AdditionalTextsProvider
				.Where(x => Path.GetExtension(x.Path) == ".idl")
				.Select((x, c) => (Path.GetFileNameWithoutExtension(x.Path), x.GetText(c)!.ToString()))
				.SelectMany((x, _) =>
					Parser.ParseDefinitions(x.Item2.AsSpan())
					.Select(y => (fileName: x.Item1, definition: y))
				)
				.Collect()
				;

			var existingMembers =
				context.CompilationProvider
				.SelectMany((x, _) => x.Assembly.GlobalNamespace.GetNamespaceMembers())
				.Where(x => x.Name == "WebView2")
				.SelectMany((x, _) => x.GetNamespaceMembers())
				.Where(x => x.Name == "DOM")
				.SelectMany((x, _) => x.GetTypeMembers())
				.SelectMany((x, _) => x.MemberNames.Select(y => (type: x.Name, member: y)))
				.Collect()
				;

			var all = definitionsWithFileNames.Combine(existingMembers);

			context.RegisterSourceOutput(all, (context, x) =>
			{
				var (definitionsWithFileNames, existingMembers) = x;

				try
				{
					var compiler = new Compiler(definitionsWithFileNames, existingMembers);

					foreach (var file in compiler.Compile())
					{
						context.AddSource($"{file.name}.g.cs", file.contents);
					}
				}
				catch (Exception ex)
				{
					_ = ex;
					_ = Debugger.Launch();
					throw;
				}
			});
		}
	}
}
