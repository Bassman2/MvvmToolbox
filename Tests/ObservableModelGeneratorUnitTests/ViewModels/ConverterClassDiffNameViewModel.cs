namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(ConverterModel))]
public partial class ConverterClassDiffNameViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty("Value", ConverterType = typeof(IntToStringConverter))]
    public partial string DiffValue { get; set; }

    public class IntToStringConverter : IPropertyConverter
    {
        public object Convert(object value) => value?.ToString()!;
        public object ConvertBack(object value) => (value is string input && int.TryParse(input, out int result)) ? result : null!;
    }
}

