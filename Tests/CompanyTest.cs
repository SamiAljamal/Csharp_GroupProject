using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace JobBoard
{
  public class CompanyTest : IDisposable
  {
    public CompanyTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=job_board_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Company.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfCompanysAreTheSame()
    {
      Company firstCompany = new Company("Company");
      Company secondCompany = new Company("Company");
      Assert.Equal(firstCompany, secondCompany);
    }

    [Fact]
    public void Test_Save_SavesCompanyToDatabase()
    {
      Company testCompany = new Company("Company");
      testCompany.Save();

      List<Company> testCompanys = new List<Company>{testCompany};
      List<Company> resultCompanys = Company.GetAll();

      Assert.Equal(testCompanys, resultCompanys);
    }

    [Fact]
    public void Test_Save_AssignsIdToCompany()
    {

      Company testCompany = new Company("Company");
      testCompany.Save();
      Company savedCompany = Company.GetAll()[0];

      int result = savedCompany.GetId();
      int testId = testCompany.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsCompanyInDatabase()
    {
      //Arrange
    Company testCompany = new Company("Company");
      testCompany.Save();

      //Act
      Company foundCompany = Company.Find(testCompany.GetId());

      //Assert
      Assert.Equal(testCompany, foundCompany);
    }

    [Fact]
    public void Test_Update_UpdatesCompanyInDatabase()
    {
      Company testCompany = new Company("Company");
      testCompany.Save();
      string newName = "Corporation";

      testCompany.Update(newName);

      Assert.Equal(newName, testCompany.GetName());
    }

    [Fact]
    public void Test_Delete_DeleteCompanyfromDB()
    {
      Company firstCompany = new Company("Company");
      Company secondCompany = new Company("Company");
      firstCompany.Save();
      secondCompany.Save();

      List<Company> allcourses = new List<Company>{firstCompany,secondCompany};
      allcourses.Remove(firstCompany);
      firstCompany.Delete();

      Assert.Equal(allcourses, Company.GetAll());
    }
    public void Dispose()
    {
      Company.DeleteAll();
    }
  }
}
