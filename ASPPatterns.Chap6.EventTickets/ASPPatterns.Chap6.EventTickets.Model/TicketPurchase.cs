using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Model
{
    public class TicketPurchase
    {
        public Guid Id { get; set; }
        public Event Event { get; set; }        
        public int TicketQuantity { get; set; }
    }
}
