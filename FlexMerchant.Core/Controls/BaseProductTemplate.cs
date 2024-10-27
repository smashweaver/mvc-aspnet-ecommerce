using System;
using System.Web.Mvc;
using FlexMerchant.Core;

namespace FlexMerchant.Web.UI.Controls
{
    public abstract class BaseProductTemplate : ViewUserControl<Product>
    {
        protected override void OnPreRender(EventArgs e)
        {
            string productForm =
                "<form id=\"productForm\" method=\"post\" action=\"/product\">\n" +
                "  <input type=\"hidden\" name=\"id\"  />\n" +
                "</form>";
            Manager.RegisterScriptInclude("baseproducttemplatejs", typeof(BaseProductTemplate), "FlexMerchant.Core.Scripts.baseproducttemplate.js");
            Manager.RegisterScript("productForm", productForm, false);            
            base.OnPreRender(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.AddContext<Product>(ViewData);
            base.OnLoad(e);
        }
    }
}
