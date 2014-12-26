using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.UnitOfWork.Infrastructure; 

namespace ASPPatterns.Chap7.UnitOfWork.Model
{
    public class Account : IAggregateRoot 
    {
        public decimal balance { get; set; }
    }
}
