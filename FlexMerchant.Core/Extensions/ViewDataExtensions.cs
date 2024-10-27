namespace System.Web.Mvc
{
    public static class ViewDataExtensions
    {
        public static object GetItem(this ViewData viewData, string name)
        {
            try
            {
                return viewData[name];
            }
            catch
            {
                return null;
            }
        }
    }

    public static class ViewPageExtensions
    {
        public static T GetContext<T>(this ViewPage page)
        {
            return (T)HttpContext.Current.Items[typeof(T).ToString()];
        }

        public static void AddContext<T>(this ViewPage page, T context)
        {
            HttpContext.Current.Items[typeof(T).ToString()] = context;
        }
    }

    public static class ControllerExtensions
    {
        public static T GetContext<T>(this Controller controller)
        {
            return (T)HttpContext.Current.Items[typeof(T).ToString()];
        }

        public static void AddContext<T>(this Controller controller, T context)
        {
            HttpContext.Current.Items[typeof(T).ToString()] = context;
        }
    }

    public static class ViewUserControlExtensions
    {
        public static T GetContext<T>(this ViewUserControl control)
        {
            return (T)HttpContext.Current.Items[typeof(T).ToString()];
        }

        public static void AddContext<T>(this ViewUserControl control, T context)
        {
            HttpContext.Current.Items[typeof(T).ToString()] = context;
        }
    }
}
