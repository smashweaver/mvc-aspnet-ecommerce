using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using FlexMerchant.Core.Utils;

namespace FlexMerchant.Core.Models
{
    public class Paypal
    {
        public decimal OrderTotal { get; set; }
        public decimal MaxTotal { get; set; }
        public string ReturnUrl { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
        public string PaymentAction { get; set; }
        public string LogoUrl { get; set; }
        public string Custom { get; set; }
        public string BuyerEmail { get; set; }
        public string AccountEmail { get; set; }
        public string InvoiceNo { get; set; }
        public string ItemName { get; set; }

        string ppUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr?";

        public Paypal()
        {
            CancelUrl =  "http://localhost:56743/checkout/cancel";
            SuccessUrl = "http://localhost:56743/checkout/ok";
            LogoUrl = "http://www.sextoys.us/images/logo-sextoys.jpg";
            BuyerEmail = "";
            AccountEmail = "kool_1204265258_biz@hotmail.com ";
            OrderTotal = 0.10M;
            InvoiceNo = "1000008";
            ItemName = "OrderID #1000008";
        }

        public string GetSubmitUrl()
        {
            StringBuilder url = new StringBuilder();

            url.Append(this.ppUrl + "cmd=_xclick&business=" +HttpUtility.UrlEncode(AccountEmail));
            if (BuyerEmail != null && BuyerEmail != "") url.AppendFormat("&email={0}", HttpUtility.UrlEncode(BuyerEmail));
            if (OrderTotal != 0.00M) url.AppendFormat("&amount={0:f2}", OrderTotal);
            if (LogoUrl != null && LogoUrl != "") url.AppendFormat("&image_url={0}", HttpUtility.UrlEncode(LogoUrl));
            if (ItemName != null && ItemName != "") url.AppendFormat("&item_name={0}", HttpUtility.UrlEncode(ItemName));
            if (InvoiceNo != null && InvoiceNo != "") url.AppendFormat("&invoice={0}", HttpUtility.UrlEncode(InvoiceNo));
            if (SuccessUrl != null && SuccessUrl != "") url.AppendFormat("&return={0}", HttpUtility.UrlEncode(SuccessUrl));
            if (CancelUrl != null && CancelUrl != "") url.AppendFormat("&cancel_return={0}", HttpUtility.UrlEncode(CancelUrl));
            return url.ToString();
        }

    }
}
