# MvvmToolkit

Code Generator to fill a ViewModel tree with the date of a Model tree and updates the model tree on ViewModel tree changes.


| Mode Property Data Type | ViewModel Property Data Type | Comment |
| --- | --- | --- |
| simple types | simple types | e.q. (string, int, float, ...) |
| List<T> | ObservableCollection<T> | where T is a simple Type |
| List<M> | ObservableCollection<VM> | VM is the corresponding ViewModel to the Model M |
