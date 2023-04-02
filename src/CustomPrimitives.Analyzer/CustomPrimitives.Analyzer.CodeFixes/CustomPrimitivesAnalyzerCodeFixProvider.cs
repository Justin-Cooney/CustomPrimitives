using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomPrimitives.Analyzer
{
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(CustomPrimitivesAnalyzerCodeFixProvider)), Shared]
	public class CustomPrimitivesAnalyzerCodeFixProvider : CodeFixProvider
	{
		private const string Title = "Add primitive constructor";

		public sealed override ImmutableArray<string> FixableDiagnosticIds
			=> ImmutableArray.Create(CustomPrimitivesAnalyzerAnalyzer.PrimitiveConstructorDiagnosticId);

		public sealed override FixAllProvider GetFixAllProvider()
			=> WellKnownFixAllProviders.BatchFixer;

		public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
			var diagnostic = context.Diagnostics.First();
			var diagnosticSpan = diagnostic.Location.SourceSpan;
			var classDeclaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<ClassDeclarationSyntax>().First();

			context.RegisterCodeFix(
				CodeAction.Create(
					title: Title,
					createChangedDocument: c => AddConstructor(context.Document, root, classDeclaration, c),
					equivalenceKey: Title),
				diagnostic);
		}

		private async Task<Document> AddConstructor(Document document, SyntaxNode root, ClassDeclarationSyntax node, CancellationToken cancellationToken)
		{
			var sModel = await document.GetSemanticModelAsync(cancellationToken);
			var classSymbol = sModel.GetDeclaredSymbol(node);
			var primitiveInterface = classSymbol.AllInterfaces.First(x => x.ToString().StartsWith("CustomPrimitives.IPrimitive"));

			var syntax = SyntaxFactory
				.ConstructorDeclaration(classSymbol.Name)
				.AddParameterListParameters(
					SyntaxFactory.Parameter(SyntaxFactory.Identifier("value"))
						.WithType(SyntaxFactory.ParseTypeName(((INamedTypeSymbol)primitiveInterface.TypeArguments.First()).ToDisplayString())))
				.WithInitializer(SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer).AddArgumentListArguments(SyntaxFactory.Argument(SyntaxFactory.IdentifierName("value"))))
				.WithBody(SyntaxFactory.Block())
				.AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword));

			var attributes = node.Members.Insert(0, syntax);
			var newroot = root.ReplaceNode(node, node.WithMembers(attributes));
			return document.WithSyntaxRoot(newroot);
		}
	}
}
