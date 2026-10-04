namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(TreeRootModel))]
public partial class TreeRootDiffNameViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty("Child")]
    public partial TreeLeaveViewModel DiffChild { get; set; }

    [ObservableProperty]
    [ObservableModelProperty("Leave")]
    public partial TreeLeaveViewModel? DiffLeave { get; set; }

    [ObservableModelProperty("Children")]
    public ObservableCollection<TreeLeaveViewModel> DiffChildren { get; }

    [ObservableModelProperty("Leaves")]
    public ObservableCollection<TreeLeaveViewModel> DiffLeaves { get; }
}
