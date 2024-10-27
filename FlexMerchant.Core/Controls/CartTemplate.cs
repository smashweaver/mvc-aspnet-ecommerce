using System;
using System.Web;
using System.Web.Mvc;
using FlexMerchant.Core;
using FlexMerchant.Mvc;

namespace FlexMerchant.Web.UI.Controls
{
    public abstract class CartTemplate : ViewUserControl
    {
        public string GetResponse()
        {
            Cart _cart = CartService.GetCart();
            string _response = "";
            if (_cart.Count == 0)
            {
                _response = "No items in basket";
            }
            else if (_cart.Count == 1)
            {
                _response = string.Format("There is {0} item in your basket.", _cart.Count);
            }
            else
            {
                _response = string.Format("There are {0} items in your basket.", _cart.Count);
            }
            return _response;
        }
    }

   

}
