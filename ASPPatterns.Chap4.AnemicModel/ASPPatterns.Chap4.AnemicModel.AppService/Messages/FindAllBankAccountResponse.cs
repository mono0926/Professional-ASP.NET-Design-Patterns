using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.AnemicModel.AppService.Messages
{
    public class FindAllBankAccountResponse : ResponseBase 
    {
        public IList<BankAccountView> BankAccountView { get; set; }
    }
}
