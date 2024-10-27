using System;
using System.Collections.Generic;
using System.Configuration;


namespace FlexMerchant.Configuration
{
    public class ProductViewManager
    {
        static ViewSection _section;

        public static ViewElement GetView(string name)
        {
            if (_section == null) _section = (ViewSection)ConfigurationManager.GetSection("viewSection");
            if (string.IsNullOrEmpty(name))
                name = _section.DefaultView;
            foreach (ViewElement el in _section.ViewCollection)
            {
                if (el.Name == name)
                    return el;
            }
            return null;
        }

        public static List<string> GetViewNames()
        {
            List<string> list = new List<string>();
            foreach (ViewElement el in _section.ViewCollection)
            {
                list.Add(el.Name);
            }
            return list;
        }
    }

    public class ViewElement : ConfigurationElement
    {
        public ViewElement() { }

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("rows", IsRequired = true)]
        public int Rows
        {
            get { return (int)this["rows"]; }
            set { this["rows"] = value; }
        }

        [ConfigurationProperty("cols", IsRequired = true)]
        public int Columns
        {
            get { return (int)this["cols"]; }
            set { this["cols"] = value; }
        }

        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }
    }

    [ConfigurationCollection(typeof(ViewElement))]
    public class ViewElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ViewElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ViewElement)element).Name;
        }
    }

    public class ViewSection : ConfigurationSection
    {
        [ConfigurationProperty("views", IsDefaultCollection = true)]
        public ViewElementCollection ViewCollection
        {
            get { return (ViewElementCollection)(this["views"]); }
        }

        [ConfigurationProperty("default", IsRequired=true)]
        public string DefaultView
        {
            get { return (string)this["default"]; }
        }
    }
}
