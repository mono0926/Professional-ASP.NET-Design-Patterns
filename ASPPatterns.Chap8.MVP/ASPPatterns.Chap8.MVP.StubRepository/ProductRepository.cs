using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.StubRepository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> FindAll()
        {
            return new DataContext().Products;
        }

        public Product FindBy(int Id)
        {
            Product productFound = new DataContext().Products.FirstOrDefault(prod => prod.Id == Id);

            if (productFound != null)
            {
                productFound.Description = "orem ipsum dolor sit amet, consectetur adipiscing elit." +
                                           "Praesent est libero, imperdiet eget dapibus vel, tempus at ligula. Nullam eu metus justo." +
                                           "Curabitur sit amet lectus lorem, a tempus felis. " +
                                           "Phasellus consectetur eleifend est, euismod cursus tellus porttitor id.";
            }

            return productFound;
        }
    }
}
