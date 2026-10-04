namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(ListSimpleModel))]
public partial class ListSimpleDiffNameViewModel : ObservableObject
{
    [ObservableModelProperty("Names")]
    public ObservableCollection<string> DiffNames { get; }

    [ObservableModelProperty("Descriptions")]
    public ObservableCollection<string> DiffDescriptions { get; }

    [ObservableModelProperty("Numbers")]
    public ObservableCollection<int> DiffNumbers { get; }

    [ObservableModelProperty("Nos")]
    public ObservableCollection<int> DiffNos { get; }
}
