using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Location
/// </summary>
public class Location
{
    private Int32 i32Id;
    public Int32 I32Id { get { return i32Id; } }
    private String strName;
    public String StrName { get { return strName; } }
    public Location(Int32 PrmI32Id, String PrmStrName)
    {
        i32Id = PrmI32Id;
        strName = PrmStrName;
    }
}
