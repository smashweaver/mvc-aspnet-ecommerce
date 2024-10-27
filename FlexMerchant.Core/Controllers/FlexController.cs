using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using FlexMerchant.Core;
using System.Web.Routing;

namespace FlexMerchant.Mvc
{
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    abstract public class FlexController : Controller
    {
        private bool isAjaxRequest = false;
        protected internal virtual bool IsAjaxRequest
        {
            get { return isAjaxRequest; }
        }

        private bool isJsonRequest = false;
        protected internal virtual bool IsJsonRequest
        {
            get { return isJsonRequest; }
        }

        private bool isPartRequest = false;
        protected internal virtual bool IsPartRequest
        {
            get { return isPartRequest; }
        }

        bool IsSecureAction(string actionName)
        {
            if (string.IsNullOrEmpty(actionName)) return false;
            MethodInfo methodInfo = GetMethodInfo(actionName);
            if (methodInfo == null) throw new InvalidOperationException();
            object[] customAttributes = methodInfo.GetCustomAttributes(typeof(SecureActionAttribute), true);
            return customAttributes.Length > 0;
        }

        MethodInfo GetMethodInfo(string actionName)
        {
            MethodInfo[] methods = this.GetType().GetMethods(BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < methods.Length; i++)
            {
                MethodInfo info2 = methods[i];
                if (string.Equals(actionName, info2.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return info2;
                }
            }
            return null;
        }

        string GetAction(RouteData routeData)
        {
            object value;
            routeData.Values.TryGetValue("action", out value);
            return value as string;
        }

        protected override void Execute(ControllerContext controllerContext)
        {
            if (!String.IsNullOrEmpty(controllerContext.HttpContext.Request.Headers["Ajax"]))
            {
                isAjaxRequest = true;
            }

            if (!String.IsNullOrEmpty(controllerContext.HttpContext.Request.Headers["Json"]))
            {
                isJsonRequest = true;
            }

            if (!String.IsNullOrEmpty(controllerContext.HttpContext.Request.Headers["AjaxPart"]))
            {
                isPartRequest = true;
            }

            if (!isAjaxRequest && !isJsonRequest && !isPartRequest)
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;
                HttpResponseBase response = controllerContext.HttpContext.Response;

                bool isSSLRequired = IsSecureAction(GetAction(controllerContext.RouteData));

                if (isSSLRequired)
                {
                    if (!request.IsSecureConnection)
                    {
                        string redirectUrl = request.Url.ToString().Replace("http:", "https:");
                        response.Redirect(redirectUrl, false);
                    }
                }
                else
                {
                    if (request.IsSecureConnection)
                    {
                        string redirectUrl = request.Url.ToString().Replace("https:", "http:");
                        response.Redirect(redirectUrl, false);
                    }
                }
            }
            

            FlexException exception = null;
            try
            {
                base.Execute(controllerContext);
            }
            catch (System.Reflection.TargetInvocationException exc)
            {
                exception = new FlexException(exc.InnerException);
                //pass the _inner_ exception
            }
            catch (Exception exc)
            {
                exception = new FlexException(exc);
            }
            
            if (exception != null)
            {
                if (IsJsonRequest)
                {
                    RenderView("json", null, exception);
                }
                else
                {
                    //pass it on to the error handler
                    RenderView("error", exception);
                }
            }
        }      

        protected override void RenderView(string viewName, string masterName, object viewData)
        {
            if (viewData is FlexException)
            {
                HttpResponseBase response = ControllerContext.HttpContext.Response;
                FlexException exception = (FlexException)viewData;

                if (exception.InnerException is HttpException)
                {
                    response.StatusCode =
                        ((HttpException)exception.InnerException).GetHttpCode();
                }
                else
                {
                    response.StatusCode = 500;
                }
            }

            if (IsJsonRequest)
            {
                base.RenderView("json", null, viewData);
            }
            else if (IsAjaxRequest)
            {
                base.RenderView(viewName, null, viewData);
            }
            else if (IsPartRequest)
            {
                base.RenderView("part", null, viewData);
            }
            else
            {
                base.RenderView(viewName, masterName, viewData);
            }
        }
    }

    public class FlexException
    {
        public FlexException(Exception exc)
        {
            this.Errors.Add(exc.Message);
            this.StackTrace = exc.StackTrace;
            this.Source = exc.Source;
            this.Type = exc.GetType().FullName;
            this.InnerException = exc;
        }
        List<string> errors = new List<string>();
        public List<string> Errors
        {
            get
            {
                return errors;
            }
        }
        public string StackTrace;
        public string Source;
        public string Type;
        public bool IsException = true;

        internal Exception InnerException;
    }
}