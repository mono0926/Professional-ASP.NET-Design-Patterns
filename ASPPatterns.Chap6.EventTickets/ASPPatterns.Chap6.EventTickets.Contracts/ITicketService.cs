using System;
using System.Collections.Generic;
using System.Linq;

using System.ServiceModel;
using ASPPatterns.Chap6.EventTickets.DataContract; 

namespace ASPPatterns.Chap6.EventTickets.Contracts
{
    [ServiceContract(Namespace = "http://ASPPatterns.Chap6.EventTickets/")]    
    public interface ITicketService
    {                        
        [OperationContract()]
        ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest);

        [OperationContract()]
        PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest purchaseTicketRequest);
    }
}
