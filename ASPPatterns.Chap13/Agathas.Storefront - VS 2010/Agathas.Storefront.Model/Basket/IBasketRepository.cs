using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Basket
{
    public interface IBasketRepository : IRepository<Basket, Guid>
    {
    }

}
