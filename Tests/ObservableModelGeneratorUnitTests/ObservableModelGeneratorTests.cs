//#pragma warning disable IDE0017 

using ObservableModelGeneratorUnitTests.Models;
using ObservableModelGeneratorUnitTests.ViewModels;


namespace ObservableModelGeneratorUnitTests;

[TestClass]
public sealed class ObservableModelGeneratorTests
{
    #region Simple

    readonly string Name = "New Name";
    readonly string Description = "New Description";
    readonly int Number = 15;
    readonly int No = 20;
    
    [TestMethod]
    public void SimpleTest()
    {
        var model = new SimpleModel { Name = "Test Name", Description = "Test description", Number = 5, No = 10 };
        var viewModel = new SimpleViewModel(model);

        Assert.AreEqual(model.Name, viewModel.Name, nameof(viewModel.Name));
        Assert.AreEqual(model.Description, viewModel.Description, nameof(viewModel.Description));
        Assert.AreEqual(model.Number, viewModel.Number, nameof(viewModel.Number));
        Assert.AreEqual(model.No, viewModel.No, nameof(viewModel.No));

        viewModel.Name = Name;
        viewModel.Description = Description;
        viewModel.Number = Number;
        viewModel.No = No;

        Assert.AreEqual(Name, model.Name, nameof(model.Name));
        Assert.AreEqual(Description, model.Description, nameof(model.Description));
        Assert.AreEqual(Number, model.Number, nameof(model.Number));
        Assert.AreEqual(No, model.No, nameof(model.No));
    }

    [TestMethod]
    public void SimpleDiffNameTest()
    {
        var model = new SimpleModel { Name = "Test Name", Description = "Test description", Number = 5, No = 10 };
        var viewModel = new SimpleDiffNameViewModel(model);

        Assert.AreEqual(model.Name, viewModel.DiffName, nameof(viewModel.DiffName));
        Assert.AreEqual(model.Description, viewModel.DiffDescription, nameof(viewModel.DiffDescription));
        Assert.AreEqual(model.Number, viewModel.DiffNumber, nameof(viewModel.DiffNumber));
        Assert.AreEqual(model.No, viewModel.DiffNo, nameof(viewModel.DiffNo));

        viewModel.DiffName = Name;
        viewModel.DiffDescription = Description;
        viewModel.DiffNumber = Number;
        viewModel.DiffNo = No;

        Assert.AreEqual(Name, model.Name, nameof(model.Name));
        Assert.AreEqual(Description, model.Description, nameof(model.Description));
        Assert.AreEqual(Number, model.Number, nameof(model.Number));
        Assert.AreEqual(No, model.No, nameof(model.No));
    }

    #endregion

    #region List Simple

    readonly List<string> Names = ["Peter", "Paul"];
    readonly List<string> Descriptions = ["Butcher", "Baker"];
    readonly List<int> Numbers = [15, 20, 30];
    readonly List<int> Nos = [20, 30, 40];

    [TestMethod]
    public void ListSimpleTest()
    {
        var model = new ListSimpleModel { Names = ["Test Name"], Descriptions = ["Test description"], Numbers = [5], Nos = [10] };
        var viewModel = new ListSimpleViewModel(model);

        CollectionAssert.AreEqual(model.Names, viewModel.Names, nameof(viewModel.Names));
        CollectionAssert.AreEqual(model.Descriptions, viewModel.Descriptions, nameof(viewModel.Descriptions));
        CollectionAssert.AreEqual(model.Numbers, viewModel.Numbers, nameof(viewModel.Numbers));
        CollectionAssert.AreEqual(model.Nos, viewModel.Nos, nameof(viewModel.Nos));

        ReplaceAll(viewModel.Names, Names);
        ReplaceAll(viewModel.Descriptions, Descriptions);
        ReplaceAll(viewModel.Numbers, Numbers);
        ReplaceAll(viewModel.Nos, Nos);

        CollectionAssert.AreEqual(Names, model.Names, nameof(model.Names));
        CollectionAssert.AreEqual(Descriptions, model.Descriptions, nameof(model.Descriptions));
        CollectionAssert.AreEqual(Numbers, model.Numbers, nameof(model.Numbers));
        CollectionAssert.AreEqual(Nos, model.Nos, nameof(model.Nos));
    }

    [TestMethod]
    public void ListSimpleDiffNameTest()
    {
        var model = new ListSimpleModel { Names = ["Test Name"], Descriptions = ["Test description"], Numbers = [5], Nos = [10] };
        var viewModel = new ListSimpleDiffNameViewModel(model);

        CollectionAssert.AreEqual(model.Names, viewModel.DiffNames, nameof(viewModel.DiffNames));
        CollectionAssert.AreEqual(model.Descriptions, viewModel.DiffDescriptions, nameof(viewModel.DiffDescriptions));
        CollectionAssert.AreEqual(model.Numbers, viewModel.DiffNumbers, nameof(viewModel.DiffNumbers));
        CollectionAssert.AreEqual(model.Nos, viewModel.DiffNos, nameof(viewModel.DiffNos));

        ReplaceAll(viewModel.DiffNames, Names);
        ReplaceAll(viewModel.DiffDescriptions, Descriptions);
        ReplaceAll(viewModel.DiffNumbers, Numbers);
        ReplaceAll(viewModel.DiffNos, Nos);

        CollectionAssert.AreEqual(Names, model.Names, nameof(model.Names));
        CollectionAssert.AreEqual(Descriptions, model.Descriptions, nameof(model.Descriptions));
        CollectionAssert.AreEqual(Numbers, model.Numbers, nameof(model.Numbers));
        CollectionAssert.AreEqual(Nos, model.Nos, nameof(model.Nos));
    }

    #endregion

    #region Tree

    #endregion

    #region List Tree

    #endregion

    #region Converter

    #endregion

    #region Helper

    private static void ReplaceAll<T>(ObservableCollection<T> collection, IEnumerable<T> items)
    {
        collection.Clear();
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }

    #endregion
}

