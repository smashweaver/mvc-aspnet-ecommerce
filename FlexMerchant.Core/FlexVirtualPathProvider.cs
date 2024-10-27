using System;
using System.IO;
using System.Security.Permissions;
using System.Web;
using System.Web.Hosting;
using FlexMerchant.Mvc;

namespace FlexMerchant.Core
{
    public class FlexVirtualPathProvider : VirtualPathProvider
    {
        public override VirtualFile GetFile(string virtualPath)
        {
            string path = virtualPath;

            string ext = Path.GetExtension(virtualPath);
            string fileName = Path.GetFileName(virtualPath);
            if (ext.Equals(".master", StringComparison.CurrentCultureIgnoreCase))
            {
                string themeName = ThemeService.Current.Name;
                if (string.IsNullOrEmpty(themeName))
                {
                    string themedFile = string.Format("/themes/{0}/{1}", themeName, fileName); 
                    if (base.FileExists(themedFile))
                    {
                        path = VirtualPathUtility.ToAppRelative(themedFile);
                        return new FlexVirtualFile(path, virtualPath);
                    }
                }
            }
            return base.GetFile(path);
        }
    }

    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
 
    public class FlexVirtualFile : VirtualFile
    {
        string _path;

        public FlexVirtualFile(string path, string virtualPath)
            : base(virtualPath)
        {
            _path = HttpContext.Current.Server.MapPath(path);
        }

        public override Stream Open()
        {
            string fileContents = GetContents();
            Stream stream = new MemoryStream();            
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(fileContents);
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        string GetContents()
        {
            StreamReader reader = new StreamReader(_path);
            string contents = reader.ReadToEnd();
            reader.Close();
            return contents;
        }

        public override bool IsDirectory
        {
            get {return false; }
        }
    }
}
