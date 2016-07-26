using Nancy;
using System.Collections.Generic;

namespace JobBoard
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => View ["index.cshtml", Account.GetAll()];
      Get ["/accounts/new"] = _ =>  View ["account_form.cshtml"];

      Get ["/accounts"] = _ => {
        return View ["accounts.cshtml", Account.GetAll()];
      };

      Post ["/accounts"] = _ => {
        Account newAccount = new Account
        (
          Request.Form ["account-first-name"],
          Request.Form ["account-last-name"],
          Request.Form ["account-email"],
          Request.Form ["account-phone"],
          Request.Form ["account-education"],
          Request.Form ["account-resume"],
          Request.Form ["account-username"],
          Request.Form ["account-password"]
        );
        newAccount.Save();
        return View ["accounts.cshtml", Account.GetAll()];
      };

      Post["/keyword"]=_=>{
        Job newJob = new Job(Request.Form["title"], Request.Form["description"], Request.Form["salary"], Request.Form["company-id"], Request.Form["category-id"]);
        newJob.Save();
        return View["result.cshtml", newJob];
      };

      Get ["/accounts/{id}/{first_name}"] = parameters => {
        Account selectedAccount = Account.Find(parameters.id);
        return View ["account.cshtml", selectedAccount];
      };
      Patch ["/accounts/{id}/{first_name}/updated"] = parameters => {
        Account selectedAccount = Account.Find(parameters.id);
        selectedAccount.Update
        (
        Request.Form ["account-first-name"],
        Request.Form ["account-last-name"],
        Request.Form ["account-email"],
        Request.Form ["account-phone"],
        Request.Form ["account-education"],
        Request.Form ["account-resume"],
        Request.Form ["account-username"],
        Request.Form ["account-password"]
        );
        return View ["account.cshtml", selectedAccount];
      };
      Post ["/accounts/{id}/{first_name}/deleted"] = parameters => {
        Account selectedAccount = Account.Find(parameters.id);
        selectedAccount.DeleteOne();
        return View ["deleted_account.cshtml", selectedAccount];
      };
      Get ["/jobs"] = _ => {
        return View ["jobs.cshtml", Job.GetAll()];
      };

      Get ["/jobs/new"] = _ =>{
        Dictionary<string, object> model = new   Dictionary<string, object> {};
        List<Company> allCompanies = Company.GetAll();
        List<Category> allCategories = Category.GetAll();
        model.Add("allCompanies", allCompanies);
        model.Add("allCategories", allCategories);
        return View ["job_form.cshtml", model];
      };

      Post ["/jobs"] = _ => {
        Job newJob = new Job
        (
          Request.Form ["job-title"],
          Request.Form ["job-description"],
          Request.Form ["job-salary"],
          Request.Form ["company"],
          Request.Form ["category"]
        );
        newJob.Save();
        return View ["jobs.cshtml", Job.GetAll()];
      };
      Get ["/jobs/{id}/{title}"] = parameters => {
        Job selectedJob = Job.Find(parameters.id);
        return View ["job.cshtml", selectedJob];
      };
      Patch ["/jobs/{id}/{title}/updated"] = parameters => {
        Job selectedJob = Job.Find(parameters.id);
        selectedJob.Update
        (
          Request.Form ["job-title"],
          Request.Form ["job-description"],
          Request.Form ["job-salary"],
          Request.Form ["company-id"],
          Request.Form ["category-id"]
        );
        return View ["job.cshtml", selectedJob];
      };
      Post ["/jobs/{id}/{title}/deleted"] = parameters => {
        Job selectedJob = Job.Find(parameters.id);
        selectedJob.Delete();
        return View ["deleted_job.cshtml", selectedJob];
      };

      Get ["/companies"] = _ => {
        return View ["companies.cshtml", Company.GetAll()];
      };
      Get ["/companies/new"] = _ => View ["company_form.cshtml"];

      Post ["/companies"] = _ => {
        Company newCompany = new Company(Request.Form["company-name"]);
        newCompany.Save();
        return View ["companies.cshtml", Company.GetAll()];
      };
      Get ["/companies/{id}/{name}"] = parameters => {
        Company selectedCompany = Company.Find(parameters.id);
        return View ["company.cshtml", selectedCompany];
      };

      Get ["/categories"] = _ => {
        return View ["categories.cshtml", Category.GetAll()];
      };
      Get ["/categories/new"] = _ => View ["category_form.cshtml"];
      Post ["/categories"] = _ => {
        Category newCategory = new Category(Request.Form["category-name"]);
        newCategory.Save();
        return View ["categories.cshtml", Category.GetAll()];
      };
      Get ["/categories/{id}/{name}"] = parameters => {
        Category selectedCategory = Category.Find(parameters.id);
        return View ["category.cshtml", selectedCategory];
      };
    }
  }
}
