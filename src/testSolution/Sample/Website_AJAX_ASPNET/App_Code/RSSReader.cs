using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.UI;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class RSSReader : System.Web.Services.WebService {

  [WebMethod]
  public string GetRSSReader()
  {
    Page page = new Page();
    UserControl ctl = 
      (UserControl)page.LoadControl("~/RSSReaderControl.ascx");

    page.Controls.Add(ctl);

    StringWriter writer = new StringWriter();
    HttpContext.Current.Server.Execute(page, writer, false);

    return writer.ToString();
  }
}