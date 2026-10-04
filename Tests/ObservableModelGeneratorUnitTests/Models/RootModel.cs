namespace ObservableModelGeneratorUnitTests.Models;

public class RootModel
{
    // TestStringProperty

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; } = null;

    // TestStringDifferentNameProperty

    public string NameDiff { get; set; } = string.Empty;

    public string? DescriptionDiff { get; set; } = null;

    // TestIntProperty

    public int NumberA { get; set; } = 0;

    public int? NumberB { get; set; } = null;

    //TestIntDifferentNameProperty

    public int NumberADiff { get; set; } = 0;

    public int? NumberBDiff { get; set; } = null;

    //

    public LeafModel LeafA { get; set; } = new LeafModel();

    public LeafModel? LeafB { get; set; } = null;

    public List<string> StringListA { get; set; } = [];

    public List<string>? StringListB { get; set; } = null;

    public List<int> IntListA { get; set; } = [];

    public List<int>? IntListB { get; set; } = null;

    public List<LeafModel> ModelListA { get; set; } = [];

    public List<LeafModel>? ModelListB { get; set; } = null;

    public string TitelOtherName { get; set; } = string.Empty;

    public List<LeafModel> ListOtherName { get; set; } = [];

    public int LambdaInt { get; set; } = 0;

    public List<string> LambdaList { get; set; } = [];

}
