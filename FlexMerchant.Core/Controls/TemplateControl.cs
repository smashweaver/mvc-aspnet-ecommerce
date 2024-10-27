using System;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using FlexMerchant.Core;
using FlexMerchant.Mvc;

namespace FlexMerchant.Web.UI.Controls
{
    public class Template : ViewUserControl
    {
        public string Src { get; set; }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
            if (DesignMode)
            {
                writer.Write("[TemplateControl]");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Manager.AddManager(this.Page);
            string path = string.Format("{1}/{0}.ascx", Src, ThemeService.Current.TemplatePath);
            HtmlGenericControl div = new HtmlGenericControl("div");
            ITemplate template = Page.LoadTemplate(path);
            template.InstantiateIn(div);
            this.Controls.Add(div);

        }
    }

    public class ProductTemplate : ViewUserControl
    {
        public string Src { get; set; }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
            if (DesignMode)
            {
                writer.Write("[ProductTemplateControl]");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Product ctx = this.GetContext<Product>();
            if (ctx != null && !string.IsNullOrEmpty(ctx.Template))
                Src = ctx.Template;
            base.OnLoad(e);
            Manager.AddManager(this.Page);
            string path = string.Format("{1}/product/{0}.ascx", Src, ThemeService.Current.TemplatePath);
            HtmlGenericControl div = new HtmlGenericControl("div");
            ITemplate template = Page.LoadTemplate(path);
            template.InstantiateIn(div);
            this.Controls.Add(div);
        }
    }

    public class ProductsTemplate : ViewUserControl
    {
        public string Src { get; set; }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
            if (DesignMode)
            {
                writer.Write("[ProductsTemplateControl]");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            ProductListContext ctx = this.GetContext<ProductListContext>();
            if (ctx != null && !string.IsNullOrEmpty(ctx.CategoryTemplate))
                Src = ctx.CategoryTemplate;     
            base.OnLoad(e);
            Manager.AddManager(this.Page);
            string path = string.Format("{1}/products/{0}.ascx", Src, ThemeService.Current.TemplatePath);
            HtmlGenericControl div = new HtmlGenericControl("div");
            ITemplate template = Page.LoadTemplate(path);
            template.InstantiateIn(div);
            this.Controls.Add(div);
        }
    }

    public class GlobalTemplate : ViewUserControl
    {
        public string Src { get; set; }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
            if (DesignMode)
            {
                writer.Write("[GlobalTemplateControl]");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Manager.AddManager(this.Page);
            string path = string.Format("{1}/{0}.ascx", Src, ThemeService.Current.GlobalTemplatePath);
            HtmlGenericControl div = new HtmlGenericControl("div");
            ITemplate template = Page.LoadTemplate(path);
            template.InstantiateIn(div);
            this.Controls.Add(div);

        }
    }
}
