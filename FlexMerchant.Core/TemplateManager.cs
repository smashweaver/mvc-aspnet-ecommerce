using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace FlexMerchant.Core
{
    public class TemplateManager
    {
        public static string Render<T>(string templatePath, T dataContext)
        {
            FormlessPage page = new FormlessPage();
            ViewUserControl viewTemplate = (ViewUserControl)page.LoadControl(templatePath);
            if (viewTemplate is IViewTemplate<T>)
            {
                ((IViewTemplate<T>)viewTemplate).SetDataContext(dataContext);
                viewTemplate.DataBind();
            }
            page.Controls.Add(viewTemplate);
            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(page, output, false);
            return output.ToString();
        }
    }

    class FormlessPage : Page
    {
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }

    public class BaseViewTemplate<T> : ViewUserControl<T>,  IViewTemplate<T>
    {
        public void SetDataContext(T dataContext)
        {
            this.SetViewData(dataContext);
        }
    }

    public interface IViewTemplate<T>
    {
        void SetDataContext(T dataContext);
    }

}
