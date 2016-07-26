// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Data.SqlClient;
// using Xunit;
//
// namespace JobBoard
// {
//   public class AccountTest : IDisposable
//   {
//     public AccountTest()
//     {
//       DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=job_board_test;Integrated Security=SSPI;";
//     }
//     public void Dispose()
//     {
//       Account.DeleteAll();
//     }
//
//     [Fact]
//     public void Test_GetAll_ReturnsZeroWhenDatabaseEmpty()
//     {
//       List<Account> testList = Account.GetAll();
//       Assert.Equal(0, testList.Count);
//     }
//
//     [Fact]
//     public void Test_Equals_ReturnsEqualForSameAccount()
//     {
//       Account testAccount = new Account("John", "Doe", "johndoe@gmail.com", "503-555-5555", 1, "This is my resume.", "jdoe", "iamdead");
//       Account testAccount2 = new Account("John", "Doe", "johndoe@gmail.com", "503-555-5555", 1, "This is my resume.", "jdoe", "iamdead");
//       Assert.Equal(testAccount, testAccount2);
//     }
//
//     [Fact]
//     public void Test_Save_SavesAccountToDatabase()
//     {
//       Account testAccount = new Account("John", "Doe", "johndoe@gmail.com", "503-555-5555", 1, "This is my resume.", "jdoe", "iamdead");
//       testAccount.Save();
//       List<Account> resultAccounts = Account.GetAll();
//       Assert.Equal(testAccount, resultAccounts[0]);
//     }
//
//     [Fact]
//     public void Test_Find_ReturnsFoundAccount()
//     {
//       Account testAccount = new Account("John", "Doe", "johndoe@gmail.com", "503-555-5555", 1, "This is my resume.", "jdoe", "iamdead");
//       testAccount.Save();
//       Account foundAccount = Account.Find(testAccount.GetId());
//       Assert.Equal(testAccount, foundAccount);
//     }
//
//     [Fact]
//     public void Test_Update_UpdatesAccountInDatabase()
//     {
//       Account testAccount = new Account("John", "Doe", "johndoe@gmail.com", "503-555-5555", 1, "This is my resume.", "jdoe", "iamdead");
//       testAccount.Save();
//       string testLastName = "Jones";
//       testAccount.Update(testAccount.GetFirstName(), testLastName, testAccount.GetEmail(), testAccount.GetPhone(), 1, testAccount.GetResume(), testAccount.GetUsername(), testAccount.GetPassword());
//       Assert.Equal(testLastName, testAccount.GetLastName());
//     }
//
//     [Fact]
//     public void Test_Delete_DeletesAccountFromDatabase()
//     {
//       Account testAccount = new Account("John", "Doe", "johndoe@gmail.com", "503-555-5555", 1, "This is my resume.", "jdoe", "iamdead");
//       testAccount.Save();
//       Account testAccount2 = new Account("Jane", "Roe", "janeroee@gmail.com", "971-555-5555", 2, "This is also my resume.", "janedoe", "iamalsodead");
//       testAccount2.Save();
//       List<Account> testAccounts = new List<Account> {testAccount2};
//       testAccount.DeleteOne();
//       Assert.Equal(testAccounts, Account.GetAll());
//     }
//   }
// }
