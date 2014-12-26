using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.MVP.Presentation.Navigation
{
    public interface IPageNavigator
    {
        void NaviagteTo(PageDirectory page);
    }
}
