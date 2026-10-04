namespace ObservableModelGeneratorUnitTests.ViewModels;


[ObservableModelObject(typeof(RootModel))]
public partial class RootViewModel : ObservableObject
{
    // TestStringProperty

    [ObservableProperty]
    [ObservableModelProperty]
    public partial string Name { get; set; }

    [ObservableProperty]
    [ObservableModelProperty]
    public partial string? Description { get; set; }

    [ObservableProperty]
    [ObservableModelProperty("NameDiff")]
    public partial string NameDifferent { get; set; }

    [ObservableProperty]
    [ObservableModelProperty("DescriptionDiff")]
    public partial string? DescriptionDifferent { get; set; }

    [ObservableProperty]
    [ObservableModelProperty]
    public partial int NumberA { get; set; } 

    [ObservableProperty]
    [ObservableModelProperty]
    public partial int? NumberB { get; set; }

    //[ObservableProperty]
    //[ObservableModelProperty]
    //public partial LeafViewModel LeafA { get; set; } 

    //[ObservableProperty]
    //[ObservableModelProperty]
    //public partial LeafViewModel? LeafB { get; set; }

}
