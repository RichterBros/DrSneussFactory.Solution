using Microsoft.AspNetCore.Mvc;

namespace UniversityRegistrar.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Index(string searchOption, string searchString)
    {
      if (searchOption == "courses")
      {
        return RedirectToAction("Index", "Courses", new {searchQuery = searchString});
      }
      else
      {
        return RedirectToAction("Index", "Students", new {searchQuery = searchString});
      }       
    }
  }
}