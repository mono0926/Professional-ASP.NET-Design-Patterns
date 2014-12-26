using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap9.PeriodicRefresh.Model
{
    public interface IEventRepository
    {
        IEnumerable<Event> FindAllSince(int commentaryId);        
    }
}
