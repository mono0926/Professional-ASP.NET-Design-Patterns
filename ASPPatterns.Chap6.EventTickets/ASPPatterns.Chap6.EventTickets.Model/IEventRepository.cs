using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Model
{
    public interface IEventRepository
    {
        Event FindBy(Guid id);
        void Save(Event eventEntity);       
    }
}
