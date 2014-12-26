using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Infrastructure;

namespace ASPPatterns.Chap7.Library.Model
{
    public class Loan
    {
        public Guid Id { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime DateForReturn { get; set; }

        public DateTime? ReturnDate { get; set; }

        public virtual Book Book { get; set; }

        public Member Member { get; set; }

        public bool HasNotBeenReturned()
        {
            return ReturnDate == null;
        }

        public void MarkAsReturned()
        {
            ReturnDate = DateTime.Now;            
        }
    }
}
