using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.DependencyInjection.Model
{
    public class Product
    {
        public void AdjustPriceWith(IProductDiscountStrategy discount)
        {             
        }
    }
}
