<%@ WebHandler Language="C#" Class="GeoLocationHandler" %>

using System;
using System.Web;
using System.Collections.Generic;

public class GeoLocationHandler : IHttpHandler 
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        String strCountry = String.Empty;
        String strState = String.Empty;
        String strCity = String.Empty;
        String strFirstName = String.Empty;
        String strMiddleName = String.Empty;
        String strLastName = String.Empty;
        String strEmail = String.Empty;
        String strMethodName = String.Empty;
        if (!String.IsNullOrEmpty(context.Request.Form["DdlCountry"]))
        {
            strCountry = Convert.ToString(context.Request.Form["DdlCountry"]);
        }
        if (!String.IsNullOrEmpty(context.Request.Form["DdlState"]))
        {
            strState = Convert.ToString(context.Request.Form["DdlState"]);
        }
        if (!String.IsNullOrEmpty(context.Request.Form["DdlCity"]))
        {
            strCity = Convert.ToString(context.Request.Form["DdlCity"]);
        }
        if (!String.IsNullOrEmpty(context.Request.Form["TxtFirstName"]))
        {
            strFirstName = Convert.ToString(context.Request.Form["TxtFirstName"]);
        }
        if (!String.IsNullOrEmpty(context.Request.Form["TxtMiddleName"]))
        {
            strMiddleName = Convert.ToString(context.Request.Form["TxtMiddleName"]);
        }
        if (!String.IsNullOrEmpty(context.Request.Form["TxtLastName"]))
        {
            strLastName = Convert.ToString(context.Request.Form["TxtLastName"]);
        }
        if (!String.IsNullOrEmpty(context.Request.Form["TxtEmail"]))
        {
            strEmail = Convert.ToString(context.Request.Form["TxtEmail"]);
        }
        if (!String.IsNullOrEmpty(context.Request.QueryString["StrMethodName"]))
        {
            strMethodName = Convert.ToString(context.Request.QueryString["StrMethodName"]);
        }
        if (strMethodName.Length > 0 && strMethodName.ToUpper().Equals("GETCOUNTRIES"))
        {
            context.Response.Write(CreateCountryDropDownOptions(GetCountries()));
        }
        if (strMethodName.Length > 0 && strMethodName.ToUpper().Equals("GETSTATES"))
        {
            context.Response.Write(CreateStateDropDownOptions(GetStates(strCountry)));
        }
        if (strMethodName.Length > 0 && strMethodName.ToUpper().Equals("GETCITIES"))
        {
            context.Response.Write(CreateCityDropDownOptions(GetCities(strState)));
        }
        else if (strMethodName.Length > 0 && strMethodName.ToUpper().Equals("REGISTERUSER"))
        {
            context.Response.Write("<div><p><strong>Name : </strong>" + strFirstName + " " + strMiddleName + " " + strLastName + "</p><p><strong>Email: </strong>" + strEmail + "</p><p><strong>Location: </strong> " + strCity + ", " + strState + ", " + strCountry + "</p></div>");
        }
        else
        {
            context.Response.Write("-2");
        }
    }
 
    public bool IsReusable {
        get {
            return true;
        }
    }

    
    private List<Location> GetCountries()
    {
        List<Location> countries = new List<Location>();
        for (int iCtr = 0; iCtr < 200; iCtr++)
        {
            countries.Add(new Location(iCtr, "Country_" + iCtr.ToString()));
        }
        return countries;
    }
    private List<Location> GetStates(String PrmStrCountry)
    {
        List<Location> states = new List<Location>();
        Int32 i32MaxLength = new Random().Next(50, 125);
        for (int iCtr = 0; iCtr < i32MaxLength; iCtr++)
        {
            states.Add(new Location(iCtr, PrmStrCountry + "_State_" + iCtr.ToString()));
        }
        return states;
    }
    private List<Location> GetCities(String PrmStrState)
    {
        List<Location> cities = new List<Location>();
        Int32 i32MaxLength = new Random().Next(150, 1250);
        for (int iCtr = 0; iCtr < i32MaxLength; iCtr++)
        {
            cities.Add(new Location(iCtr, PrmStrState + "_City_" + iCtr.ToString()));
        }
        return cities;
    }

    private String CreateCountryDropDownOptions(List<Location> PrmCountries)
    {
        System.Text.StringBuilder strBldOptions = new System.Text.StringBuilder();
        foreach (Location country in PrmCountries)
        {
            strBldOptions.Append("<option opText=\"" + country.StrName + "\" value=\"" + country.I32Id + "\">" + country.StrName + "</option>");
        }
        return strBldOptions.ToString();
    }
    private String CreateStateDropDownOptions(List<Location> PrmStates)
    {
        System.Text.StringBuilder strBldOptions = new System.Text.StringBuilder();
        foreach (Location state in PrmStates)
        {
            strBldOptions.Append("<option opText=\"" + state.StrName + "\" value=\"" + state.I32Id + "\">" + state.StrName + "</option>");
        }
        return strBldOptions.ToString();
    }
    private String CreateCityDropDownOptions(List<Location> PrmCities)
    {
        System.Text.StringBuilder strBldOptions = new System.Text.StringBuilder();
        foreach (Location city in PrmCities)
        {
            strBldOptions.Append("<option opText=\"" + city.StrName + "\" value=\"" + city.I32Id + "\">" + city.StrName + "</option>");
        }
        return strBldOptions.ToString();
    }
}