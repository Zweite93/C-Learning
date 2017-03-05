using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notepad;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //[ExpectedException(typeof(KeyNotFoundException))]
        //public void Test1()
        //{
        //    var container = new IoCContainer();

        //    var createResult = container.Create<IInterface>();

        //}

        //[TestMethod]
        //public void Test2()
        //{
        //    var container = new IoCContainer();

        //    container.Register<IInterface, MyClass>();
        //    var createResult = container.Create<IInterface>();

        //    Assert.IsNotNull(createResult);
        //    Assert.AreEqual(typeof(MyClass), createResult.GetType());
        //    Assert.IsInstanceOfType(createResult, typeof(MyClass));
        //    Assert.IsInstanceOfType(createResult, typeof(IInterface));

        //}

        //[TestMethod]
        //public void SaveTest()
        //{
        //    var container = new IoCContainer();

        //    container.Register<ITextSaver, FileSystemSaver>();
        //    container.Register<ISettingsSaver, FileSystemSettingsSaver>();

        //    var notepadModel = new FakeNotepadModel(Container.MainContainer.Create<ITextSaver>(), (Container.MainContainer.Create<ISettingsSaver>()));
        //}
    }
    //public class FakeNotepadModel : INotepadModel
    //{
    //    private ITextSaver _saveMethod;
    //    public FakeNotepadModel(ITextSaver saveMethod)
    //    {
    //        _saveMethod = saveMethod;
    //    }

    //    public Result Save(string Text)
    //    {
    //        return Result.Saved;
    //    }

    //    public Result SaveAs(string Text)
    //    {
    //        return Result.Saved;
    //    }

    //    public string Load()
    //    {
    //        return null;
    //    }

    //    public void SaveSettings(Settings settings)
    //    {
    //        return
    //    }

    //    public Settings LoadSettings()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Clear()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class FakeFileSystemSaver : ITextSaver
    //{

    //    public Result Save(bool isNew, string text)
    //    {
    //    }

    //    public string Load()
    //    {
    //    }
    //}
}
