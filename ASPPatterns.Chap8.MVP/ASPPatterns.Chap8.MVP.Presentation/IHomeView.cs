using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.Presentation
{
    public interface IHomeView
    {
        IEnumerable<Product> TopSellingProduct { set; } 
        IEnumerable<Category> CategoryList {set; } 
    }
}
