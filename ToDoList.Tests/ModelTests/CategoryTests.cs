using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTest : IDisposable
  {
    public void Dispose()
    {
      Category.ClearAll();
    }

    [TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
      var newCategory = new Category("test category");
      Assert.AreEqual(typeof(Category), newCategory.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      var name = "Test Category";
      var newCategory = new Category(name);

      //Act
      var result = newCategory.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsCategoryId_Int()
    {
      //Arrange
      var name = "Test Category";
      var newCategory = new Category(name);

      //Act
      var result = newCategory.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    {
      //Arrange
      var name01 = "Work";
      var name02 = "School";
      var newCategory1 = new Category(name01);
      var newCategory2 = new Category(name02);
      var newList = new List<Category> {newCategory1, newCategory2};

      //Act
      var result = Category.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectCategory_Category()
    {
      //Arrange
      var name01 = "Work";
      var name02 = "School";
      var newCategory1 = new Category(name01);
      var newCategory2 = new Category(name02);

      //Act
      var result = Category.Find(2);

      //Assert
      Assert.AreEqual(newCategory2, result);
    }

    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      //Arrange
      var description = "Walk the dog.";
      var newItem = new Item(description);
      var newList = new List<Item> {newItem};
      var name = "Work";
      var newCategory = new Category(name);
      newCategory.AddItem(newItem);

      //Act
      var result = newCategory.Items;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}