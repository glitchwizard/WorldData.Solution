using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace WorldData.Controllers
{
    public class CountryController : Controller
    {

      // [HttpGet("/countries")]
      // public ActionResult Index()
      // {
      //   return View();
      // }
      [HttpGet("/countries/show")]
      public ActionResult Index()
      {
        List<Country> newCountryList = new List<Country>{};
        newCountryList = Country.GetAllCountryInfo();
        return View(newCountryList);
      }

      [HttpGet("/countries/{countryCode}")]
      public ActionResult ShowCountry(string countryCode)
      {

        Country newCountry = new Country();
        Console.WriteLine("--------------");
        Console.WriteLine("This is the Country Code: " + countryCode);

        MySqlConnection conn = DB.Connection();

        conn.Open();

        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@CountryCode", countryCode);
        Console.WriteLine("This is the count of parameters: " + cmd.Parameters.Count);
        Console.WriteLine("This is the Parameter Name at [0]: {0}, and this is it's value: {1}",cmd.Parameters[0].ParameterName,cmd.Parameters[0].Value);
        cmd.CommandText = @"SELECT * FROM country WHERE code = @CountryCode";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

        while (rdr.Read())
        {
          string code = rdr.GetString(0);
          string countryName = rdr.GetString(1);
          string countryContinent = rdr.GetString(2);
          string countryRegion = rdr.GetString(3);
          int countryPopulation = rdr.GetInt32(6);
          string countryGovForm = rdr.GetString(11);

          newCountry.CountryCode = code;
          newCountry.CountryName = countryName;
          newCountry.CountryContinent = countryContinent;
          newCountry.CountryRegion = countryRegion;
          newCountry.CountryPopulation = countryPopulation;
          newCountry.CountryGovForm= countryGovForm;

        }

        conn.Close();

        if (conn != null)
        {
          conn.Dispose();
        }
        return View(newCountry);
      }

    }
}
