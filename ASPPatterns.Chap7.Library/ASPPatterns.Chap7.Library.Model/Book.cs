using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Infrastructure;

namespace ASPPatterns.Chap7.Library.Model
{
    public class Book : IAggregateRoot
    {
        public Guid Id { get; set; }

        public virtual BookTitle Title { get; set; }

        public virtual Member OnLoanTo { get; set; }        
             
    }
}
