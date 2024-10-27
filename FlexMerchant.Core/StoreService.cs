using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexMerchant.Core;

namespace FlexMerchant.Mvc
{
    public class ShopService
    {
        public static Shop Current
        {
            get { return new Shop { Id=1,  Theme = "default" }; }
        }

        private static ShopService Call()
        {
            return new ShopService();
        }

        public ShopService()
        {
        }
    }
}
