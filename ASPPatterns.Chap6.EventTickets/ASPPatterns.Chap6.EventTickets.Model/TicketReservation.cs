using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Model
{
    public class TicketReservation
    {        
        public Guid Id { get; set; }
        public Event Event { get; set; }
        public DateTime ExpiryTime { get; set; }
        public int TicketQuantity { get; set; }
        public bool HasBeenRedeemed { get; set; }

        public bool HasExpired()
        {
            return DateTime.Now > ExpiryTime;
        }

        public bool StillActive()
        {
            return !HasBeenRedeemed && !HasExpired();
        }
    }
}
