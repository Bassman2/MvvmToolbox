# MvvmToolkit

Code Generator to fill a ViewModel tree with the date of a Model tree and updates the model tree on ViewModel tree changes.


| Mode Property Data Type | ViewModel Property Data Type | Comment |
| --- | --- | --- |
| simple types | simple types | e.q. (string, int, float, ...) |
| `List<S>` | `ObservableCollection<S>` | where S is a simple Type |
| `List<M>` | `ObservableCollection<VM>` | VM is the corresponding ViewModel to the Model M |

# Installation

[Nuget package](https://www.nuget.org/packages/MvvmToolbox)

```
dotnet add package MvvmToolbox
```
# Examples
## Simple Types
Synchronizing properties with simple data types between the Model and the ViewModel.
#### Model
```
namespace Demo.Models;

public class DemoModel
{
    public string Name { get; set; } = "Peter";
}
```
#### ViewModel
```
using CommunityToolkit.Mvvm.ComponentModel;
using MvvmToolbox.ComponentModel;
using ObservableModelGeneratorUnitTests.Models;

namespace Demo.ViewModels;

[ObservableModelObject(typeof(RootModel))]
public partial class DemoViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial string Name { get; set; }
}
```
## Different Names
Synchronizing properties with different names between Model and ViewModel.
#### Model
```
namespace Demo.Models;

public class DemoModel
{
    public string Name { get; set; } = "Peter";
}
```
#### ViewModel
```
using CommunityToolkit.Mvvm.ComponentModel;
using MvvmToolbox.ComponentModel;
using ObservableModelGeneratorUnitTests.Models;

namespace Demo.ViewModels;

[ObservableModelObject(typeof(RootModel))]
public partial class DemoViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty(nameof(DemoModel.Name))]
    public partial string FirstName { get; set; }
}
```



