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
      Get ["/jobs/new"] = _ => View ["job_form.cshtml"];

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
          Request.Form ["account-username"]
        );
        newAccount.Save();
        return View ["accounts.cshtml", Account.GetAll()];
      };

      Post["/keyword"]=_=>{
        Job newJob = new Job(Request.Form["title"], Request.Form["descrip"], Request.Form["salary"], 1, 1);
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
        Request.Form ["account-username"]
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
      Post ["/jobs"] = _ => {
        Job newJob = new Job
        (
          Request.Form ["job-title"],
          Request.Form ["job-description"],
          Request.Form ["job-salary"]
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
          Request.Form ["job-salary"]
        );
        return View ["job.cshtml", selectedJob];
      };
      Post ["/jobs/{id}/{title}/deleted"] = parameters => {
        Job selectedJob = Job.Find(parameters.id);
        selectedJob.Delete();
        return View ["deleted_job.cshtml", selectedJob];
      };

      Get ["/accounts/{id}/rankedjobs"] = parameters => {
        Account selectedAccount = Account.Find(parameters.id);
        Dictionary<Job, int> rankedJobs = selectedAccount.GetRankedJobs();
        return View ["ranked.cshtml", rankedJobs];
      };
    }
  }
}
