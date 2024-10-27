using System;
using System.Web;
using System.Web.UI.WebControls;
using FlexMerchant.Core;
using FlexMerchant.Mvc;

namespace FlexMerchant.Web.UI.Controls
{
    public class CartItems : Repeater
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Cart cart = CartService.GetCart();
            this.DataSource = cart.Items;
            this.DataBind();
        }
    }
}
