using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace WorldData.Models
{
  public class CountryLanguage
  {
    public string CountryCode {get;set;}
    public string CountryLanguageType {get;set;}
    public bool CountryIsOfficialLang {get;set;}
    public float CountryLangPercentage {get;set;}

    public CountryLanguage(string CountryCode,string CountryLanguageType, bool CountryIsOfficialLang, float CountryLangPercentage)
    {
      this.CountryCode = CountryCode;
      this.CountryLanguageType = CountryLanguageType;
      this.CountryIsOfficialLang = CountryIsOfficialLang;
      this.CountryLangPercentage = CountryLangPercentage;
    }

    public static List<CountryLanguage> GetAllCountryInfo()
    {
      List<CountryLanguage> allCountryLangInfo = new List<CountryLanguage>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM countrylanguage";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {

        string CountryCode = rdr.GetString(0);
        string CountryLanguageType = rdr.GetString(1);
        bool CountryIsOfficialLang = rdr.GetBoolean(2);
        int CountryLangPercentage = rdr.GetInt32(3);

        CountryLanguage newCountryLanguage = new CountryLanguage(CountryCode, CountryLanguageType, CountryIsOfficialLang, CountryLangPercentage);

        allCountryLangInfo.Add(newCountryLanguage);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountryLangInfo;
    }
  }
}
