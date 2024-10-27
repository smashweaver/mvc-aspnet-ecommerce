using System;
using System.Web;
using System.Web.Mvc;
using FlexMerchant.Core;

namespace FlexMerchant.Mvc
{
    public class SearchController : Controller
    {
        public virtual void Index(string query, string page)
        {
            RenderView("search", ThemeService.Current.MasterPage, query);
        }
    }
}
