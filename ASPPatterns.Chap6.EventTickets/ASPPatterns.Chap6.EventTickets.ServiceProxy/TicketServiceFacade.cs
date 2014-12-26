using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap6.EventTickets.Contracts;
using ASPPatterns.Chap6.EventTickets.DataContract;

namespace ASPPatterns.Chap6.EventTickets.ServiceProxy
{
    public class TicketServiceFacade
    {
        private ITicketService _ticketService;

        public TicketServiceFacade(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }      

        public TicketReservationPresentation ReserveTicketsFor(string EventId, int NoOfTkts)
        {
            TicketReservationPresentation reservation = new TicketReservationPresentation();
            ReserveTicketResponse response = new ReserveTicketResponse();
            ReserveTicketRequest request = new ReserveTicketRequest();

            request.EventId = EventId;
            request.TicketQuantity = NoOfTkts;

            response = _ticketService.ReserveTicket(request);

            if (response.Success)
            {
                reservation.TicketWasSuccessfullyReserved = true;
                reservation.ReservationId = response.ReservationNumber;
                reservation.ExpiryDate = response.ExpirationDate;
                reservation.EventId = response.EventId;
                reservation.Description = String.Format("{0} ticket(s) reserved for {1}.<br/><small>This reservation will expire on {2} at {3}.</small>", response.NoOfTickets, response.EventName, response.ExpirationDate.ToLongDateString(), response.ExpirationDate.ToLongTimeString());
            }
            else
            {
                reservation.TicketWasSuccessfullyReserved = false;
                reservation.Description = response.Message;
            }

            return reservation;
        }

        public TicketPresentation PurchaseReservedTicket(string EventId, string ReservationId)
        {
            TicketPresentation ticket = new TicketPresentation();
            PurchaseTicketResponse response = new PurchaseTicketResponse();
            PurchaseTicketRequest request = new PurchaseTicketRequest();
            request.ReservationId = ReservationId;
            request.EventId = EventId;
            request.CorrelationId = ReservationId; // In this instance we can use the ReservationId

            response = _ticketService.PurchaseTicket(request);
            if (response.Success)
            {
                ticket.Description = String.Format("{0} ticket(s) purchased for {1}.<br/><small>Your e-ticket id is {2}.</small>", response.NoOfTickets, response.EventName, response.TicketId);
                ticket.EventId = response.EventId;
                ticket.TicketId = response.TicketId;
                ticket.WasAbleToPurchaseTicket = true;
            }
            else
            {
                ticket.WasAbleToPurchaseTicket = false;
                ticket.Description = response.Message; 
            }

            return ticket;
        }

    }
}
