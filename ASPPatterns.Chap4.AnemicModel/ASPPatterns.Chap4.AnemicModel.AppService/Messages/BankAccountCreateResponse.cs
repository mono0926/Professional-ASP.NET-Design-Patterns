using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.AnemicModel.AppService.Messages
{
    public class BankAccountCreateResponse : ResponseBase 
    {        
        public Guid BankAccountId { get; set; }
    }
}
