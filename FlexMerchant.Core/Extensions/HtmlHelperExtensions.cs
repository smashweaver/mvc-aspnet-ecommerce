using System;
using System.Collections;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static string UnsortedList(this HtmlHelper helper, object data)
        {
            if (data != null && (data is IEnumerable))
            {
                StringBuilder ul = new StringBuilder("<ul>\n");
                bool hasItems = false;
                foreach (object m in (IEnumerable)data)
                {
                    hasItems = true;
                    ul.Append("<li>").Append(m).AppendLine("</li>");
                }
                if (!hasItems)
                    return String.Empty;
                else
                    return ul.AppendLine("</ul>").ToString(); ;

            }
            return String.Empty;
        }

        public static string AjaxLink(this HtmlHelper helper, string linkText, string actionName, string target)
        {
            return AjaxLink(helper, linkText, actionName, null, target);
        }
        public static string AjaxLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, string target)
        {
            string link = controllerName == null ? helper.ActionLink(linkText, actionName) :
                helper.ActionLink(linkText, actionName, controllerName);

            if (target == null)
                return link;
            else if (!target.StartsWith("#"))
                target = "#" + target;

            return link.Replace("<a", "<a class=\"ajaxlink\" meta:ajaxtarget=\"" + target + "\"");
        }
    }
}
