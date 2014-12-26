using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ASPPatterns.Chap6.EventTickets.DataContract
{
    [DataContract]
    public class PurchaseTicketResponse : Response 
    {
        [DataMember]
        public string TicketId { get; set; }
                       
        [DataMember]
        public String EventName { get; set; }

        [DataMember]
        public String EventId { get; set; }

        [DataMember]
        public int NoOfTickets { get; set; }
    }
}
