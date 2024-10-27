using System;
using System.Web.Mvc;
using System.Web.UI;
using FlexMerchant.Core;
using FlexMerchant.Mvc;

namespace FlexMerchant.Web.UI.Controls
{
    public class ProductList : ViewUserControl
    {
        ProductListContext context;

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
                writer.Write("<table>");
                for (int i = 0; i < context.MaxRows; i++)
                {
                    writer.WriteLine("<tr>");
                    for (int j = 0; j < context.MaxCols; j++)
                    {
                        int index = i * context.MaxCols + j;
                        writer.Write("<td>");
                        if (index < context.Items.Count)
                        {
                            //TODO: 
                            string path = string.Format("{1}/product/{0}.ascx", context.ViewTemplate, ThemeService.Current.TemplatePath);
                            writer.Write(Html.RenderUserControl(path, context.Items[index]));
                        }
                        writer.Write("</td>");
                    }
                    writer.Write("</tr>");
                }
                writer.Write("</table>");
            }

            base.RenderControl(writer);
        }

    }
}
