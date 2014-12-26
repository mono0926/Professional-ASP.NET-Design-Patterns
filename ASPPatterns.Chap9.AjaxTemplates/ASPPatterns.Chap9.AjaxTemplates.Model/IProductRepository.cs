using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap9.AjaxTemplates.Model
{
    public interface IProductRepository
    {        
        IEnumerable<Product> FindAll();
        IEnumerable<Product> FindAllBy(int categoryId);   
    }
}
