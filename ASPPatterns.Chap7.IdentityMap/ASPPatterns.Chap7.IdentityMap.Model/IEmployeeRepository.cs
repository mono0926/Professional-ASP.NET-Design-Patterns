using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.IdentityMap.Model
{
    public interface IEmployeeRepository
    {
        Employee FindBy(Guid Id);        
    }
}
