using System;
using System.Web;
using System.Web.Mvc;
using System.Text;
using FlexMerchant.Core;
//using FlexMerchant.Core;

namespace FlexMerchant.Mvc
{
    public class CartController : FlexController
    {
        public void Update()
        {
            FlexMerchant.Core.Cart cart = CartService.GetCart();
            foreach (string key in Request.Form.AllKeys)
            {
                if (key.StartsWith("sku["))
                {
                    string sku = GetSku(key);
                    int qty = int.Parse(Request.Form[key]);
                    cart.Update(sku, qty);                   
                }
            }
        }

        public void Delete()
        {
            string sku = Request.Form["sku"];
            CartService.Remove(sku);
        }

        public void AddSku(string sku, string qty)
        {
            int quantity = 1;
            if (qty != null) 
                quantity = int.Parse(qty);
            CartService.Add(sku, quantity);
        }

        public void Index(string mode)
        {
            if (mode == "update") 
                Update();
            else if (mode == "delete") 
                Delete();
            RenderView("cart", ThemeService.Current.MasterPage);
        }

        #region helpers
        // this method could be placed inside a Utility class
        string GetSku(string sample)
        {
            return sample.Replace("sku[", "").Replace("]", "");
        }


        #endregion
    }
}
