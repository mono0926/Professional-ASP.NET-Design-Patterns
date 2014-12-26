using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.Concurrency.Model
{
    public interface IPersonRepository
    {
        void Add(Person person);        
        void Save(Person person);        
        Person FindBy(Guid Id);
    }
}
