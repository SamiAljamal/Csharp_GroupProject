using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace JobBoard
{
  public class KeywordTest : IDisposable
  {
    public KeywordTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=job_board_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Keyword.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfKeywordsAreTheSame()
    {
      Keyword firstKeyword = new Keyword("Keyword");
      Keyword secondKeyword = new Keyword("Keyword");
      Assert.Equal(firstKeyword, secondKeyword);
    }

    [Fact]
    public void Test_Save_SavesKeywordToDatabase()
    {
      Keyword testKeyword = new Keyword("Keyword");
      testKeyword.Save();

      List<Keyword> testKeywords = new List<Keyword>{testKeyword};
      List<Keyword> resultKeywords = Keyword.GetAll();

      Assert.Equal(testKeywords, resultKeywords);
    }

    [Fact]
    public void Test_Save_AssignsIdToKeyword()
    {

      Keyword testKeyword = new Keyword("Keyword");
      testKeyword.Save();
      Keyword savedKeyword = Keyword.GetAll()[0];

      int result = savedKeyword.GetId();
      int testId = testKeyword.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsKeywordInDatabase()
    {
      //Arrange
      Keyword testKeyword = new Keyword("Keyword");
      testKeyword.Save();

      //Act
      Keyword foundKeyword = Keyword.Find(testKeyword.GetId());

      //Assert
      Assert.Equal(testKeyword, foundKeyword);
    }

    [Fact]
    public void Test_Update_UpdatesKeywordInDatabase()
    {
      Keyword testKeyword = new Keyword("Keyword");
      testKeyword.Save();
      string newWord = "Keyword2";

      testKeyword.Update(newWord);

      Assert.Equal(newWord, testKeyword.GetWord());
    }

    [Fact]
    public void Test_Delete_DeleteKeywordfromDB()
    {
      Keyword firstKeyword = new Keyword("Keyword");
      Keyword secondKeyword = new Keyword("Keyword");
      firstKeyword.Save();
      secondKeyword.Save();

      List<Keyword> allcourses = new List<Keyword>{firstKeyword,secondKeyword};
      allcourses.Remove(firstKeyword);
      firstKeyword.Delete();

      Assert.Equal(allcourses, Keyword.GetAll());
    }
    
    public void Dispose()
    {
      Keyword.DeleteAll();
    }
  }
}
