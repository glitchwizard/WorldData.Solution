using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;

namespace WorldData.Controllers
{
    public class CountryController : Controller
    {

      [HttpGet("/countries")]
      public ActionResult Index()
      {
        return View();
      }
      [HttpGet("/countries/show")]
      public ActionResult Show()
      {
        List<Country> newCountryList = new List<Country>{};
        newCountryList = Country.GetAllCountryInfo();
        return View(newCountryList);
      }

    }
}
