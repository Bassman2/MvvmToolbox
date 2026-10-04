namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(TreeLeafModel))]
public partial class TreeLeafViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial string Name { get; set; }
}
