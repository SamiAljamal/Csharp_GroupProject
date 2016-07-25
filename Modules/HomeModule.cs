using Nancy;

namespace JobBoard
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"]=_=>{
        return View["index.cshtml"];
      };

      Post["/keyword"]=_=>{
        Job newJob = new Job(Request.Form["title"], Request.Form["descrip"], Request.Form["salary"]);
        newJob.Save();
        return View["result.cshtml", newJob];
      };
    }
  }
}
