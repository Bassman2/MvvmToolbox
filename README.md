# MvvmToolkit

Code Generator to fill a ViewModel tree with the date of a Model tree and updates the model tree on ViewModel tree changes.

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

[ObservableModelObject(typeof(DemoModel))]
public partial class DemoViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial string Name { get; set; }
}
```
## List of Simple Types
Synchronizing properties with a list of simple data types between the Model and the ViewModel.
#### Model
```
namespace Demo.Models;

public class DemoModel
{
    public List<string> Names { get; set; } = [ "Peter", "Paul", "Mary"];
}
```
#### ViewModel
```
using CommunityToolkit.Mvvm.ComponentModel;
using MvvmToolbox.ComponentModel;
using ObservableModelGeneratorUnitTests.Models;

namespace Demo.ViewModels;

[ObservableModelObject(typeof(DemoModel))]
public partial class DemoViewModel : ObservableObject
{
    // no [ObservableProperty]
    [ObservableModelProperty]
    public partial ObservableCollection<string> Names { get; }
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

[ObservableModelObject(typeof(DemoModel))]
public partial class DemoViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty(nameof(DemoModel.Name))]
    public partial string FirstName { get; set; }
}
```
## Children
Synchronizing properties with children between Model and ViewModel.
#### Model
```
namespace Demo.Models;

public class RootModel
{
    public LeafModel? Leaf { get; set; } = new LeafModel();
}

public class LeafModel
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
public partial class RootViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial LeafViewModel? Leaf { get; set; }
}

[ObservableModelObject(typeof(LeafModel))]
public partial class LeafViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial string Name { get; set; }
}
```
## List of Children
Synchronizing properties with a list of children between Model and ViewModel.
#### Model
```
namespace Demo.Models;

public class RootModel
{
    public List<LeafModel> Leafs { get; set; } = [new LeafModel(), new LeafModel()];
}

public class LeafModel
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
public partial class RootViewModel : ObservableObject
{
    // no [ObservableProperty]
    [ObservableModelProperty]
    public partial ObservableCollection<LeafViewModel> Leafs { get; }
}

[ObservableModelObject(typeof(LeafModel))]
public partial class LeafViewModel : ObservableObject
{
    [ObservableProperty]
    [ObservableModelProperty]
    public partial string Name { get; set; }
}
```


