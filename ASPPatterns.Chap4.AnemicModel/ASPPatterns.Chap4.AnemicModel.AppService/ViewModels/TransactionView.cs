using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.AnemicModel.AppService
{
    public class TransactionView
    {
        public string Deposit { get; set; }
        public string Withdrawal { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
    }
}
