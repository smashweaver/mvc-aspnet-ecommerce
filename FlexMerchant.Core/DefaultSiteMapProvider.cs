using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace FlexMerchant.Core
{
    public class DefaultSiteMapProvider : StaticSiteMapProvider
    {
        readonly object _lock = new object();
 
        public override SiteMapNode BuildSiteMap()
        {
            lock (_lock) 
            {
                Clear();   
                
                int key = 0;

                AddNode(new SiteMapNode(this, (key++).ToString(), "~/default.aspx", "Home"));
                SiteMapNode rootNode = new SiteMapNode(this, (key++).ToString(), "~/home", "Home");
                AddNode(rootNode);
                
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/about", "About Us"), rootNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/businessterms", "Business Terms"), rootNode);

                // testimonial
                SiteMapNode testimonialNode = new SiteMapNode(this, (++key).ToString(), null, "Products");
                AddNode(testimonialNode, rootNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/testimonial/write", "Write Testimonial"), testimonialNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/testimonial/showall", "All Testimonials"), testimonialNode);

                // products 
                SiteMapNode productsNode = new SiteMapNode(this, (++key).ToString(), null, "Products");
                AddNode(productsNode, rootNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/products/new", "New Products"), productsNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/products/sale", "Sale Products"), productsNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/products/bestseller", "Best Sellers"), productsNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/products/search", "Search"), productsNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/products/search/[query]", "Search"), productsNode);
                                
                // customer
                SiteMapNode customerNode = new SiteMapNode(this, (++key).ToString(), null, "Customer");
                AddNode(customerNode, rootNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/customer/writeus", "write us"), customerNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/customer/wishlist", "Wish List"), customerNode);
                AddNode(new SiteMapNode(this, (++key).ToString(), "~/customer/cart", "Cart"), customerNode);

                return rootNode;
            }
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return BuildSiteMap();
        }
    }
}
