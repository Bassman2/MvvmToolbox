namespace ObservableModelGeneratorUnitTests.Models;

public class TreeRootModel
{
    public TreeLeaveModel Child { get; set; } = new TreeLeaveModel();
    public TreeLeaveModel? Leave { get; set; } = null;
    public List<TreeLeaveModel> Children { get; set; } = [];
    public List<TreeLeaveModel>? Leaves { get; set; } = [];
}
