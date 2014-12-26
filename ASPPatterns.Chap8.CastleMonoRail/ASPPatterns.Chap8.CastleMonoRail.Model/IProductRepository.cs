using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.CastleMonoRail.Model;

namespace ASPPatterns.Chap8.CastleMonoRail.Model
{
    public interface IProductRepository
    {        
        IEnumerable<Product> FindAll();
        Product FindBy(int Id);
    }
}
