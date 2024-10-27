using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class UrlHelperExtensions
    {
        public static object SiteRoot(this UrlHelper helper)
        {
            try
            {
                string path = helper.ViewContext.HttpContext.Request.ApplicationPath;
                if (!path.EndsWith("/"))
                    path += "/";
                return path;
            }
            catch
            {
                return null;
            }
        }
    }
}
