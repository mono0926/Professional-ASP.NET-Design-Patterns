using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.AutoMapper.AppService.Views
{
    public class OrderView
    {
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public IList<ItemView> Items { get; set; }
    }
}
