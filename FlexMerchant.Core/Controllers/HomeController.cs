using System;
using System.Web.Mvc;
using FlexMerchant.Core;

namespace FlexMerchant.Mvc
{
    public class HomeController : FlexController
    {
        public virtual void Index()
        {
            RenderView("index", ThemeService.Current.MasterPage);
        }
    }
}



