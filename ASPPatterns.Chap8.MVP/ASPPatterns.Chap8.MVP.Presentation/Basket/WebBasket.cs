using System.Collections.Generic;
using System.Web;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.Presentation.Basket
{
    public class WebBasket : IBasket
    {           
        public IEnumerable<Product> Items
        {
            get { return GetBasketProducts(); }
        }

        public void Add(Product product)
        {
            IList<Product> products = GetBasketProducts();

            products.Add(product);
        }

        private IList<Product> GetBasketProducts()
        {
            IList<Product> products = HttpContext.Current.Session["Basket"] as IList<Product>;

            if (products == null)
            {
                products = new List<Product>();
                HttpContext.Current.Session["Basket"] = products;
            }
            return products;
        }
    }
}
