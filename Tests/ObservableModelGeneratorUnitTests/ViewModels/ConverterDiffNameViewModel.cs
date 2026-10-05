namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(ConverterModel))]
public partial class ConverterDiffNameViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty("Value", Converter = "NumConvert", ModelType = "int")]
    public partial string DiffValue { get; set; }

    private static partial string GetNumConvert(int value) => value.ToString();
    private static partial int SetNumConvert(string value) => int.Parse(value);
}

