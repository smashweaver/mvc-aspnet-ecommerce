using System;
using System.Web.Mvc;

namespace FlexMerchant.Mvc
{
    public class UtilityController : FlexController
    {
        public void GetPart(string part)
        {
            if (string.IsNullOrEmpty(part))
                part = string.Format("{0}", this.Request.Headers["AjaxPart"]);
            RenderView("part", null, part);
        }
    }
}
