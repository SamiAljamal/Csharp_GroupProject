using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace JobBoard
{
  public class Job
  {
    private string _title;
    private string _description;
    private int _salary;
    private int _id;

    public Job(string title, string description, int salary, int id=0)
    {
      _title = title;
      _description = description;
      _salary = salary;
      _id = id;
    }

    public string GetTitle()
    {
      return _title;
    }

    public string GetDescription()
    {
      return _description;
    }

    public int GetId()
    {
      return _id;
    }
    public int GetSalary()
    {
      return _salary;
    }

    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }

    public void SetSalary(int newSalary)
    {
      _salary = newSalary;
    }

    public override bool Equals(System.Object otherJob)
    {
      if (!(otherJob is Job))
      {
        return false;
      }
      else
      {
        Job newJob = (Job) otherJob;
        bool idEquality = this.GetId() == newJob.GetId();
        bool titleEquality = this.GetTitle() == newJob.GetTitle();
        bool descriptionEquality = this.GetDescription()== newJob.GetDescription();
        bool salaryEquality = this.GetSalary()== newJob.GetSalary();
        return (idEquality && titleEquality && descriptionEquality && salaryEquality);
      }
    }

    public static List<Job> GetAll()
    {
      List<Job> allJobs = new List<Job>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM jobs;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int JobId = rdr.GetInt32(0);
        string JobTitle = rdr.GetString(1);
        string JobDesctiption = rdr.GetString(2);
        int JobSalary = rdr.GetInt32(3);
        Job newJob = new Job(JobTitle, JobDesctiption, JobSalary, JobId);
        allJobs.Add(newJob);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allJobs;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO jobs (title, description, salary) OUTPUT INSERTED.id VALUES (@JobTitle, @JobDescription, @JobSalary);", conn);

      SqlParameter titleParameter = new SqlParameter();
      titleParameter.ParameterName = "@JobTitle";
      titleParameter.Value = this.GetTitle();

      SqlParameter descriptionParameter = new SqlParameter();
      descriptionParameter.ParameterName = "@JobDescription";
      descriptionParameter.Value = this.GetDescription();

      SqlParameter salaryParameter = new SqlParameter();
      salaryParameter.ParameterName = "@JobSalary";
      salaryParameter.Value = this.GetSalary();

      cmd.Parameters.Add(descriptionParameter);
      cmd.Parameters.Add(titleParameter);
      cmd.Parameters.Add(salaryParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Job Find(int id)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand ("SELECT * FROM jobs WHERE id = @JobId;", conn);

      SqlParameter JobIdParameter = new SqlParameter();
      JobIdParameter.ParameterName = "@JobId";
      JobIdParameter.Value = id.ToString();
      cmd.Parameters.Add(JobIdParameter);
      rdr = cmd.ExecuteReader();

      int foundJobId = 0;
      string foundJobName = null;
      string foundJobDescription = null;
      int foundJobSalary=0;

      while(rdr.Read())
      {
        foundJobId = rdr.GetInt32(0);
        foundJobName = rdr.GetString(1);
        foundJobDescription = rdr.GetString(2);
        foundJobSalary = rdr.GetInt32(3);

      }
      Job foundJob = new Job(foundJobName, foundJobDescription, foundJobSalary, foundJobId);

      if(rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundJob;
    }

    public void Update(string newTitle, string newDescription, int newSalary)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      this.SetDescription(newDescription);
      this.SetTitle(newTitle);
      this.SetSalary(newSalary);

      SqlCommand cmd = new SqlCommand("UPDATE jobs SET title = @NewTitle WHERE id = @JobId; UPDATE jobs SET description = @NewDescription WHERE id = @JobId; UPDATE jobs SET salary = @NewSalary WHERE id = @JobId;", conn);

      SqlParameter newTitleParameter = new SqlParameter();
      newTitleParameter.ParameterName = "@NewTitle";
      newTitleParameter.Value = newTitle;
      cmd.Parameters.Add(newTitleParameter);

      SqlParameter newDescriptionParameter = new SqlParameter();
      newDescriptionParameter.ParameterName = "@NewDescription";
      newDescriptionParameter.Value = newDescription;
      cmd.Parameters.Add(newDescriptionParameter);

      SqlParameter newSalaryParameter = new SqlParameter();
      newSalaryParameter.ParameterName = "@NewSalary";
      newSalaryParameter.Value = newSalary;
      cmd.Parameters.Add(newSalaryParameter);

      SqlParameter JobIdParameter = new SqlParameter();
      JobIdParameter.ParameterName = "@JobId";
      JobIdParameter.Value = this.GetId();
      cmd.Parameters.Add(JobIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM jobs WHERE id = @JobId;", conn);

      SqlParameter JobIdParameter = new SqlParameter();
      JobIdParameter.ParameterName = "@JobId";
      JobIdParameter.Value = this.GetId();

      cmd.Parameters.Add(JobIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM jobs;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
