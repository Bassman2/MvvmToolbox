namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(ConverterModel))]
public partial class ConverterFuncDiffNameViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty("Value", Converter = "NumConvert")]
    public partial string DiffValue { get; set; }

    private static string GetNumConvert(int value) => value.ToString();
    private static int SetNumConvert(string value) => int.Parse(value);
}

