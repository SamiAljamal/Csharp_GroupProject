using Nancy;

namespace JobBoard
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => View ["index.cshtml", Account.GetAll()];
      Get ["/accounts/new"] = _ =>  View ["account_form.cshtml"];
      Get ["/jobs/new"] = _ => View ["job_form.cshtml"];
      Post ["/accounts"] = _ => {
        Account newAccount = new Account
        (
          Request.Form ["account-first-name"],
          Request.Form ["account-last-name"],
          Request.Form ["account-email"],
          Request.Form ["account-phone"],
          Request.Form ["account-education"],
          Request.Form ["account-resume"]
        );
        newAccount.Save();
        return View ["accounts.cshtml", Account.GetAll()];
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
        Request.Form ["account-resume"]
        );
        return View ["account.cshtml", selectedAccount];
      };
      Post ["/accounts/{id}/{first_name}/deleted"] = parameters => {
        Account selectedAccount = Account.Find(parameters.id);
        selectedAccount.DeleteOne();
        return View ["deleted_account.cshtml", selectedAccount];
      };
      Get ["/jobs"] = _ => {
        return View ["jobs.cshtml"];
      };
    }
  }
}
