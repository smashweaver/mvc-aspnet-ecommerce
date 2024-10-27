using System;
using System.Collections.Generic;
using System.Web;
using FlexMerchant.Core;

namespace FlexMerchant.Mvc
{
    public class CartService
    {
        public static Cart GetCart()
        {
            if (HttpContext.Current.Session[CARTKEY] == null) {
                HttpContext.Current.Session[CARTKEY] = new Cart();
            }
            return (Cart)HttpContext.Current.Session[CARTKEY];
        }


        public static void Add(string sku, int qty)
        {
            Cart cart = GetCart();
            cart.Add(sku, qty);
        }

        public static void Update(string sku, int qty)
        {
            Cart cart = GetCart();
            if (qty == 0) cart.Delete(sku);
            else cart.Update(sku, qty);
        }

        public static void Remove(string sku)
        {
            Cart cart = GetCart();
            cart.Delete(sku);
        }

        private static readonly string CARTKEY = "__cartkey__";
    }

    public class SKUService
    {
    }
}
