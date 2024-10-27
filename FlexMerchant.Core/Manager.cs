using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections;

namespace FlexMerchant.Core
{
    public sealed class Manager
    {
        #region Public Static Methods

        public static void AddManager(Page page)
        {
            Manager manager = HttpContext.Current.Items[MANAGERKEY] as Manager;
            if (manager == null)
            {
                manager = new Manager();
                page.Unload += new EventHandler(manager.OnUnload);
                HttpContext.Current.Items[MANAGERKEY] = manager;
                //manager._page = page;
                manager._response = page.Response;
                manager.RegisterPageScript(page);
            }
            //if (!manager.isRegistered) 
            //    manager.RegisterPageScript(page);
        }

        public static void RegisterScript(string key, string script)
        {
            RegisterScript(key, script, true);
        }

        public static void RegisterScript(string key, string script, bool isScript)
        {
            Manager manager = Instance;
            if (!manager._scripts.ContainsKey(key))
            {
                manager._scripts.Add(key, new Script { Text = script, IsScript = isScript });
            }
        }

        public static void RegisterScriptInclude(string key, Type type, string resource)
        {
#if DEBUG
            Stream stream = type.Assembly.GetManifestResourceStream(resource);
            StreamReader reader = new StreamReader(stream);
            string script = reader.ReadToEnd();
            RegisterScript(key, script);
#else
            string js = GetManager()._page.ClientScript.GetWebResourceUrl(type, resource);
            string script = string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>", js);
            RegisterScript(key, script, false);
#endif
        }
        #endregion

        #region Private Static Methods

        private static readonly string MANAGERKEY = "__flex_manager__";

        private static Manager Instance
        {
            get { return (Manager)HttpContext.Current.Items[MANAGERKEY]; }
        }

        #endregion

        #region Private Methods

        //private bool isRegistered = false;
        //private Page _page = null;
        private HttpResponse _response = null;
        private Dictionary<string, Script> _scripts = new Dictionary<string, Script>();

        private Manager() {}

        private void RegisterPageScript(Page page)
        {
            // set to true since we want this to be called only once 
            //isRegistered = true;
            // insert our client framework script
            Control mc = page.Controls[0];
            foreach (Control control in mc.Controls)
            {
                HtmlHead htmlHead = control as HtmlHead;
                if (htmlHead != null)
                {
                    HtmlGenericControl script = new HtmlGenericControl("script");
                    script.Attributes.Add("type", "text/javascript");
#if DEBUG
                    Stream stream = this.GetType().Assembly.GetManifestResourceStream("FlexMerchant.Core.Scripts.flex.js");
                    StreamReader reader = new StreamReader(stream);
                    script.InnerHtml = '\n'+reader.ReadToEnd()+'\n';
#else
                    string js = page.ClientScript.GetWebResourceUrl(this.GetType(), "FlexMerchant.Core.Scripts.flex.js");
                    script.Attributes.Add("src", js);
#endif
                    htmlHead.Controls.Add(script);
                    break;
                }
            }
        }

        private void OnUnload(object sender, EventArgs e)
        {
            // inject scripts           
            Manager manager = Instance;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script type=\"text/javascript\">");
            if (manager._scripts.Count > 0)
            {
                foreach (string key in manager._scripts.Keys)
                {
                    Script script = manager._scripts[key];
                    if (script.IsScript)
                    {
                        sb.AppendLine(script.Text);
                    }
                    else
                    {
                        manager._response.Write('\n' + script.Text);
                    }
                }
            }
            sb.AppendLine("</script>");
            manager._response.Write('\n'+sb.ToString());
        }

        #endregion
    }

    internal class Script
    {
        public string Text { get; set; }
        public bool IsScript { get; set; }
    }
}
