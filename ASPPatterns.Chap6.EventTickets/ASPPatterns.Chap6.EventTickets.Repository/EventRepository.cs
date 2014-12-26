using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ASPPatterns.Chap6.EventTickets.Model; 

namespace ASPPatterns.Chap6.EventTickets.Repository
{
    public class EventRepository : IEventRepository 
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\EventTickets.mdf;Integrated Security=True;User Instance=True";

        public Event FindBy(Guid id)
        {
            Event Event = default(Event);

            string queryString = "SELECT * FROM dbo.Events WHERE Id = @EventId " +
                                 "SELECT * FROM dbo.PurchasedTickets WHERE EventId = @EventId " +                                
                                 "SELECT * FROM dbo.ReservedTickets WHERE EventId = @EventId;";                 

            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;

                SqlParameter Idparam = new SqlParameter("@EventId", id.ToString());
                command.Parameters.Add(Idparam);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {                   
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Event = new Event();
                        Event.PurchasedTickets = new List<TicketPurchase>();
                        Event.ReservedTickets = new List<TicketReservation>();
                        Event.Allocation = int.Parse(reader["Allocation"].ToString());
                        Event.Id = new Guid(reader["Id"].ToString());
                        Event.Name = reader["Name"].ToString();

                        if (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    TicketPurchase ticketPurchase = new TicketPurchase();
                                    ticketPurchase.Id = new Guid(reader["Id"].ToString());
                                    ticketPurchase.Event = Event;                                    
                                    ticketPurchase.TicketQuantity = int.Parse(reader["TicketQuantity"].ToString());
                                    Event.PurchasedTickets.Add(ticketPurchase);
                                }
                            }
                        }

                        if (reader.NextResult())                                                
                        {
                            if (reader.HasRows)
                            { 
                                while (reader.Read())
                                {
                                    TicketReservation ticketReservation = new TicketReservation();
                                    ticketReservation.Id = new Guid(reader["Id"].ToString());
                                    ticketReservation.Event = Event;
                                    ticketReservation.ExpiryTime = DateTime.Parse(reader["ExpiryTime"].ToString());
                                    ticketReservation.TicketQuantity = int.Parse(reader["TicketQuantity"].ToString());
                                    ticketReservation.HasBeenRedeemed = bool.Parse(reader["HasBeenRedeemed"].ToString());
                                    Event.ReservedTickets.Add(ticketReservation);
                                }
                            }                            
                        }                        
                    }                    
                }
            }

            return Event;
        }

        public void Save(Event Event)
        {
            // Code to save the Event entity 
            // is not required in this senario

            RemovePurchasedAndReservedTicketsFrom(Event);            

            InsertPurchasedTicketsFrom(Event);
            InsertReservedTicketsFrom(Event);
           
        }

        public void InsertReservedTicketsFrom(Event Event)
        {
            string insertSQL = "INSERT INTO ReservedTickets " +
                               "(Id, EventId, TicketQuantity, ExpiryTime, HasBeenRedeemed) " +
                               "VALUES " +
                               "(@Id, @EventId, @TicketQuantity, @ExpiryTime, @HasBeenRedeemed);";                               

            foreach (TicketReservation ticket in Event.ReservedTickets)
            {
                using (SqlConnection connection =
                      new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = insertSQL;

                    SqlParameter Idparam = new SqlParameter("@Id", ticket.Id.ToString());
                    command.Parameters.Add(Idparam);

                    SqlParameter EventIdparam = new SqlParameter("@EventId", ticket.Event.Id.ToString());
                    command.Parameters.Add(EventIdparam);                    

                    SqlParameter TktQtyparam = new SqlParameter("@TicketQuantity", ticket.TicketQuantity);
                    command.Parameters.Add(TktQtyparam);

                    SqlParameter Expiryparam = new SqlParameter("@ExpiryTime", ticket.ExpiryTime);
                    command.Parameters.Add(Expiryparam);

                    SqlParameter HasBeenRedeemedparam = new SqlParameter("@HasBeenRedeemed", ticket.HasBeenRedeemed);
                    command.Parameters.Add(HasBeenRedeemedparam);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void InsertPurchasedTicketsFrom(Event Event)
        {
            string insertSQL = "INSERT INTO PurchasedTickets " +
                               "(Id, EventId, TicketQuantity) " +
                               "VALUES " +
                               "(@Id, @EventId, @TicketQuantity);";                            

            foreach (TicketPurchase ticket in Event.PurchasedTickets)
            { 
                 using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = insertSQL;

                    SqlParameter Idparam = new SqlParameter("@Id", ticket.Id.ToString());
                    command.Parameters.Add(Idparam);

                    SqlParameter EventIdparam = new SqlParameter("@EventId", ticket.Event.Id.ToString());
                    command.Parameters.Add(EventIdparam);
                    
                    SqlParameter TktQtyparam = new SqlParameter("@TicketQuantity", ticket.TicketQuantity);
                    command.Parameters.Add(TktQtyparam);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }           
        }

        public void RemovePurchasedAndReservedTicketsFrom(Event Event)
        {
            string deleteSQL = "DELETE PurchasedTickets WHERE EventId = @EventId; " +
                               "DELETE ReservedTickets WHERE EventId = @EventId;";                                

            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteSQL;

                SqlParameter Idparam = new SqlParameter("@EventId", Event.Id.ToString());
                command.Parameters.Add(Idparam);

                connection.Open();
                command.ExecuteNonQuery();
            }        
        }        
    }
}
