using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.InterfaceSegregation.Model
{
    public class TShirt : IProduct  
    {
        public decimal Price { get; set; }

        public decimal WeightInKg { get; set; }

        public int Stock { get; set; }        
    }
}
