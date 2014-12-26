using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LayerSuperType.Model
{
    public class Product : EntityBase<System.Guid>
    {
        public Product() { }

        public Product(System.Guid Id)
            : base(Id)
        { }

        public decimal Price { get; set; }
        public int Stock { get; set; }

        protected override void CheckForBrokenRules()
        {
            if (Price < 0m)
                base.AddBrokenRule("A product must have a non negative price.");

            if (Stock < 0)
                base.AddBrokenRule("A product cannot have a negative stock level."); 
        }
    }
}
