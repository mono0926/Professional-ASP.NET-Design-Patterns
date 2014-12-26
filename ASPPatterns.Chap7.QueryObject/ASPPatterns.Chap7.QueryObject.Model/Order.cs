using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.QueryObject.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public bool HasShipped { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
    }
}
