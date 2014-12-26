using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.DomainModel.AppService.Messages
{
    public class BankAccountCreateResponse : ResponseBase 
    {        
        public Guid BankAccountId { get; set; }
    }
}
