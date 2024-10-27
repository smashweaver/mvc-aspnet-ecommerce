using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using FlexMerchant.Mvc;

namespace FlexMerchant.Core
{
    public class FilteringModule : IHttpModule
    {

        const string MODULEKEY = "FilterModuleInstalled";
        HttpApplication _app;

        public void Init(HttpApplication context)
        {
            _app = context;
            context.ReleaseRequestState += new EventHandler(InstallFilter);
            context.PreSendRequestHeaders += new EventHandler(InstallFilter);
        }

        public void Dispose() { }

        private void InstallFilter(object sender, EventArgs e)
        {
            if (!_app.Context.Items.Contains(MODULEKEY)) {

                HttpResponse response = _app.Response;
                if (response.ContentType == "text/html")
                {
                    response.Filter = new PageFilter(response.Filter);
                }
                _app.Context.Items.Add(MODULEKEY, new object());
            }
        }
    }


    public class PageFilter : Stream
    {
        Stream reqStream;
        long position;
        StringBuilder htmlBits;

        public PageFilter(Stream inputStream)
        {
            reqStream = inputStream;
            htmlBits = new StringBuilder();
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Close()
        {
            reqStream.Close();
        }

        public override void Flush()
        {
            reqStream.Flush();
        }

        public override long Length
        {
            get { return 0; }
        }

        public override long Position
        {
            get { return position; }
            set { position = value; }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return reqStream.Seek(offset, origin);
        }

        public override void SetLength(long length)
        {
            reqStream.SetLength(length);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return reqStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            string strBuffer = System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count);
            Regex eof = new Regex("</html>", RegexOptions.IgnoreCase);

            if (!eof.IsMatch(strBuffer)) {
                htmlBits.Append(strBuffer);
            } else {
                htmlBits.Append(strBuffer);
                ReplaceTokens(htmlBits);
                string finalHtml = htmlBits.ToString();
                byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(finalHtml);
                reqStream.Write(data, 0, data.Length);
            }
        }

        void ReplaceTokens(StringBuilder pageSource)
        {
            Regex parser = new Regex(@"\$\[\w+\]");
            string temp = pageSource.ToString();
            MatchCollection matches = parser.Matches(temp);
            if (matches.Count > 0) {
                for (int i = matches.Count - 1; i > -1; i--) {
                    Match match = matches[i];
                    string key = GetKey(match.Value);
                    temp = temp.Remove(match.Index, match.Length);
                    temp = temp.Insert(match.Index, GetResource(key));
                }
            }
            pageSource.Remove(0, pageSource.Length);
            pageSource.Append(temp);
        }

        string GetResource(string key)
        {
            // should get resource from hash file or database ...
            //if (key.Equals("THEMEPATH", StringComparison.OrdinalIgnoreCase))
            //    return ThemeService.Current.ThemePath;
            if (key.Equals("IMAGEPATH", StringComparison.OrdinalIgnoreCase))
                return ThemeService.Current.ImagePath;
            if (key.Equals("GLOBALIMAGEPATH", StringComparison.OrdinalIgnoreCase))
                return ThemeService.Current.GlobalImagePath;
            if (key.Equals("SEARCH", StringComparison.OrdinalIgnoreCase))
                return "Search";
            if (key.Equals("SITEEMAIL", StringComparison.OrdinalIgnoreCase))
                return "jason.jimenez@flexmerchants.com";
            if (key.Equals("CURRENTDATE", StringComparison.OrdinalIgnoreCase))
                return DateTime.Now.ToString("MM/dd/yyyy");
            if (key.Equals("WEBSITE_URL", StringComparison.OrdinalIgnoreCase))
                return "www.sextoys.us";
            if (key.Equals("WEBSITE_TITLE", StringComparison.OrdinalIgnoreCase))
                return "sextoys.us -  Buy dildo and vibrators from $4.95 ";
            if (key.Equals("WEBSITE_DESCRIPTION", StringComparison.OrdinalIgnoreCase))
                return "sextoys us is one of the most popular sexshops on the internet, fast delivery and great prices and secure payments and good return policy.";
            if (key.Equals("WEBSITE_KEYWORDS", StringComparison.OrdinalIgnoreCase))
                 return "sex toys, dildo, sexshop, vibrator, adult toys, sextoys";
            if (key.Equals("TOP_BANNER_LINKS", StringComparison.OrdinalIgnoreCase))
                return "<A id=linkTopFaq href=\"Faq.aspx\">F.A.Q</A> | <A id=linkTopTerm href=\"/terms\">Terms &amp; Agreement</A> | <A id=linkTopAbout href=\"/about\">About sextoys.us</A> | <A id=linkTopWrite href=\"/writeus\">Contact Us</A></span>";
            if (key.Equals("BOTTOM_BANNER_LINKS", StringComparison.OrdinalIgnoreCase))
                return "<TABLE style=\"border:0; padding:0; width:100%; text-align:center\" cellSpacing=0 cellPadding=0>" +
                        "<TBODY>" +
                        "<TR>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Sex Toys</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Couple</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">For Him</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">For Her</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Dildos</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Anal Toys</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Essentials</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Enhancers</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Sex Dolls</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Clothing</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Movies</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Fun &amp; Games</A></TD>" +
                        "<TD align=middle><IMG alt='' src=\"/images/divider.jpg\"></TD>" +
                        "<TD align=middle><A class=nav-bg id=linkMenuHome href=\"#.aspx\">Gay</A></TD>"+
                        "</TR></TBODY></TABLE>";
            if (key.Equals("WEBSITE_PHONE", StringComparison.OrdinalIgnoreCase))
                return "1-800-SEXTOYS";
            if (key.Equals("WEBSITE_INDEXPAGE", StringComparison.OrdinalIgnoreCase))
                return "/index";
            if (key.Equals("COPYRIGHT", StringComparison.OrdinalIgnoreCase))
                return " © 2007 Brothers LLC";
            if (key.Equals("ADDRESS", StringComparison.OrdinalIgnoreCase))
                return " 501 Silverside Rd Ste 105 | Wilmington, DE 19809 | USA | Email: info@sextoys.us | Allrights Reserved";
            
            throw new ArgumentException(string.Format("{0} is not a valid resource key.", key));
        }

        string GetKey(string token)
        {
            return token.Replace("$[", "").Replace("]", "").Trim();
        }
    }
}
