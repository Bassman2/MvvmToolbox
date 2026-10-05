using GeneratorLibrary;
using Microsoft.CodeAnalysis;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using static MvvmToolbox.SourceGenerators.ObservableModelGenerator;

namespace MvvmToolbox.SourceGenerators;

[Generator(LanguageNames.CSharp)]
public partial class ObservableModelGenerator : Generator
{
    private const string ObservableModelObjectAttribute = "MvvmToolbox.ComponentModel.ObservableModelObjectAttribute";
    private const string ObservableModelPropertyAttribute = "MvvmToolbox.ComponentModel.ObservableModelPropertyAttribute";

    //private const string FindFieldsGeneratorAttribute = "MediaDevices.FindFieldsGeneratorAttribute";
    //private const string EnumGuidAttribute = "MediaDevices.EnumGuidAttribute";
    //private const string KeyAttribute = "MediaDevices.KeyAttribute";

    public override void Execute()
    {
        //Location errorLocation = propertySyntax.GetLocation();
        //string propertyName = propertySyntax.Identifier.Text;

        //Diagnostic diagnostic = Diagnostic.Create(GeneratorDiagnostics.InvalidPropertyError, errorLocation, propertyName);  // Befüllt das '{0}' im messageFormat
        //Context.ReportDiagnostic(diagnostic);

        //ReportError("Test");

        //Debugger.Launch();
        CreateDebug();

        // get all classes with [ObservableModelObjectAttribute] 
        foreach (var cl in GetAllClassesWithAttribute(ObservableModelObjectAttribute))
        {
            CreateClassFile(cl);
        }
       
    }

    protected override void CreateAttributes(IncrementalGeneratorPostInitializationContext context)
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

    public enum DataType { Error, Simple, Model, List, ModelList, ConverterFunc, ConverterClass }

    public DataType GetDataType(Property prop, GeneratorLibrary.Attribute propAttr)
    {
        if (propAttr.HasNamedArgument("Converter"))
        {
            return DataType.ConverterFunc;
        }
        else if (propAttr.HasNamedArgument("ConverterType"))
        {
            return DataType.ConverterClass;
        }
        else if (prop.Type.IsObservableCollection)
        {
            var innerType = prop.Type.GetInnerType()!;
            if (innerType.ImplementsInterface("System.ComponentModel.INotifyPropertyChanged"))
            {
                // type is a ViewModel type, because it implements INotifyPropertyChanged
                return DataType.ModelList;
            }
            else
            {
                return DataType.List;
            }
        }
        else
        {
            if (prop.Type.ImplementsInterface("System.ComponentModel.INotifyPropertyChanged"))
            {
                return DataType.Model;
            }
            else
            {
                return DataType.Simple;
            }
        }
    }

    public struct PropertyData
    {
        public DataType DataType { get; set; }
        public string ViewModelPropertyName { get; set; }
        public string ViewModelPropertyType { get; set; }
        public string ModelPropertyName { get; set; }
        public string ModelPropertyType { get; set; }
        public string? Converter { get; set; }
    }

    private PropertyData FindData(Property prop, GeneratorLibrary.Attribute propAttr, INamedTypeSymbol? modelSymbol)
    {
        DataType dataType = GetDataType(prop, propAttr);
        string viewModelPropertyName = prop.Name;
        string viewModelPropertyType = (prop.Type.IsObservableCollection ? prop.Type.GetInnerType()!.FullName : prop.Type.FullName); 

        string modelPropertyName = propAttr.ConstructorArguments.FirstOrDefault()?.Value ?? prop.Name;
        string modelPropertyType = modelSymbol?.GetMembers(modelPropertyName).OfType<IPropertySymbol>().FirstOrDefault()?.Type.ToDisplayString()!;

        string? converterName = propAttr.GetNamedArgument("Converter")?.Value?.ToString() ?? null;
        string? converterClassName = propAttr.GetNamedArgument("ConverterType")?.Value?.ToString() ?? null;

        return new PropertyData
        {
            DataType = dataType,
            ViewModelPropertyName = viewModelPropertyName,
            ViewModelPropertyType = viewModelPropertyType,
            ModelPropertyName = modelPropertyName,
            ModelPropertyType = modelPropertyType,
            Converter = converterName ?? converterClassName
        };
    }

    private void CreateClassFile(Class cl)
    {
        var attr = cl.GetAttribute(ObservableModelObjectAttribute);
        string modelType = attr != null ? attr.ConstructorArguments.FirstOrDefault().Value : string.Empty;

        INamedTypeSymbol? modelSymbol = Compilation.GetTypeByMetadataName(modelType);

        StringBuilder sb = new(
            $$"""
            // <auto-generated />

            #nullable enable annotations
            #nullable disable warnings

            // Suppress warnings about [Obsolete] member usage in generated code.
            #pragma warning disable CS0612, CS0618
            
            namespace {{cl.NameSpace}};

            partial class {{cl.Name}}
            {
                public readonly {{modelType}} Model;
                
                public {{cl.Name}}({{modelType}} model)
                {
                    Model = model;

            """);

        foreach (var prop in cl.Properties)
        {
            var propAttr = prop.GetAttribute(ObservableModelPropertyAttribute);
            if (propAttr != null)
            {
                PropertyData propertyData = FindData(prop, propAttr, modelSymbol);
                sb.AppendLine(CreateConstructorLine(propertyData));
            }
        }

        sb.AppendLine(
            """
                }

            """);

        foreach (var prop in cl.Properties)
        {
            var propAttr = prop.GetAttribute(ObservableModelPropertyAttribute);
            if (propAttr != null)
            {
                PropertyData propertyData = FindData(prop, propAttr, modelSymbol);
                sb.AppendLine(CreateSetterMethods(propertyData));
            }
        }

        sb.AppendLine(
            """
            }
            """);
        AddSource($"{cl.Name}.g.cs", sb.ToString());
    }

    
   
    public string CreateConstructorLine(PropertyData propertyData)
    {
        return //$"        // {propertyData.DataType}: vmName: {propertyData.ViewModelPropertyName} vmType: {propertyData.ViewModelPropertyType.TrimEnd('?')} mName: {propertyData.ModelPropertyName} mType: {propertyData.ModelPropertyType.TrimEnd('?')} converter: {propertyData.Converter}\r\n" +
            propertyData.DataType switch
            {
                DataType.Error => string.Empty,
                DataType.Simple =>
                    $"        {propertyData.ViewModelPropertyName} = model.{propertyData.ModelPropertyName};",
                DataType.Model =>
                    $"        {propertyData.ViewModelPropertyName} = model.{propertyData.ModelPropertyName} != null ? new {propertyData.ViewModelPropertyType.TrimEnd('?')}(model.{propertyData.ModelPropertyName}) : new {propertyData.ViewModelPropertyType.TrimEnd('?')}(new ());",
                DataType.List =>
                    $$"""
                            {{propertyData.ViewModelPropertyName}} = [.. model.{{propertyData.ModelPropertyName}}];
                            {{propertyData.ViewModelPropertyName}}.CollectionChanged += On{{propertyData.ViewModelPropertyName}}CollectionChanged;
                    """,
                DataType.ModelList =>
                    $$"""
                            {{propertyData.ViewModelPropertyName}} = [.. (model.{{propertyData.ModelPropertyName}} ?? []).Select(m => new {{propertyData.ViewModelPropertyType.TrimEnd('?')}}(m))];
                            {{propertyData.ViewModelPropertyName}}.CollectionChanged += On{{propertyData.ViewModelPropertyName}}CollectionChanged;
                    """,
                DataType.ConverterFunc =>
                    $"        {propertyData.ViewModelPropertyName} = Get{propertyData.Converter}(model.{propertyData.ModelPropertyName});",
                DataType.ConverterClass =>
                    $"        {propertyData.ViewModelPropertyName} = ({propertyData.ViewModelPropertyType.TrimEnd('?')})(new {propertyData.Converter}()).Convert(model.{propertyData.ModelPropertyName});",
                _ => throw new ArgumentOutOfRangeException(nameof(propertyData.DataType), propertyData.DataType, null)
            };
    }

    public string CreateSetterMethods(PropertyData propertyData)
    {
        return //$"    // {propertyData.DataType}: vmName: {propertyData.ViewModelPropertyName} vmType: {propertyData.ViewModelPropertyType} mName: {propertyData.ModelPropertyName} mType: {propertyData.ModelPropertyType} converter: {propertyData.Converter}\r\n" +
            propertyData.DataType switch
            {
                DataType.Error => string.Empty,
                DataType.Simple =>
                    $$"""
                        partial void On{{propertyData.ViewModelPropertyName}}Changed({{propertyData.ViewModelPropertyType}} value)
                        {
                            Model.{{propertyData.ModelPropertyName}} = value;
                        }

                    """,
                DataType.Model =>
                    $$"""
                        partial void On{{propertyData.ViewModelPropertyName}}Changed({{propertyData.ViewModelPropertyType}} value)
                        {
                            Model.{{propertyData.ModelPropertyName}} = value.Model;
                        }

                    """,
                DataType.List =>
                    $$"""
                        private void On{{propertyData.ViewModelPropertyName}}CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                        {
                            Model.{{propertyData.ModelPropertyName}} ??= [];
                            switch (e.Action)
                            {
                            case System.Collections.Specialized.NotifyCollectionChangedAction.Add when e.NewItems != null:
                                int index = e.NewStartingIndex;
                                foreach ({{propertyData.ViewModelPropertyType}} item in e.NewItems)
                                {
                                    Model.{{propertyData.ModelPropertyName}}.Insert(index++, item);
                                }
                                break;
                            case System.Collections.Specialized.NotifyCollectionChangedAction.Remove when e.OldItems != null:
                                foreach ({{propertyData.ViewModelPropertyType}} item in e.OldItems)
                                {
                                     Model.{{propertyData.ModelPropertyName}}.Remove(item);
                                }
                                break;
                            case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                                var modelToMove =  Model.{{propertyData.ModelPropertyName}}[e.OldStartingIndex];
                                Model.{{propertyData.ModelPropertyName}}.RemoveAt(e.OldStartingIndex);
                                Model.{{propertyData.ModelPropertyName}}.Insert(e.NewStartingIndex, modelToMove);
                                break;
                            case System.Collections.Specialized.NotifyCollectionChangedAction.Replace when e.NewItems != null:
                                int replaceIndex = e.NewStartingIndex;
                                foreach ({{propertyData.ViewModelPropertyType}} item in e.NewItems)
                                {
                                    Model.{{propertyData.ModelPropertyName}}[replaceIndex++] = item;
                                }
                                break;
                            case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                                Model.{{propertyData.ModelPropertyName}}.Clear();
                                foreach ({{propertyData.ViewModelPropertyType}} item in {{propertyData.ViewModelPropertyName}})
                                {
                                    Model.{{propertyData.ModelPropertyName}}.Add(item);
                                }
                                break;
                            }   
                        }
                     """,
                DataType.ModelList =>
                    $$"""
                         private void On{{propertyData.ViewModelPropertyName}}CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                         {
                            Model.{{propertyData.ModelPropertyName}} ??= [];
                             switch (e.Action)
                             {
                             case System.Collections.Specialized.NotifyCollectionChangedAction.Add when e.NewItems != null:
                                 int index = e.NewStartingIndex;
                                 foreach ({{propertyData.ViewModelPropertyType}} vm in e.NewItems)
                                 {
                                     Model.{{propertyData.ModelPropertyName}}.Insert(index++, vm.Model);
                                 }
                                 break;
                             case System.Collections.Specialized.NotifyCollectionChangedAction.Remove when e.OldItems != null:
                                 foreach ({{propertyData.ViewModelPropertyType}} vm in e.OldItems)
                                 {
                                      Model.{{propertyData.ModelPropertyName}}.Remove(vm.Model);
                                 }
                                 break;
                             case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                                 var modelToMove =  Model.{{propertyData.ModelPropertyName}}[e.OldStartingIndex];
                                 Model.{{propertyData.ModelPropertyName}}.RemoveAt(e.OldStartingIndex);
                                 Model.{{propertyData.ModelPropertyName}}.Insert(e.NewStartingIndex, modelToMove);
                                 break;
                             case System.Collections.Specialized.NotifyCollectionChangedAction.Replace when e.NewItems != null:
                                 int replaceIndex = e.NewStartingIndex;
                                 foreach ({{propertyData.ViewModelPropertyType}} vm in e.NewItems)
                                 {
                                     Model.{{propertyData.ModelPropertyName}}[replaceIndex++] = vm.Model;
                                 }
                                 break;
                             case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                                 Model.{{propertyData.ModelPropertyName}}.Clear();
                                 foreach ({{propertyData.ViewModelPropertyType}} vm in {{propertyData.ViewModelPropertyName}})
                                 {
                                     Model.{{propertyData.ModelPropertyName}}.Add(vm.Model);
                                 }
                                 break;
                             }   
                         }
                     """,
                DataType.ConverterFunc =>
                    $$"""
                        partial void On{{propertyData.ViewModelPropertyName}}Changed({{propertyData.ViewModelPropertyType}} value)
                        {
                            Model.{{propertyData.ModelPropertyName}} = Set{{propertyData.Converter}}(value);
                        }
                    """,
                DataType.ConverterClass =>
                    $$"""
                        partial void On{{propertyData.ViewModelPropertyName}}Changed({{propertyData.ViewModelPropertyType}} value)
                        {
                            Model.{{propertyData.ModelPropertyName}} = ({{propertyData.ModelPropertyType}})new {{propertyData.Converter}}().ConvertBack({{propertyData.ViewModelPropertyName}});
                        }
                    """,
                _ => throw new ArgumentOutOfRangeException(nameof(propertyData.DataType), propertyData.DataType, null)
            };
    }
   
}
