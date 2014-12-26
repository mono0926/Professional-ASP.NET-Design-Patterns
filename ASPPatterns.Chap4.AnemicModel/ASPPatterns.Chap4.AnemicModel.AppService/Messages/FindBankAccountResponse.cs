using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.AnemicModel.AppService.Messages
{
    public class FindBankAccountResponse : ResponseBase 
    {
        public BankAccountView BankAccount { get; set; }
    }
}
