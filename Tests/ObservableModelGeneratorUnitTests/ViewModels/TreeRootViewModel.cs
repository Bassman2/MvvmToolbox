namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(TreeRootModel))]
public partial class TreeRootViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial TreeLeaveViewModel Child { get; set; }

    [ObservableProperty]
    [ObservableModelProperty]
    public partial TreeLeaveViewModel? Leave { get; set; }

    [ObservableModelProperty]
    public ObservableCollection<TreeLeaveViewModel> Children { get; }

    [ObservableModelProperty]
    public ObservableCollection<TreeLeaveViewModel> Leaves { get; }
}
