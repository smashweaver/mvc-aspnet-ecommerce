using System;
using System.Web;
using System.Web.Mvc;

public partial class Part : ViewPage<string>
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Response.ContentType = "text/html";
    }
}
