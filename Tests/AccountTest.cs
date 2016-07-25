using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace JobBoard
{
  public class AccountTest : IDisposable
  {
    public AccountTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=job_board_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Account.DeleteAll();
    }

    [Fact]
    public void Test_GetAll_ReturnsZeroWhenDatabaseEmpty()
    {
      List<Account> testList = Account.GetAll();
      Assert.Equal(0, testList.Count);
    }

    [Fact]
    public void Test_Equals_ReturnsEqualForSameAccount()
    {
      Account testAccount = new Account("John", "Doe", "johndoe@gmail.com", "503-555-5555", 1, "This is my resume.");
      Account testAccount2 = new Account("John", "Doe", "johndoe@gmail.com", "503-555-5555", 1, "This is my resume.");
      Assert.Equal(testAccount, testAccount2);
    }

    [Fact]
    public void Test_Save_SavesAccountToDatabase()
    {
      Account testAccount = new Account("John", "Doe", "johndoe@gmail.com", "503-555-5555", 1, "This is my resume.");
      testAccount.Save();
      List<Account> resultAccounts = Account.GetAll();
      Assert.Equal(testAccount, resultAccounts[0]);
    }
  }
}
