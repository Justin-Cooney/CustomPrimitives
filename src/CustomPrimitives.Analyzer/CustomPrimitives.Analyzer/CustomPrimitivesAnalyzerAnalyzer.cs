using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace CustomPrimitives.Analyzer
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class CustomPrimitivesAnalyzerAnalyzer : DiagnosticAnalyzer
	{
		public const string PrimitiveConstructorDiagnosticId = "PRMTV001";

		private static readonly DiagnosticDescriptor PrimitiveConstructorRule =
			new DiagnosticDescriptor(
				id: PrimitiveConstructorDiagnosticId,
				title: "Primitive class is missing its required constructor",
				messageFormat: "Class '{0}' that implements IPrimitive should have a constructor that accepts a single parameter of its primitive type",
				category: "Constructors",
				DiagnosticSeverity.Error,
				isEnabledByDefault: true,
				description: "Primitives should have a primitive constructor");

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics 
			=> ImmutableArray.Create(PrimitiveConstructorRule);

		public override void Initialize(AnalysisContext context)
		{
			context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
			context.EnableConcurrentExecution();
			context.RegisterSyntaxNodeAction(PerformConstructorAnalysis, SyntaxKind.ClassDeclaration);
		}

		private static void PerformConstructorAnalysis(SyntaxNodeAnalysisContext context)
		{
			var node = context.Node as ClassDeclarationSyntax;
			var sModel = context.Compilation.GetSemanticModel(node.SyntaxTree);
			var classSymbol = sModel.GetDeclaredSymbol(node);

			if (!classSymbol.AllInterfaces.Any(x => x.ToString().StartsWith("CustomPrimitives.IPrimitive"))) return;

			var primitiveInterface = classSymbol.AllInterfaces.First(x => x.ToString().StartsWith("CustomPrimitives.IPrimitive"));

			if (!classSymbol.Constructors.Any(x => x.Parameters.Count() == 1 && x.Parameters.First().Type.Name == primitiveInterface.TypeArguments.First().Name))
			{
				var diagnostic = Diagnostic.Create(PrimitiveConstructorRule, node.GetLocation(), classSymbol.Name);
				context.ReportDiagnostic(diagnostic);
			}
		}
	}
}
