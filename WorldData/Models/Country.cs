using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace WorldData.Models
{
  public class Country
  {
    public string CountryCode {get;set;}
    public string CountryName {get;set;}
    public string CountryContinent {get;set;}
    public string CountryRegion {get;set;}
    public int CountryPopulation {get;set;}
    public string CountryGovForm {get;set;}

    public Country (string CountryCode, string CountryName, string CountryContinent, string CountryRegion, int CountryPopulation, string CountryGovForm)
    {
      this.CountryCode = CountryCode;
      this.CountryName = CountryName;
      this.CountryContinent = CountryContinent;
      this.CountryRegion = CountryRegion;
      this.CountryPopulation = CountryPopulation;
      this.CountryGovForm = CountryGovForm;
    }

    public static List<Country> GetAllCountryInfo()
    {
      List<Country> allCountriesInfo = new List<Country>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string CountryCode = rdr.GetString(0);
        string CountryName = rdr.GetString(1);
        string CountryContinent = rdr.GetString(2);
        string CountryRegion = rdr.GetString(3);
        int CountryPopulation = rdr.GetInt32(6);
        string CountryGovForm = rdr.GetString(11);

        Country newCountry = new Country(CountryCode, CountryName, CountryContinent, CountryRegion, CountryPopulation, CountryGovForm);
        allCountriesInfo.Add(newCountry);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountriesInfo;
    }
  }
}
