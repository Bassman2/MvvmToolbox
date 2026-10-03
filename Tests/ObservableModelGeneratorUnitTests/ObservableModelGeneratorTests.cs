#pragma warning disable IDE0017 

using ObservableModelGeneratorUnitTests.Models;
using ObservableModelGeneratorUnitTests.ViewModels;


namespace ObservableModelGeneratorUnitTests;

[TestClass]
public sealed class ObservableModelGeneratorTests
{
    [TestMethod]
    public void TestRootStringProperty()
    {
        var model = new RootModel { Name = "Test", Description = "Test description" };
        var viewModel = new RootViewModel(model);
        viewModel.Name = "New Name";
        viewModel.Description = "New Description";

        Assert.AreEqual("New Name", model.Name, nameof(model.Name));
        Assert.AreEqual("New Description", model.Description, nameof(model.Description));
    }

    [TestMethod]
    public void TestRootIntProperty()
    {
        var model = new RootModel { NumberA = 10, NumberB = null };
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
    public void TestRootListProperty()
    {
        var model = new RootModel { NumberA = 10, NumberB = null };
        var viewModel = new RootViewModel(model);
        viewModel.NumberA = 20;
        viewModel.NumberB = 30;

        Assert.AreEqual(20, model.NumberA, nameof(model.NumberA));
        Assert.AreEqual(30, model.NumberB, nameof(model.NumberB));
    }
}

   
