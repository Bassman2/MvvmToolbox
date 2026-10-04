#pragma warning disable IDE0017 

using ObservableModelGeneratorUnitTests.Models;
using ObservableModelGeneratorUnitTests.ViewModels;


namespace ObservableModelGeneratorUnitTests;

[TestClass]
public sealed class ObservableModelGeneratorTests
{
    readonly string Name = "New Name";
    readonly string Description = "New Description";
    readonly int Number = 15;
    readonly int No = 20;

    readonly List<string> Names = ["Peter", "Paul"];
    readonly List<string> Descriptions = ["Butcher", "Baker"];
    readonly List<int> Numbers = [15, 20, 30];
    readonly List<int> Nos = [20, 30, 40];

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

    /*
    [TestMethod]
    public void TestStringProperty()
    {
        var model = new RootModel { Name = "Test", Description = "Test description" };
        var viewModel = new RootViewModel(model);
        viewModel.Name = "New Name";
        viewModel.Description = "New Description";

        Assert.AreEqual("New Name", model.Name, nameof(model.Name));
        Assert.AreEqual("New Description", model.Description, nameof(model.Description));
    }

    [TestMethod]
    public void TestStringDifferentNameProperty()
    {
        var model = new RootModel { NameDiff = "Test", DescriptionDiff = "Test description" };
        var viewModel = new RootViewModel(model);
        viewModel.NameDifferent = "New Name";
        viewModel.DescriptionDifferent = "New Description";

        Assert.AreEqual("New Name", model.NameDiff, nameof(model.NameDiff));
        Assert.AreEqual("New Description", model.DescriptionDiff, nameof(model.DescriptionDiff));
    }

    [TestMethod]
    public void TestIntProperty()
    {
        var model = new RootModel { NumberA = 10, NumberB = null };
        var viewModel = new RootViewModel(model);
        viewModel.NumberA = 20;
        viewModel.NumberB = 30;

        Assert.AreEqual(20, model.NumberA, nameof(model.NumberA));
        Assert.AreEqual(30, model.NumberB, nameof(model.NumberB));
    }

    [TestMethod]
    public void TestIntDifferentNameProperty()
    {
        var model = new RootModel { NumberADiff = 10, NumberBDiff = null };
        var viewModel = new RootViewModel(model);
        viewModel.NumberA = 20;
        viewModel.NumberB = 30;

        Assert.AreEqual(20, model.NumberA, nameof(model.NumberA));
        Assert.AreEqual(30, model.NumberB, nameof(model.NumberB));
    }

    //[TestMethod]
    //public void TestRootModelProperty()
    //{
    //    var model = new RootModel { 
    //        LeafA = new LeafModel { NumberA = 10, NumberB = 20 }, 
    //        LeafB = null };
    //    var viewModel = new RootViewModel(model);
    //    viewModel.LeafA.NumberA = 20;
    //    viewModel.LeafA.NumberB = 30;
    //    viewModel.LeafB = new LeafViewModel(new LeafModel { NumberA = 40, NumberB = 50 });
    //    viewModel.LeafB.NumberA = 40;
    //    viewModel.LeafB.NumberB = 50;

    //    Assert.IsNotNull(model.LeafB, nameof(model.LeafB));
    //    Assert.AreEqual(20, model.LeafA.NumberA, nameof(model.LeafA.NumberA));
    //    Assert.AreEqual(30, model.LeafA.NumberB, nameof(model.LeafA.NumberB));
    //    Assert.AreEqual(40, model.LeafB.NumberA, nameof(model.LeafB.NumberA));
    //    Assert.AreEqual(50, model.LeafB.NumberB, nameof(model.LeafB.NumberB));
    //}

    [TestMethod]
    public void TestStringListProperty()
    {
        var model = new RootModel { StringListA = [ "TestA", "TestB" ], StringListB = null };
        var viewModel = new RootViewModel(model);
        viewModel.NumberA = 20;
        viewModel.NumberB = 30;

        Assert.AreEqual(20, model.NumberA, nameof(model.NumberA));
        Assert.AreEqual(30, model.NumberB, nameof(model.NumberB));
    }

    [TestMethod]
    public void TestIntListProperty()
    {
        var model = new RootModel { IntListA = [10, 20], IntListB = null };
        var viewModel = new RootViewModel(model);
        viewModel.NumberA = 20;
        viewModel.NumberB = 30;

        Assert.AreEqual(20, model.NumberA, nameof(model.NumberA));
        Assert.AreEqual(30, model.NumberB, nameof(model.NumberB));
    }

    [TestMethod]
    public void TestModelListProperty()
    {
        var model = new RootModel { ModelListA = [ new LeafModel(), new LeafModel()], ModelListB = null };
        var viewModel = new RootViewModel(model);
        viewModel.NumberA = 20;
        viewModel.NumberB = 30;

        Assert.AreEqual(20, model.NumberA, nameof(model.NumberA));
        Assert.AreEqual(30, model.NumberB, nameof(model.NumberB));
    }
    */

    //private static ObservableCollection<T> ReplaceAll<T>(ObservableCollection<T> collection, IEnumerable<T> items)
    //{
    //    collection.Clear();
    //    foreach (var item in items)
    //    {
    //        collection.Add(item);
    //    }
    //    return collection;
    //}

    private static void ReplaceAll<T>(ObservableCollection<T> collection, IEnumerable<T> items)
    {
        collection.Clear();
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }
}

