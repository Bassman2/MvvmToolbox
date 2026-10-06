using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmToolbox.SourceGenerators;

partial class ObservableModelGenerator
{
    protected void CreateAttributes(IncrementalGeneratorPostInitializationContext context)
    {
        context.AddSource($"ObservableModelAttributes.g.cs",
            """
            #nullable enable

            namespace MvvmToolbox.ComponentModel;

            [AttributeUsage(AttributeTargets.Class)]
            public class ObservableModelObjectAttribute(Type modelType): Attribute
            { 
                public Type ModelType { get; } = modelType;
            }

            [AttributeUsage(AttributeTargets.Property)]
            public class ObservableModelPropertyAttribute : Attribute
            { 
                public ObservableModelPropertyAttribute()
                { }

                public ObservableModelPropertyAttribute(string modelPropertyName)
                {
                    ModelPropertyName = modelPropertyName;
                }

                public string? ModelPropertyName { get; } = null; 
                public string? Converter { get; init; } = null;
                public Type? ConverterType { get; init; } = null;
            }

            public interface IPropertyConverter
            {
                // From Model to ViewModel
                object Convert(object value);

                // From ViewModel to Model
                object ConvertBack(object value);
            }
            """);
    }

}
