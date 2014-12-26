using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.AutoMapper.Model
{
    public class Order
    {
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public IList<Item> Items { get; set; }
    }
}
