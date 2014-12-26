using System;
using System.Collections.Generic;
using ASPPatterns.Chap9.AjaxTemplates.Model;

namespace ASPPatterns.Chap9.AjaxTemplates.Controllers
{
    public class CategoryBrandView
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Brand>  Brands { get; set; }        
    }
}
