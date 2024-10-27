using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexMerchant.Core;

namespace FlexMerchant.Mvc
{
    public class ProductService
    {

        public PagedResult<Product> GetProducts(Category category, int pageIndex, int pageSize)
        {
            return ProductFactory.Get(category, pageIndex, pageSize);
        }


        public Product GetById(int id)
        {
            return ProductFactory.Get(id);
        }

        public static ProductService Get()
        {
            // get this from a DI container
            return new ProductService();
        }

        private ProductService()
        {
        }
    }

    public class CategoryService
    {
        public Category GetById(int id)
        {
            Shop shop = ShopService.Current;
            if (id>3) 
                return new Category { Id = id, Shop = shop, Template="StereoProductsTemplate" };
            return new Category { Id = id, Shop = shop};
        }

        public static CategoryService Get()
        {
            // get this from a DI container
            return new CategoryService();
        }

        public CategoryService()
        {
        }
    }
}
