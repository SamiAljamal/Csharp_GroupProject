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
  }
}
