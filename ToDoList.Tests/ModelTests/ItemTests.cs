using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {
    public void Dispose()
    {
      Item.ClearAll();
    }

    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      var newItem = new Item("test");
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      var description = "Walk the dog.";

      //Act
      var newItem = new Item(description);
      var result = newItem.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      var description = "Walk the dog.";
      var newItem = new Item(description);

      //Act
      var updatedDescription = "Do the dishes";
      newItem.Description = updatedDescription;
      var result = newItem.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      // Arrange
      var newList = new List<Item>();

      // Act
      var result = Item.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      var description01 = "Walk the dog";
      var description02 = "Wash the dishes";
      var newItem1 = new Item(description01);
      var newItem2 = new Item(description02);
      var newList = new List<Item> {newItem1, newItem2};

      //Act
      var result = Item.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      var description = "Walk the dog.";
      var newItem = new Item(description);

      //Act
      var result = newItem.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      //Arrange
      var description01 = "Walk the dog";
      var description02 = "Wash the dishes";
      var newItem1 = new Item(description01);
      var newItem2 = new Item(description02);

      //Act
      var result = Item.Find(2);

      //Assert
      Assert.AreEqual(newItem2, result);
    }
  }
}