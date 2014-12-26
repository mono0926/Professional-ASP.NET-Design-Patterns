using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Infrastructure;

namespace ASPPatterns.Chap7.Library.Model
{
    public class BookTitle : IAggregateRoot
    {
        public string ISBN { get; set; } 

        public string Title { get; set; }                
    }
}
