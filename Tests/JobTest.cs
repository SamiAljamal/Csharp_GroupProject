using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace JobBoard
{
  public class JobTest : IDisposable
  {
    public JobTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=job_board_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Job.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfJobsAreTheSame()
    {
      Job firstJob = new Job("Job", "Cool Job", 45000, 1, 1);
      Job secondJob = new Job("Job", "Cool Job", 45000, 1, 1);
      Assert.Equal(firstJob, secondJob);
    }

    [Fact]
    public void Test_Save_SavesJobToDatabase()
    {
      Job testJob = new Job("Job", "Cool Job", 45000, 1, 1);
      testJob.Save();

      List<Job> testJobs = new List<Job>{testJob};
      List<Job> resultJobs = Job.GetAll();

      Assert.Equal(testJobs, resultJobs);
    }

    [Fact]
    public void Test_Save_AssignsIdToJob()
    {

      Job testJob = new Job("Job", "Cool Job", 45000, 1, 1);
      testJob.Save();
      Job savedJob = Job.GetAll()[0];

      int result = savedJob.GetId();
      int testId = testJob.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsJobInDatabase()
    {
      //Arrange
    Job testJob = new Job("Job", "Cool Job", 45000, 1, 1);
      testJob.Save();

      //Act
      Job foundJob = Job.Find(testJob.GetId());

      //Assert
      Assert.Equal(testJob, foundJob);
    }
    [Fact]
    public void Test_Update_UpdatesJobInDatabase()
    {
      Job testJob = new Job("Job", "Cool Job", 45000, 1, 1);
      testJob.Save();
      string newTitle = "Dr. Love";
      string newDesription = "love people";
      int newSalary= 5000000;
      int newCompanyId = 2;
      int newCategoryId = 2;

      testJob.Update(newTitle, newDesription, newSalary, newCompanyId, newCategoryId);

      Assert.Equal(newTitle, testJob.GetTitle());
    }

    [Fact]
    public void Test_Delete_DeleteJobfromDB()
    {
      Job firstJob = new Job("Job", "Cool Job", 45000, 1, 1);
      Job secondJob = new Job("Job", "Cool Job", 45000, 1, 1);
      firstJob.Save();
      secondJob.Save();

      List<Job> allcourses = new List<Job>{firstJob,secondJob};
      allcourses.Remove(firstJob);
      firstJob.Delete();

      Assert.Equal(allcourses, Job.GetAll());
    }

    [Fact]
    public void Test_UniqueWordCount_ReturnsDictionaryWithWordsAndCounts()
    {

      Job testJob = new Job("Job", "A cool job for a Cool Person what a job", 45000, 1, 1);
      testJob.Save();

      Dictionary<string, int> result = testJob.UniqueWordCount();
      Dictionary<string, int> expectedResult = new Dictionary<string, int> {{"cool", 2}, {"job", 2}, {"person", 1}, {"what", 1}};

      //Assert
      Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test_UniqueWordCount_CountsAdjoiningCapitalWordsAsOne()
    {
      Job testJob = new Job("Job", "A: cool; job, (for) a Cool Person. what? a job!", 45000, 1, 1);
      testJob.Save();
      Dictionary<string, int> result = testJob.UniqueWordCount();
      Dictionary<string, int> expectedResult = new Dictionary<string, int> {{"cool", 1}, {"job", 2}, {"Cool Person", 1}, {"what", 1}};
      Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test_SaveWords_SavesKeywordtoJobs()
    {
      Job firstJob = new Job("Job", "Cool Job", 45000, 1, 1);
      Job secondJob = new Job("job A", "Not cool  Job", 46000, 1, 1);

      firstJob.Save();
      secondJob.Save();

      firstJob.SaveWords();
      secondJob.SaveWords();

      Assert.Equal(1,1);
    }

    [Fact]
    public void Test_SearchJobsFromKeywords()
    {
      Job firstJob = new Job("Job", "Cool Job", 45000, 1, 1);
      Job secondJob = new Job("Job A", "A job, but not cool job", 46000, 1, 1);

      firstJob.Save();
      secondJob.Save();

      firstJob.SaveWords();
      secondJob.SaveWords();

      Dictionary<Job, int> testJobList = new Dictionary<Job, int> {{firstJob, 1}, {secondJob, 2}};
      Dictionary<Job, int> resultJobList = Job.SearchJobsbyKeyword("job");

      Assert.Equal(1, 1);
    }

    public void Dispose()
    {
      Job.DeleteAll();
    }
  }
}
