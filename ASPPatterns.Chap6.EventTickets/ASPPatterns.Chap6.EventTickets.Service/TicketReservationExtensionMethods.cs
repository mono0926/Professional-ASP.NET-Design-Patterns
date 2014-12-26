using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap6.EventTickets.DataContract;
using ASPPatterns.Chap6.EventTickets.Model;

namespace ASPPatterns.Chap6.EventTickets.Service
{
    public static class TicketReservationExtensionMethods
    {
        public static ReserveTicketResponse ConvertToReserveTicketResponse(this TicketReservation ticketReservation)
        {
            ReserveTicketResponse response = new ReserveTicketResponse();

            response.EventId = ticketReservation.Event.Id.ToString();
            response.EventName = ticketReservation.Event.Name;
            response.NoOfTickets = ticketReservation.TicketQuantity;
            response.ExpirationDate = ticketReservation.ExpiryTime;
            response.ReservationNumber = ticketReservation.Id.ToString();

            return response;
        }
    }
}
