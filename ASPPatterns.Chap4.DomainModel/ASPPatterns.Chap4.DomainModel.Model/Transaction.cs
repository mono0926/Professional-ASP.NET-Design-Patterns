using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.DomainModel.Model
{
    public class Transaction
    {
        public Transaction(decimal deposit, decimal withdrawal, string reference, DateTime date)
        {            
            this.Deposit = deposit;
            this.Withdrawal = withdrawal;
            this.Reference = reference;
            this.Date = date;
        }
              
        public decimal Deposit
        { get; internal set; }

        public decimal Withdrawal
        { get; internal set; }

        public string Reference
        { get; internal set; }

        public DateTime Date
        { get; internal set; }
    }
}
