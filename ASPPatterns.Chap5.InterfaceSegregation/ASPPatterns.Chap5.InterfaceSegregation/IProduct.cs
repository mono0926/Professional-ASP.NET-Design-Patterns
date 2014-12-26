using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.InterfaceSegregation.Model
{
    public interface IProduct
    {
        decimal Price { get; set; }
        decimal WeightInKg { get; set; }
        int Stock { get; set; }        
    }
}
