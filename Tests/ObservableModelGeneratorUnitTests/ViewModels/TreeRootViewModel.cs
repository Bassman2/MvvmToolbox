namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(TreeRootModel))]
public partial class TreeRootViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial TreeLeafViewModel Child { get; set; }

    [ObservableProperty]
    [ObservableModelProperty]
    public partial TreeLeafViewModel Leaf { get; set; }

    [ObservableModelProperty]
    public ObservableCollection<TreeLeafViewModel> Children { get; }

    [ObservableModelProperty]
    public ObservableCollection<TreeLeafViewModel> Leaves { get; }
}
