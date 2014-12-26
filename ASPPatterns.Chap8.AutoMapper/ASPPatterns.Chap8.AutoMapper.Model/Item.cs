using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.AutoMapper.Model
{
    public class Item
    {
        public Product Product { get; set; }
        public int Qty { get; set; }
    }
}
