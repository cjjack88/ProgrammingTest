using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GenerateExcelBtn_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/zip";
        Response.AppendHeader("content-disposition", "attachment; filename=" + Guid.NewGuid() + ".zip");

        using (ZipFile zip = new ZipFile())
        {
            zip.AddFile(@"C:\eula.1028.txt");

            zip.Save(Response.OutputStream);
        }
    }
}