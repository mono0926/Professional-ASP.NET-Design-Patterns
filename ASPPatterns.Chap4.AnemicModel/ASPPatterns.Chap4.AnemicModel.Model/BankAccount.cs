using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.AnemicModel.Model
{    
    public class BankAccount
    {
        public BankAccount()
        {
            Transactions = new List<Transaction>();
        }

        public Guid AccountNo { get; set; }

        public decimal Balance { get; set; }

        public string CustomerRef { get; set; }

        public IList<Transaction> Transactions { get; set; }
    }   
}
