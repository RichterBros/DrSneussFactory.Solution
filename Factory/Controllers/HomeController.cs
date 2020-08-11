using Microsoft.AspNetCore.Mvc;

namespace DrSneuss.Controllers
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
      if (searchOption == "machines")
      {
        return RedirectToAction("Index", "Machines", new {searchQuery = searchString});
      }
      else
      {
        return RedirectToAction("Index", "Engineers", new {searchQuery = searchString});
      }       
    }
  }
}