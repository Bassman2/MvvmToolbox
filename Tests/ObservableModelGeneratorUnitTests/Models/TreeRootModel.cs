namespace ObservableModelGeneratorUnitTests.Models;

public class TreeRootModel
{
    public TreeLeafModel Child { get; set; } = new TreeLeafModel();
    public TreeLeafModel? Leaf { get; set; } = null;
    public List<TreeLeafModel> Children { get; set; } = [];
    public List<TreeLeafModel>? Leaves { get; set; } = [];
}
