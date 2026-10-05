namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(ConverterModel))]
public partial class ConverterViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty(Converter = "NumConvert", ModelType = "int")]
    public partial string Value { get; set; }

    private static partial string GetNumConvert(int value) => value.ToString();
    private static partial int SetNumConvert(string value) => int.Parse(value);
}

