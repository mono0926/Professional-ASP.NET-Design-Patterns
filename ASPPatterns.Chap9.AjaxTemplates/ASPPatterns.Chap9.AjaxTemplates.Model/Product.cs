using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap9.AjaxTemplates.Model
{
    public class Product
    {
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }        
    }
}
