using Microsoft.AspNetCore.Mvc;

namespace WorldData.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}
