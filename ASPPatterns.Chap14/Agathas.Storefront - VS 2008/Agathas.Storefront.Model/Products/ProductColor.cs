﻿using System;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Products
{
    public class ProductColor : EntityBase<int>, IProductAttribute
    {
        public string Name { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }     
    }
}
