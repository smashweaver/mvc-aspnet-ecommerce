using System;
using System.Web.UI;
using System.Web.Mvc;
using FlexMerchant.Core;

namespace FlexMerchant.Web.UI.Controls
{
    public class ProductViewSelector : ViewUserControl
    {
        ProductListContext context;

        public string Text { get; set; }
        public string Value { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            Manager.RegisterScriptInclude("viewselectorcontroljs", typeof(ProductViewSelector), "FlexMerchant.Core.Scripts.viewselectorcontrol.js");
            base.OnPreRender(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Manager.AddManager(this.Page);
            context = this.GetContext<ProductListContext>();
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            string content;
            if (context.View != this.Value)
                content = string.Format("<span style=\"text-decoration:underline; cursor: pointer;margin:0em;padding:0em;\" onclick=\"__setView('{0}')\">{1}</span>", Value, Text);
            else
                content = string.Format("<span>{0}</span>", Text);
            writer.Write(content);
            base.RenderControl(writer);
        }
    }
}
