using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.AnemicModel.Model
{    
    public class Transaction
    {
        public Guid Id{ get; set; }

        public decimal Deposit{ get; set; }

        public decimal Withdraw{ get; set; }

        public string Reference{ get; set; }

        public DateTime Date{ get; set; }

        public Guid BankAccountId{ get; set; }
    }
}
