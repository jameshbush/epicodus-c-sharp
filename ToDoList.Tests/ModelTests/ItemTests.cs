using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest
  {
    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      var item1 = new Item {Description = "clean"};
      var item2 = new Item {Description = "clean"};
      Assert.AreNotEqual(item1, item2);
    }
  }
}