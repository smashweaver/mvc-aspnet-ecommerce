using System;
using System.Web;
using System.Web.Caching;
using FlexMerchant.Core;

namespace FlexMerchant.Mvc
{
    public class ThemeService
    {
        static readonly string THEMEKEY = "__themekey__";
        public static Theme Current
        {
            get 
            {
                if (HttpRuntime.Cache[THEMEKEY] == null) {
                    Call().Initialize();
                }
                return (Theme)HttpRuntime.Cache[THEMEKEY]; 
            }
        }

        private static ThemeService Call()
        {
            return new ThemeService();
        }

        private void Initialize()
        {
            // We will pull the default theme from the Shop class 
            Shop shop = ShopService.Current;
            Theme theme = new Theme(shop.Theme);
            // Store the theme in the application
            HttpRuntime.Cache.Add(
                THEMEKEY, 
                theme, 
                null,
                DateTime.Now.AddMinutes(10),
                Cache.NoSlidingExpiration,                                 
                CacheItemPriority.NotRemovable, null);
        }

        public ThemeService()
        {
        }
    }

    public class Theme
    {
        string _name;
        public string Name { get { return _name; } }

        public Theme(string name)
        {
            _name = name;
        }
        public string MasterPage
        {
            get { return string.Format("/themes/{0}/site.master", Name); }
        }
        public string ThemePath
        {
            get { return string.Format("/themes/{0}", Name); }
        }
        public string TemplatePath
        {
            get { return string.Format("/themes/{0}/templates", Name); }
        }
        public string ImagePath
        {
            get { return string.Format("/themes/{0}/images", Name); }
        }
        public string GlobalTemplatePath
        {
            get { return "/global/templates"; }
        }
        public string GlobalImagePath
        {
            get { return "/global/images"; }
        }
    }
}
