using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.Presentation
{
    public interface IProductDetailView
    {
        int ProductId {get;}
        string Name {set;}
        decimal Price { set; }
        string Description { set; }
        IEnumerable<Category> CategoryList { set; } 
    }
}
