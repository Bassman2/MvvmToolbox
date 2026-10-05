namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(ConverterModel))]
public partial class ConverterClassViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty(ConverterType = typeof(IntToStringConverter), ModelType = typeof(ConverterModel))]
    public partial string Value { get; set; }

    public class IntToStringConverter : IPropertyConverter
    {
        public object Convert(object value) => value?.ToString()!;
        public object ConvertBack(object value) => (value is string input && int.TryParse(input, out int result)) ? result : null!;
    }
}

