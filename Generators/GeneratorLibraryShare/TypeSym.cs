using Microsoft.CodeAnalysis;
using System.Linq;

namespace GeneratorLibrary
{
    public class TypeSym(ITypeSymbol symbol) 
    {
        public string Name => symbol.Name;

        public string FullName => symbol.ToDisplayString();

        public string NameSpace => symbol.ContainingNamespace?.ToDisplayString() ?? string.Empty;

        public string FullNameWithoutConcreteTypes => symbol.OriginalDefinition.ToDisplayString();

        public TypeKind TypeKind => symbol.TypeKind;


        public string BaseTypeName => GetInnerType()?.Name ?? "";

        public string BaseTypeFullName => GetInnerType()?.FullName ?? "";


        public bool IsReferenceType => symbol.IsReferenceType;

        public bool IsValueType => symbol.IsValueType;

        public bool IsEnum => symbol.TypeKind == Microsoft.CodeAnalysis.TypeKind.Enum;

        public bool IsGeneric => symbol is INamedTypeSymbol namedType && namedType.IsGenericType;

        public bool IsObservableCollection => symbol is INamedTypeSymbol namedType && namedType.IsGenericType && namedType.OriginalDefinition.ToDisplayString() == "System.Collections.ObjectModel.ObservableCollection<T>";


        public TypeSym? GetInnerType(int index = 0)
        {
            if (symbol is INamedTypeSymbol named && named.TypeArguments.Length > index)
            {
                var arg = named.TypeArguments[index];
                // If the symbol is an unbound generic (type parameter) there's no concrete inner type:
                if (arg is ITypeParameterSymbol)
                    return null;
                return new TypeSym(arg);
            }

            if (symbol is IArrayTypeSymbol arr)
                return new TypeSym(arr.ElementType);

            if (symbol is IPointerTypeSymbol ptr)
                return new TypeSym(ptr.PointedAtType);

            return null;
        }

        public bool ImplementsInterface(string interfaceFullyQualifiedName)
        {
            if (symbol.AllInterfaces.Any(i => i.ToDisplayString() == interfaceFullyQualifiedName))
            {
                return true;
            }

            if (symbol is INamedTypeSymbol namedType && namedType.ToDisplayString() == interfaceFullyQualifiedName)
            {
                return true;
            }
            return false;
        }
    }
}
