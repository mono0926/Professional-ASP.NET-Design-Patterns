using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.MVP.Model
{
    public interface IProductRepository
    {        
        IEnumerable<Product> FindAll();
        Product FindBy(int Id);
    }
}
