using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MvvmToolbox.SourceGenerators;

partial class ObservableModelGenerator
{

    // Einfacher Fehler ohne direkten Codebezug
    public void ReportError(string message)
    {
        Context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.InvalidPropertyError, Location.None, message));
    }

    // Fehler, der direkt an einer Klasse/einem Enum im Editor angezeigt wird
    public void ReportErrorOnSyntax(BaseTypeDeclarationSyntax syntax, string message)
    {
        Context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.InvalidPropertyError, syntax.Identifier.GetLocation(), message));
    }

    /*
    foreach (var syntaxClass in Classes)
        {
            if (syntaxClass.Identifier.Text == "BadClassName")
            {
                // Zeigt den Fehler direkt unter dem Klassennamen im Editor an
                ReportErrorOnSyntax(syntaxClass, "Dieser Klassenname ist nicht erlaubt");
                return; 
            }
        }  
    */
}
