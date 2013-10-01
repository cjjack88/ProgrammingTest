using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string MemberName = Request.QueryString["MemberName"];

        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "text/plain";
        Response.Write("Hello! " + MemberName);
    }
}