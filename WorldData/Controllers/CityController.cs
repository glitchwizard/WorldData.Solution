using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
    public class CityController : Controller
    {

      [HttpGet("/cats")]
      public ActionResult Index()
      {
        return View();
      }

    }
}
