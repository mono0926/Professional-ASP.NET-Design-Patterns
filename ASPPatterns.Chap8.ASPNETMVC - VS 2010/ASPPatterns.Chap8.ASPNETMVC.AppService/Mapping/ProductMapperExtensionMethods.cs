using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.ASPNETMVC.AppService.Views;
using ASPPatterns.Chap8.ASPNETMVC.Model;

namespace ASPPatterns.Chap8.ASPNETMVC.AppService.Mapping
{
    public static class ProductMapperExtensionMethods
    {
        public static IEnumerable<ProductView> ConvertToProductViewList(this IEnumerable<Product> products)
        {
            IList<ProductView> productViews = new List<ProductView>();

            foreach (Product p in products)
            {
                productViews.Add(p.ConvertToProductView());
            }

            return productViews;
        }

        public static ProductView ConvertToProductView(this Product product)
        {
            ProductView productView = new ProductView();
            productView.Name = product.Name;
            productView.Id = product.Id.ToString();
            productView.Price = String.Format("{0:c}", product.Price); 

            return productView;
        }

        public static ProductDetailView ConvertToProductDetailView(this Product product)
        {
            ProductDetailView productView = new ProductDetailView();
            productView.Name = product.Name;
            productView.Id = product.Id.ToString();
            productView.Price = String.Format("{0:c}", product.Price);
            productView.Description = product.Description;

            return productView;
        }
    }
}
