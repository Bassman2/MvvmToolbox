namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(ConverterModel))]
public partial class ConverterFuncViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty(Converter = "NumConvert")]
    public partial string Value { get; set; }

    private static string GetNumConvert(int value) => value.ToString();
    private static int SetNumConvert(string value) => int.Parse(value);
}

