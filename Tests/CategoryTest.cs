using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace JobBoard
{
  public class CategoryTest : IDisposable
  {
    public CategoryTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=job_board_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Category.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfCategorysAreTheSame()
    {
      Category firstCategory = new Category("Category");
      Category secondCategory = new Category("Category");
      Assert.Equal(firstCategory, secondCategory);
    }

    [Fact]
    public void Test_Save_SavesCategoryToDatabase()
    {
      Category testCategory = new Category("Category");
      testCategory.Save();

      List<Category> testCategorys = new List<Category>{testCategory};
      List<Category> resultCategorys = Category.GetAll();

      Assert.Equal(testCategorys, resultCategorys);
    }

    [Fact]
    public void Test_Save_AssignsIdToCategory()
    {

      Category testCategory = new Category("Category");
      testCategory.Save();
      Category savedCategory = Category.GetAll()[0];

      int result = savedCategory.GetId();
      int testId = testCategory.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsCategoryInDatabase()
    {
      //Arrange
    Category testCategory = new Category("Category");
      testCategory.Save();

      //Act
      Category foundCategory = Category.Find(testCategory.GetId());

      //Assert
      Assert.Equal(testCategory, foundCategory);
    }

    [Fact]
    public void Test_Update_UpdatesCategoryInDatabase()
    {
      Category testCategory = new Category("Category");
      testCategory.Save();
      string newName = "Category2";

      testCategory.Update(newName);

      Assert.Equal(newName, testCategory.GetName());
    }

    [Fact]
    public void Test_Delete_DeleteCategoryfromDB()
    {
      Category firstCategory = new Category("Category");
      Category secondCategory = new Category("Category");
      firstCategory.Save();
      secondCategory.Save();

      List<Category> allcourses = new List<Category>{firstCategory,secondCategory};
      allcourses.Remove(firstCategory);
      firstCategory.Delete();

      Assert.Equal(allcourses, Category.GetAll());
    }
    public void Dispose()
    {
      Category.DeleteAll();
    }
  }
}
