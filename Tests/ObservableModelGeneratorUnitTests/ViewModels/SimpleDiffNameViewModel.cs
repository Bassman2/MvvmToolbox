namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(SimpleModel))]
public partial class SimpleDiffNameViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty("Name")]
    public partial string DiffName { get; set; }

    [ObservableProperty]
    [ObservableModelProperty("Description")]
    public partial string? DiffDescription { get; set; }

    [ObservableProperty]
    [ObservableModelProperty("Number")]
    public partial int DiffNumber { get; set; }

    [ObservableProperty]
    [ObservableModelProperty("No")]
    public partial int? DiffNo { get; set; }
}
