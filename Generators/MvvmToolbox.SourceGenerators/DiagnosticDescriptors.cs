using Microsoft.CodeAnalysis;

namespace MvvmToolbox.SourceGenerators;

public static class DiagnosticDescriptors
{
    public static readonly DiagnosticDescriptor InvalidPropertyError = new(
        id: "MTSG001",                                         
        title: "Missing partial modifier",    
        messageFormat: "Missing partial modifier on declaration of type '{0}'; another partial declaration of this type exists", 
        category: "MvvmToolboxGenerator",                        
        defaultSeverity: DiagnosticSeverity.Error,              
        isEnabledByDefault: true
    );
}
