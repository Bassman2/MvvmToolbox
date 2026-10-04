using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    [RelayCommand]
    private void DoSomething()
    {
    }
}
