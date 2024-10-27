using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using FlexMerchant.Core;

namespace FlexMerchant.Web.UI.Controls
{
    public class Pager : ViewUserControl
    {
        ProductListContext context;
        
        public string CssClass { get; set; }

        protected override void OnLoad(EventArgs e)
        {            
            base.OnLoad(e);
            Manager.AddManager(this.Page);
            context = this.GetContext<ProductListContext>();
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (context != null)
            {
                writer.Write(string.Format("<span class='{0}'>", this.CssClass));
                writer.Write(string.Format("Page {0} of {1} ", context.Index, context.Count));
                for (int i = 0; i < context.Count; i++)
                {
                    if (context.Index != i + 1)
                        //output.Write(string.Format("<span style=\"text-decoration:underline;cursor:pointer;margin:0em;\" onclick=\"setPage({1})\">{0}</span>", i + 1, i + 1));
                        writer.Write(string.Format("<a href=\"/{0}?page={1}\">{1}</a>", context.Url, i + 1));
                    else
                        writer.Write(string.Format("{0}", i + 1));
                }
                writer.Write("</span>");
            }
            base.RenderControl(writer);
        }
    }
}
