using CommunityToolkit.Mvvm.ComponentModel;
using MvvmToolbox.ComponentModel;
using ObservableModelGeneratorUnitTests.Models;

namespace ObservableModelGeneratorUnitTests.ViewModels;

[ObservableModelObject(typeof(LeafModel))]
public partial class LeafViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial int NumberA { get; set; }

    [ObservableProperty]
    [ObservableModelProperty]
    public partial int? NumberB { get; set; }
}
