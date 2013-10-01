using System;
using System.Linq;
using System.Xml.Linq;

public partial class RSSReaderControl : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // For demo purposes.
    System.Threading.Thread.Sleep(1000);

    XDocument feedXML = 
      XDocument.Load("http://feeds.encosia.com/Encosia");

    var feeds = from feed in feedXML.Descendants("item")
                select new
                {
                  Title = feed.Element("title").Value,
                  Link = feed.Element("link").Value,
                  Description = feed.Element("description").Value
                };

    PostList.DataSource = feeds;
    PostList.DataBind();
  }
}