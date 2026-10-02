namespace MvvmToolbox.SourceGenerators;

partial class ObservableModelGenerator
{
    protected void CreateAttributes()
    {
        AddSource($"ObservableModelAttributes.g.cs",
            """
            namespace MvvmToolbox.ComponentModel;

            [AttributeUsage(AttributeTargets.Class)]
            public class ObservableModelObjectAttribute(string modelTypeName) : Attribute
            { 
                public string ModelTypeName { get; } = modelTypeName;
            }

            [AttributeUsage(AttributeTargets.Property)]
            public class ObservableModelPropertyAttribute(string modelPropetyName)  : Attribute
            { 
                public string ModelPropetyName { get; } = modelPropetyName;
            }

            """);
    }
}
