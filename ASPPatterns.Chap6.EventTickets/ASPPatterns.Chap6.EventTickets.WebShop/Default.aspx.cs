using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap6.EventTickets.ServiceProxy;
using ASPPatterns.Chap6.EventTickets.Contracts;

namespace ASPPatterns.Chap6.EventTickets.WebShop
{
    public partial class _Default : System.Web.UI.Page
    {        
        protected void btnReserveTickets_Click(object sender, EventArgs e)
        {
            Basket.Clear();

            TicketServiceFacade ticketService = new TicketServiceFacade(new TicketServiceClientProxy());
            TicketReservationPresentation reservation = ticketService.ReserveTicketsFor(ddlEvents.SelectedValue, int.Parse(this.txtNoOfTickets.Text));

            if (reservation.TicketWasSuccessfullyReserved)
            {
                Basket.GetBasket().Reservation = reservation;
                Response.Redirect("Checkout.aspx");
            }

            Response.Write("Your tickets were unable to be reserved.<br/>" + reservation.Description);                        
        }         
    }
}
