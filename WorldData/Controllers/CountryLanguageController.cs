using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
    public class CountryLanguageController : Controller
    {

      [HttpGet("/pigs")]
      public ActionResult Index()
      {
        return View();
      }

    }
}
