using Nancy;

namespace JobBoard
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => View ["index.cshtml"];
      Get ["/accounts/new"] = _ =>  View ["account_form.cshtml"];
      Get ["/jobs/new"] = _ => View ["job_form.cshtml"];
      Post ["/accounts"] = _ => {
        return View ["accounts.cshtml", Account.GetAll()];
      };
      Post ["/jobs"] = _ => {
        return View ["jobs.cshtml", Job.GetAll()];
      };
    }
  }
}
