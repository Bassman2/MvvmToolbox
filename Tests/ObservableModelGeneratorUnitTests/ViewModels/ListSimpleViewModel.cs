namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(ListSimpleModel))]
public partial class ListSimpleViewModel : ObservableObject
{
    [ObservableModelProperty]
    public ObservableCollection<string> Names { get; }

    [ObservableModelProperty]
    public ObservableCollection<string> Descriptions { get; }

    [ObservableModelProperty]
    public ObservableCollection<int> Numbers { get; }

    [ObservableModelProperty]
    public ObservableCollection<int> Nos { get; }
}
