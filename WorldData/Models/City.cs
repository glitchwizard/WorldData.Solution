using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace WorldData.Models
{
  public class City
  {
    public string CityName {get;set;}
    public string CityCountryCode {get;set;}
    public string CityDistrict {get;set;}
    public int CityID {get;set;}
    public int CityPopulation {get;set;}


    public City (string CityName, string CityCountryCode, string CityDistrict, int CityID, int CityPopulation)
    {
      this.CityName = CityName;
      this.CityCountryCode = CityCountryCode;
      this.CityDistrict = CityDistrict;
      this.CityID = CityID;
      this.CityPopulation = CityPopulation;
    }

    public static List<City> GetAllCityInfo()
    {
      List<City> allCitiesInfo = new List<City>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int CityID = rdr.GetInt32(0);
        string CityName = rdr.GetString(1);
        string CityCountryCode = rdr.GetString(2);
        string CityDistrict = rdr.GetString(3);
        int CityPopulation = rdr.GetInt32(4);

        City newCity = new City(CityName, CityCountryCode, CityDistrict, CityID, CityPopulation);
        allCitiesInfo.Add(newCity);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allCitiesInfo;
    }
  }
}
