using System;
using System.Web;
using System.Web.Mvc;
using FlexMerchant.Core;
using FlexMerchant.Configuration;
using System.Web.Routing;

namespace FlexMerchant.Mvc
{
    public class CatalogController : Controller
    {
        public void New(string page)
        {
            RenderView("newproducts", ThemeService.Current.MasterPage);
        }

        public void BestSellers(string page)
        {
            RenderView("bestproducts", ThemeService.Current.MasterPage);
        }

        public void Discounted(string page)
        {
            RenderView("discountedproducts", ThemeService.Current.MasterPage);
        }

        public void Products(int id, string page, string view, string order)
        {
            // get the url from the Route
            Route route = (Route)this.RouteData.Route;
            string url = route.Url;

            // get the template to use
            Category category = CategoryService.Get().GetById(id);

            // inject the context
            this.AddContext<ProductListContext>(GetProductListContextContext(category, page, view, order, url));

            // render the view
            RenderView("products", ThemeService.Current.MasterPage);
        }

        public void Product(int id)
        {
            Product product = ProductService.Get().GetById(id);
            this.AddContext<Product>(product);
            RenderView("product", ThemeService.Current.MasterPage, product);
        }

        private ProductListContext GetProductListContextContext(Category category, string page, string view, string order, string url)
        {
            int pageIndex;
            if (string.IsNullOrEmpty(page))
                pageIndex = 1;
            else
                pageIndex = int.Parse(page);

            if (CurrentView == null)
                CurrentView = ProductViewManager.GetView(null).Name;


            if (view != null && CurrentView != view)
                CurrentView = view;

            ViewElement el = ProductViewManager.GetView(CurrentView);

            string path = el.Path;
            int rows = el.Rows;
            int cols = el.Columns;
            int pageSize = rows * cols;

            PagedResult<Product> result = ProductService.Get().GetProducts(category, pageIndex, pageSize);

            result.List.ForEach(c => c.Url = url);
            return new ProductListContext
            {
                Order = order,
                View = CurrentView,
                Id = category.Id,
                Url = url,
                Index = pageIndex,
                Count = result.Count,
                ViewTemplate = path,
                Items = result.List,
                MaxCols = cols,
                MaxRows = rows,
                CategoryTemplate = category.Template
            };
        }

        private readonly string VIEWKEY = "__category_showproducts_view__";

        string CurrentView
        {
            get { return (string)this.HttpContext.Session[VIEWKEY]; }
            set { this.HttpContext.Session[VIEWKEY] = value; }
        }

        string GetProductsUrl(string url)
        {
            return "/" + url.Replace("/[page]", "");
        }
    }
}