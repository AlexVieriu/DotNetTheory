using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ClassListGenerator;

[Generator]
public class TheGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // tell Roslyn that we want from the compiler to generate
        var provider = context.SyntaxProvider.CreateSyntaxProvider(
            // predicate is the filter
            predicate: static (node, _) => node is ClassDeclarationSyntax,
            // transform sais you satisfied the first piece of this, now what u want to do with the things that qualify for the predicate
            transform: static (ctx, _) => (ClassDeclarationSyntax)ctx.Node
            ).Where(m => m is not null);

        var compilation = context.CompilationProvider.Combine(provider.Collect());

        // we gonna take this compilation that's going to contain all those classes
        // that we care about and then tell it to execute some code of ours
        context.RegisterSourceOutput(compilation, Execute);
    }

    private void Execute(SourceProductionContext context, 
        (Compilation Left, ImmutableArray<ClassDeclarationSyntax> Right) tuple)
    {
        var (compilation, list) = tuple;

        var nameList = new List<string>();
        foreach (var syntax in list)
        {
            var symbol = compilation
                .GetSemanticModel(syntax.SyntaxTree)
                .GetDeclaredSymbol(syntax) as INamedTypeSymbol;

            nameList.Add($"\"{symbol.ToDisplayString()}\"");
        }

        var names= string.Join(",\n     ", nameList); 

        var theCode = $$"""
            namespace ClassListGenerator;

            public static class ClassNames
            {
                public static List<string> Name = new()
                {
                    {{names}}
                };
            }
            """;

        context.AddSource("YourClassList.g.cs", theCode);
    }
}
