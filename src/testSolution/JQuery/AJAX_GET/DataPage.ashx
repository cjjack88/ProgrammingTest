<%@ WebHandler Language="C#" Class="DataPage" %>

using System;
using System.Web;

public class DataPage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string MemberName = context.Request.QueryString["MemberName"];
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World! " + MemberName);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}