using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using ASPPatterns.Chap6.EventTickets.Contracts;
using ASPPatterns.Chap6.EventTickets;
using ASPPatterns.Chap6.EventTickets.DataContract;
using ASPPatterns.Chap6.EventTickets.Model;
using ASPPatterns.Chap6.EventTickets.Repository; 

namespace ASPPatterns.Chap6.EventTickets.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = 
         AspNetCompatibilityRequirementsMode.Allowed)]
    public class TicketService : ITicketService 
    {
        private IEventRepository _eventRepository;
        private static MessageResponseHistory<PurchaseTicketResponse> _reservationResponse = new MessageResponseHistory<PurchaseTicketResponse>();
        
        public TicketService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public TicketService() : this (new EventRepository()) // Poor mans DI
        { }

        public ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest)
        {           
            ReserveTicketResponse response = new ReserveTicketResponse();

            try
            {
                Event Event = _eventRepository.FindBy(new Guid(reserveTicketRequest.EventId));
                TicketReservation reservation;

                if (Event.CanReserveTicket(reserveTicketRequest.TicketQuantity)   )
                {
                    reservation = Event.ReserveTicket(reserveTicketRequest.TicketQuantity);
                    _eventRepository.Save(Event);
                    response = reservation.ConvertToReserveTicketResponse();
                    response.Success = true;
                }
                else                
                {
                    response.Success = false;
                    response.Message = String.Format("There are {0} ticket(s) available.", Event.AvailableAllocation());             
                }
               
            }
            catch (Exception ex)
            {
                // Shield Exceptions
                response.Message = ErrorLog.GenerateErrorRefMessageAndLog(ex);
                response.Success = false;
            }            
            return response;
        }

        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest PurchaseTicketRequest)
        {
            PurchaseTicketResponse response = new PurchaseTicketResponse();

            try
            {
                // Check for a duplicate transaction using the Idempotent Pattern,
                // the Domain Logic could cope but we can't be sure.
                if (_reservationResponse.IsAUniqueRequest(PurchaseTicketRequest.CorrelationId))
                {                
                    TicketPurchase ticket;
                    Event Event = _eventRepository.FindBy(new Guid(PurchaseTicketRequest.EventId));

                    if (Event.CanPurchaseTicketWith(new Guid(PurchaseTicketRequest.ReservationId)))
                    {
                        ticket = Event.PurchaseTicketWith(new Guid(PurchaseTicketRequest.ReservationId));

                        _eventRepository.Save(Event);

                        response = ticket.ConvertToPurchaseTicketResponse();
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = Event.DetermineWhyATicketCannotbePurchasedWith(new Guid(PurchaseTicketRequest.ReservationId));
                        response.Success = false;
                    }
                   
                    _reservationResponse.LogResponse(PurchaseTicketRequest.CorrelationId, response);
                }            
                else
                {
                    // Retrieve last response
                    response = _reservationResponse.RetrievePreviousResponseFor(PurchaseTicketRequest.CorrelationId);
                }
            }
            catch (Exception ex)
            {
                // Shield Exceptions
                response.Message = ErrorLog.GenerateErrorRefMessageAndLog(ex);
                response.Success = false;
            }   

            return response;             
        }        
    }
}
