using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace JobBoard
{
  public class Account
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phone;
    private int _education;
    private string _resume;

    public Account (string firstName, string lastName, string email, string phone, int education, string resume, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
      _email = email;
      _phone = phone;
      _education = education;
      _resume = resume;
    }

    public override bool Equals(System.Object otherAccount)
    {
      if (!(otherAccount is Account))
      {
        return false;
      }
      else
      {
        Account newAccount = (Account) otherAccount;
        bool idEquality = this.GetId() == newAccount.GetId();
        bool firstNameEquality = this.GetFirstName() == newAccount.GetFirstName();
        bool lastNameEquality = this.GetLastName() == newAccount.GetLastName();
        bool emailEquality = this.GetEmail() == newAccount.GetEmail();
        bool phoneEquality = this.GetPhone() == newAccount.GetPhone();
        bool educationEquality = this.GetEducation() == newAccount.GetEducation();
        bool resumeEquality = this.GetResume() == newAccount.GetResume();
        return (idEquality && firstNameEquality && lastNameEquality && emailEquality && phoneEquality && educationEquality && resumeEquality);
      }
    }

    public int GetId()
    {
      return _id;
    }

    public string GetFirstName()
    {
      return _firstName;
    }
    public string GetLastName()
    {
      return _lastName;
    }
    public string GetEmail()
    {
      return _email;
    }
    public string GetPhone()
    {
      return _phone;
    }
    public int GetEducation()
    {
      return _education;
    }
    public string GetResume()
    {
      return _resume;
    }

    public void SetFirstName(string newFirstName)
    {
      _firstName = newFirstName;
    }
    public void SetLastName(string newLastName)
    {
      _lastName = newLastName;
    }
    public void SetEmail(string newEmail)
    {
      _email = newEmail;
    }
    public void SetPhone(string newPhone)
    {
      _phone = newPhone;
    }
    public void SetEducation(int newEducation)
    {
      _education = newEducation;
    }
    public void SetResume(string newResume)
    {
      _resume = newResume;
    }

    public static List<Account> GetAll()
    {
      List<Account> allAccounts = new List<Account>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM accounts;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int accountId = rdr.GetInt32(0);
        string accountFirstName = rdr.GetString(1);
        string accountLastName = rdr.GetString(2);
        string accountEmail = rdr.GetString(3);
        string accountPhone = rdr.GetString(4);
        int accountEducation = rdr.GetInt32(5);
        string accountResume = rdr.GetString(6);

        Account newAccount = new Account(accountFirstName, accountLastName, accountEmail, accountPhone, accountEducation, accountResume, accountId);
        allAccounts.Add(newAccount);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allAccounts;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO accounts (first_name, last_name, email, phone, education, resume) OUTPUT INSERTED.id VALUES (@FirstName, @LastName, @Email, @Phone, @Education, @Resume);", conn);

      SqlParameter firstNameParameter = new SqlParameter();
      firstNameParameter.ParameterName = "@FirstName";
      firstNameParameter.Value = this.GetFirstName();
      cmd.Parameters.Add(firstNameParameter);

      SqlParameter lastNameParameter = new SqlParameter();
      lastNameParameter.ParameterName = "@LastName";
      lastNameParameter.Value = this.GetLastName();
      cmd.Parameters.Add(lastNameParameter);

      SqlParameter emailParameter = new SqlParameter();
      emailParameter.ParameterName = "@Email";
      emailParameter.Value = this.GetEmail();
      cmd.Parameters.Add(emailParameter);

      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@Phone";
      phoneParameter.Value = this.GetPhone();
      cmd.Parameters.Add(phoneParameter);

      SqlParameter educationParameter = new SqlParameter();
      educationParameter.ParameterName = "@Education";
      educationParameter.Value = this.GetEducation();
      cmd.Parameters.Add(educationParameter);

      SqlParameter resumeParameter = new SqlParameter();
      resumeParameter.ParameterName = "@Resume";
      resumeParameter.Value = this.GetResume();
      cmd.Parameters.Add(resumeParameter);


      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
     SqlConnection conn = DB.Connection();
     conn.Open();
     SqlCommand cmd = new SqlCommand("DELETE FROM accounts;", conn);
     cmd.ExecuteNonQuery();
    }
  }
}
