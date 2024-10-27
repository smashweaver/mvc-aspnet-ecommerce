using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FlexMerchant.Core;

namespace MVCStore
{
    public class GlobalApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Note: Change the URL to "{controller}.mvc/{action}/{id}" to enable
            //       automatic support on IIS6 and IIS7 classic mode

            //routes.Add(new Route("{controller}/{action}/{id}", new MvcRouteHandler())
            //{
            //    Defaults = new RouteValueDictionary(new { action = "Index", id = "" }),
            //});

            routes.Add(new Route("Default.aspx", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "Home", action = "Index", id = "" })
            });
            routes.Add(new Route("index", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "home", action = "index" })
            });
            routes.Add(new Route("search", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "search", action = "index" })
            });
            routes.Add(new Route("@getpart", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "utility", action = "getpart" })
            });
            routes.Add(new Route("search", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "search", action = "index" })
            });

            routes.Add(new Route("cart", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "cart", action = "index" })
            });
            routes.Add(new Route("cart/addsku", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "cart", action = "addsku" })
            });

            routes.Add(new Route("new", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "new" })
            });
            routes.Add(new Route("bestsellers", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "bestsellers" })
            });
            routes.Add(new Route("discounted", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "new" })
            });

            routes.Add(new Route("television/sony", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "products", id = 1 })
            });
            routes.Add(new Route("television/sharp", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "products", id = 2 })
            });
            routes.Add(new Route("television/jvc", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "products", id = 3 })
            });
            routes.Add(new Route("stereo/sony", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "products", id = 4 })
            });
            routes.Add(new Route("stereo/sharp", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "products", id = 5 })
            });
            routes.Add(new Route("stereo/jvc", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "products", id = 6 })
            });
            routes.Add(new Route("product", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "catalog", action = "product" })
            });
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //ThemeService.Initialize();
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {            
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }
    }
}