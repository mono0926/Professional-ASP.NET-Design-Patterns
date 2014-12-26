using System;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Model.Categories
{
    public class Category : EntityBase<int>, IAggregateRoot, IProductAttribute
    {               
        public string Name { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }

}
