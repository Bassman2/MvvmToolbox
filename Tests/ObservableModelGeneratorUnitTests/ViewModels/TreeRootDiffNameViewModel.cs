namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(TreeRootModel))]
public partial class TreeRootDiffNameViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty("Child")]
    public partial TreeLeafViewModel DiffChild { get; set; }

    [ObservableProperty]
    [ObservableModelProperty("Leaf")]
    public partial TreeLeafViewModel DiffLeaf { get; set; }

    [ObservableModelProperty("Children")]
    public ObservableCollection<TreeLeafViewModel> DiffChildren { get; }

    [ObservableModelProperty("Leaves")]
    public ObservableCollection<TreeLeafViewModel> DiffLeaves { get; }
}
