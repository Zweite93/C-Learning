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
}
