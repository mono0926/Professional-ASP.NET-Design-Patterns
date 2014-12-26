using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.Library.Services.Messages
{
    public class LoanBookRequest
    {
        public string MemberId { get; set; }
        public string CopyId { get; set; }
    }
}
