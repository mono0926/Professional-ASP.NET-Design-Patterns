using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.TransactionScript.BLL
{
    public class BookedLeaveDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int DaysTaken { get; set; }
    }
}
