using System;
using System.Web.Mvc;
using FlexMerchant.Core;
using FlexMerchant.Web.UI.Controls;
using System.Web.UI;

namespace FlexMerchant.Web.UI
{
    public abstract class BaseProductsPage : ViewPage
    {
        protected ProductListContext context;

        protected override void OnPreRender(EventArgs e)
        {
           
            if (context != null)
            {
                string viewForm = string.Format(
                    "<form id=\"viewForm\" action=\"/{0}\" method=\"post\" style=\"display:inline;padding:0;margin:0;\">\n" +
                    "  <input type=\"hidden\" name=\"view\" value=\"{1}\" />\n" +
                    "  <input type=\"hidden\" name=\"id\" value=\"{2}\" />\n" +
                    "  <input type=\"hidden\" name=\"page\" value=\"{3}\" />\n" +
                    "  <input type=\"hidden\" name=\"order\" value=\"{4}\" />\n" +
                    "  <input type=\"hidden\" name=\"product\" />\n" +
                    "</form>", context.Url, context.View, context.Id, context.Index, context.Order);
                Manager.RegisterScript("viewForm", viewForm, false);               
            }
            base.OnPreRender(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Manager.AddManager(this.Page);
            context = this.GetContext<ProductListContext>();
        }
    }
}
