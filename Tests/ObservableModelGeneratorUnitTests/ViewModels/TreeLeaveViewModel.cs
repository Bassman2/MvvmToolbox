namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(TreeLeaveModel))]
public partial class TreeLeaveViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial string Name { get; set; }
}
