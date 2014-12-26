using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.Specification.Model
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
        
        ISpecification<T> And(ISpecification<T> other);        
        
        ISpecification<T> Not();
    }
}
