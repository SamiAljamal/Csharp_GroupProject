using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Linq;

namespace JobBoard
{
  public class Job
  {
    private string _title;
    private string _description;
    private int _salary;
    private int _id;

    public Job(string title, string description, int salary, int id = 0)
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


      if (newTitle == null)
      {
        newTitle = this.GetTitle();
      }
      if (newDescription == null)
      {
        newDescription = this.GetDescription();
      }


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

    public Dictionary<string, int> UniqueWordCount()
    {
      List<string> prepositions = new List<string>{"aboard", "about", "above", "across", "after", "against", "along", "amid", "among", "anti", "around", "as", "at", "before", "behind", "below", "beneath", "beside", "besides", "between", "beyond", "but", "by", "concerning", "considering", "despite", "down", "during", "except", "excepting", "excluding", "following", "for", "from", "in", "inside", "into", "like", "minus", "near", "of", "off", "on", "onto", "opposite", "outside", "over", "past", "per", "plus", "regarding", "round", "save", "since", "than", "through", "to", "toward", "towards", "underneath", "under", "unlike", "until", "up", "upon", "versus", "via", "with", "within", "without", "a", "an", "the"};
      List<string> commonWords = new List<string>{"any","that","our","you","just","and","this","or","is","will","are","be","can","have","had"};
      Dictionary<string, int> UniqueWords = new Dictionary<string, int>{};
      string jobDescription = this.GetDescription().ToLower() + " ";
      string backTrimmedJobDescription = Regex.Replace(jobDescription, @"[\.,\,,\?,\!,\),\;,\:] ", " ");
      string trimmedJobDescription = Regex.Replace(backTrimmedJobDescription, @" [\(]", " ");
      Regex whitespace = new Regex(@"\s+");
      string[] wordList = whitespace.Split(trimmedJobDescription);
      for(int i=0; i < wordList.Length-1; i++)
      {
        if(!prepositions.Contains(wordList[i]) && !commonWords.Contains(wordList[i]))
        {
          string trimedWordOne = wordList[i];

          int count=0;
          if(!UniqueWords.ContainsKey(wordList[i]))
          {
            for(int j = i; j < wordList.Length-1; j++)
            {
              if(wordList[i]==wordList[j]) count+=1;
            }
            UniqueWords.Add(wordList[i], count);
          }
        }
      }
      Dictionary<string, int> items = new Dictionary<string, int>();
      var sorted = from pair in UniqueWords orderby pair.Value descending select pair;
      foreach (KeyValuePair<string, int> pair in sorted)
      {
        items.Add(pair.Key, pair.Value);
      }

      return items;
    }
    public void SaveWords()
    {
      Dictionary<string, int> newDictionary = this.UniqueWordCount();
      foreach(KeyValuePair<string, int> pair in newDictionary)
      {
        SqlConnection conn = DB.Connection();
        SqlDataReader rdr = null;
        conn.Open();

        SqlCommand cmd = new SqlCommand ("SELECT * FROM keywords WHERE word = @Keyword;", conn);

        SqlParameter keywordParameter = new SqlParameter();
        keywordParameter.ParameterName = "@Keyword";
        keywordParameter.Value = pair.Key;
        cmd.Parameters.Add(keywordParameter);
        rdr = cmd.ExecuteReader();

        int foundKeywordId = -1;

        while(rdr.Read())
        {
          foundKeywordId = rdr.GetInt32(0);
        }
        if (rdr != null) rdr.Close();
        if(foundKeywordId==-1)
        {
          SqlDataReader rdr2 = null;
          SqlCommand cmd2 = new SqlCommand("INSERT INTO keywords (word) OUTPUT INSERTED.id VALUES (@Keyword);", conn);

          SqlParameter keywordParameter2 = new SqlParameter();
          keywordParameter2.ParameterName = "@Keyword";
          keywordParameter2.Value = pair.Key;
          cmd2.Parameters.Add(keywordParameter2);

          rdr2 = cmd2.ExecuteReader();

          while(rdr2.Read())
          {
            foundKeywordId = rdr2.GetInt32(0);
          }
          if (rdr2 != null) rdr2.Close();
        }
        SqlCommand cmd3 = new SqlCommand("INSERT INTO jobs_keywords (job_id, keyword_id, number_of_repeats) VALUES (@JobId, @KeywordId, @Repeats);", conn);

        SqlParameter idParameter = new SqlParameter();
        idParameter.ParameterName = "@JobId";
        idParameter.Value = this.GetId();

        SqlParameter keywordIdParameter = new SqlParameter();
        keywordIdParameter.ParameterName = "@KeywordId";
        keywordIdParameter.Value = foundKeywordId;

        SqlParameter repeatsParameter = new SqlParameter();
        repeatsParameter.ParameterName = "@Repeats";
        repeatsParameter.Value = pair.Value;

        cmd3.Parameters.Add(keywordIdParameter);
        cmd3.Parameters.Add(idParameter);
        cmd3.Parameters.Add(repeatsParameter);

        cmd3.ExecuteNonQuery();

        if (conn != null) conn.Close();
      }
    }

    public static List<Job> SearchJobsbyKeyword(string searchterm)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand ("SELECT jobs.* FROM keywords JOIN jobs_keywords ON (keyword.id = jobs_keywords.keyword_id) JOIN jobs ON (jobs_keywords.job_id = jobs.id) where keywords.word = @keyword", conn);

      SqlParameter keywordParameter = new SqlParameter();
      keywordParameter.ParameterName = "@keyword";
      keywordParameter.Value = searchterm;
      cmd.Parameters.Add(keywordParameter);
      rdr = cmd.ExecuteReader();

      int foundJobId = 0;
      string foundJobName = null;
      string foundJobDescription = null;
      int foundJobSalary=0;

      List<Job> searchJob = new List<Job>{};
      while(rdr.Read())
      {
        foundJobId = rdr.GetInt32(0);
        foundJobName = rdr.GetString(1);
        foundJobDescription = rdr.GetString(2);
        foundJobSalary = rdr.GetInt32(3);

        Job foundJob = new Job(foundJobName, foundJobDescription, foundJobSalary, foundJobId);
        searchJob.Add(foundJob);
      }


      if(rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return searchJob;

    }
  }
}
