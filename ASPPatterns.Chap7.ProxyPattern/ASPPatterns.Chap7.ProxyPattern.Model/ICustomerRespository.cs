using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.ProxyPattern.Model
{
    public interface ICustomerRespository
    {
        Customer FindBy(Guid id);
    }
}
