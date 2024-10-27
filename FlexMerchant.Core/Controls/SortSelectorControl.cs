using System;
using System.Web;
using System.Web.Mvc;
using FlexMerchant.Core;

namespace FlexMerchant.Web.UI.Controls
{
    public class SortSelector : ViewUserControl
    {
        ProductListContext context;

        protected override void OnPreRender(EventArgs e)
        {
            context = this.GetContext<ProductListContext>();
            string js = Page.ClientScript.GetWebResourceUrl(this.GetType(), "FlexMerchant.Core.Scripts.orderselectorcontrol.js");
            Page.ClientScript.RegisterClientScriptInclude("orderselectorcontroljs", js);
            base.OnPreRender(e);
            base.OnPreRender(e);
        }
    }
}
