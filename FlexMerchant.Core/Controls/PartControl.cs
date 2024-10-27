using System;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using FlexMerchant.Core;
using FlexMerchant.Mvc;

namespace FlexMerchant.Web.UI.Controls
{
    public class Part : ViewUserControl
    {
        public string Src { get; set; }
        public string TargetID { get; set; }
        public bool IsUpdatable { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (IsUpdatable)
            {
                string path = string.Format("{1}/{0}.ascx", Src, ThemeService.Current.TemplatePath);
                string script = string.Format("flex.addpart(\"{0}\",\"{1}\");", path, TargetID);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), string.Format("part{0}", TargetID), script, true);
                Manager.RegisterScript(string.Format("part_{0}", TargetID), script);
            }
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (DesignMode)
            {
                writer.Write(string.Format("[PartControl]"));
            }
            base.RenderControl(writer);
        }

        protected override void OnLoad(EventArgs e)
        { 
            base.OnLoad(e);            
            Manager.AddManager(this.Page);
            if (Src != null)
            {
                string path = string.Format("{1}/{0}.ascx", Src, ThemeService.Current.TemplatePath);
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("id", TargetID);
                div.Controls.Add(Page.LoadControl(path));
                this.Controls.Add(div);
            }

        }
    }

    
}
