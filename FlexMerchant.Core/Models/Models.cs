using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FlexMerchant.Core
{
    public class CartItem
    {
        public string Description { get; set; }
        public string SKU { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Extended { get { return Price * Qty; } }

        public string VarSKU { get { return string.Format("sku[{0}]", SKU); } }
    }

    public class Cart 
    {
        int _count = 0;
        public  List<CartItem> Items { get; private set; }        

        public Cart()
        {
            Items = new List<CartItem>();
            Items.Add(new CartItem { Description = "Sharp Stereo Model 1283AB", SKU = "1283001", Price = 5000, Qty = 1 });
            Items.Add(new CartItem { Description = "Panasonic TV Model 1224BG", SKU = "1564005", Price = 7000, Qty = 1 });
            Items.Add(new CartItem { Description = "Sony TV Model 2190BG", SKU = "201234", Price = 10000, Qty = 1 });
        }

        public int Count
        {
            get { return _count; }
        }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (CartItem item in Items)
                {
                    total += item.Extended;
                }
                return total;
            }
        }

        public void Add(string sku, int qty)
        {
            _count++;
        }

        public void Update(string sku, int qty)
        {
            //_count += qty;
            int index = GetIndex(sku);
            if (index >= 0)
            {
                Items[index].Qty = qty;
            }
        }
        
        public void Delete(string sku)
        {
            _count--;
            int index = GetIndex(sku);
            if (index >= 0)
            {
                Items.RemoveAt(index);
            }
        }

        int GetIndex(string sku)
        {
            int index = -1;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].SKU == sku)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        //protected override System.Web.UI.DataSourceView GetView(string viewName)
        //{
        //    return new CartDataSourceView(this, viewName);
        //}
    }


    //public class CartDataSourceView : System.Web.UI.DataSourceView
    //{
    //    public CartDataSourceView(System.Web.UI.IDataSource owner, string name) :base(owner, "CartView")
    //    {
    //    }

    //    protected override System.Collections.IEnumerable ExecuteSelect(System.Web.UI.DataSourceSelectArguments arguments)
    //    {
    //        CartService service = new CartService(HttpContext.Current.Session.SessionID);
    //        yield return service.GetCart();
    //    }
    //}

   

    public class Shop
    {
        public Shop() { }
        public Shop(int shopId) { }
        public int Id { get; set; }
        public string Theme { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public void Add(Category category)
        {                  
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Template { get; set; }  // template to use for displaying products
        public void Add(Product product) { }
    }

    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Template { get; set; }  // template to use for displaying products
        public void Add(ProductSKU productSKU) { }
    }

    public class ProductSKU
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Template { get; set; }  // template to use for displaying products
    }

    public class PagedResult<T>
    {
        public List<T> List { get; set; }
        public int TotalRows { get; set; }
        public int PageSize { get; set; }
        public int Count
        {
            get
            {
                int pages = TotalRows / PageSize;
                if (TotalRows % PageSize > 0) pages++;
                return pages;
            }
        }
    }

    //public interface IContextContainer
    //{
    //    T GetContext<T>();
    //    void AddContext(Type type, object context);
    //}

    public abstract class ListContext<T>
    {
        public List<T> Items { get; set; }
        public string Url { get; set; }
        public string ViewTemplate { get; set; }
        public int MaxRows { get; set; }
        public int MaxCols { get; set; }
        public int Count { get; set; }
        public int Index { get; set; }
        public int Id { get; set; }
        public string View { get; set; }
        public string Order { get; set; }
    }

    public class ProductListContext : ListContext<Product>
    {
        public string CategoryTemplate { get; set; }
    }
}
