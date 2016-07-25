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
      Job firstJob = new Job("Job", "Cool Job", 45000);
      Job secondJob = new Job("Job", "Cool Job", 45000);
      Assert.Equal(firstJob, secondJob);
    }

    [Fact]
    public void Test_Save_SavesJobToDatabase()
    {
      Job testJob = new Job("Job", "Cool Job", 45000);
      testJob.Save();

      List<Job> testJobs = new List<Job>{testJob};
      List<Job> resultJobs = Job.GetAll();

      Assert.Equal(testJobs, resultJobs);
    }

    [Fact]
    public void Test_Save_AssignsIdToJob()
    {

      Job testJob = new Job("Job", "Cool Job", 45000);
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
    Job testJob = new Job("Job", "Cool Job", 45000);
      testJob.Save();

      //Act
      Job foundJob = Job.Find(testJob.GetId());

      //Assert
      Assert.Equal(testJob, foundJob);
    }

    [Fact]
    public void Test_Update_UpdatesJobInDatabase()
    {
      Job testJob = new Job("Job", "Cool Job", 45000);
      testJob.Save();
      string newTitle = "Dr. Love";
      string newDesription = "love people";
      int newSalary= 5000000;

      testJob.Update(newTitle, newDesription, newSalary);

      Assert.Equal(newTitle, testJob.GetTitle());
    }

    [Fact]
    public void Test_Delete_DeleteJobfromDB()
    {
      Job firstJob = new Job("Job", "Cool Job", 45000);
      Job secondJob = new Job("Job", "Cool Job", 45000);
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

      Job testJob = new Job("Job", "A cool job for a Cool Person what a job", 45000);
      testJob.Save();

      Dictionary<string, int> result = testJob.UniqueWordCount();
      Dictionary<string, int> expectedResult = new Dictionary<string, int> {{"a", 3}, {"cool", 2}, {"job", 2}, {"for", 1}, {"person", 1}, {"what", 1}};

      //Assert
      Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Test_UniqueWordCount_HandlesPunctuationSensibly()
    {

      Job testJob = new Job("Job", "A: cool; job, for a) Cool! Person. what? a job", 45000);
      testJob.Save();

      Dictionary<string, int> result = testJob.UniqueWordCount();
      Dictionary<string, int> expectedResult = new Dictionary<string, int> {{"a", 3}, {"cool", 2}, {"job", 2}, {"for", 1}, {"person", 1}, {"what", 1}};

      //Assert
      Assert.Equal(expectedResult, result);
    }

    public void Dispose()
    {
      Job.DeleteAll();
    }
  }
}
