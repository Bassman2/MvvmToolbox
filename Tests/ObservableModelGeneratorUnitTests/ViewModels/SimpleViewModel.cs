namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(SimpleModel))]
public partial class SimpleViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial string Name { get; set; }

    [ObservableProperty]
    [ObservableModelProperty]
    public partial string? Description { get; set; }

    [ObservableProperty]
    [ObservableModelProperty]
    public partial int Number { get; set; }

    [ObservableProperty]
    [ObservableModelProperty]
    public partial int? No { get; set; }
}
