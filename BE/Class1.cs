using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BE
{
    public class TicketBE
    {
        public int ID { get; set; }
        public string Mabdae { get; set; }
        public string Maghsad { get; set; }
        
        public string numAIR { get; set; }
        public string TypeAir { get; set; }
        public string Pic { get; set; }
        public float Price { get; set; }

        public List<Company_Ticket> company_Tickets { get; set; }
        public List<Order_Ticket> Order_Tickets { get; set; }
    }
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }
        public string pic { get; set; }
        public List<Company_Ticket> company_Tickets { get; set; }
    }
    public class Company_Ticket
    {
       public int ID { get; set; }
       public Company Company { get; set; }
       public TicketBE TicketBE { get; set; }
       public int CompanyID { get; set; }
       public int TicketBEID { get; set; }
    
    }
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Order
    {
        public int ID { get; set; }
        public UserApp User { get; set; }
        public float TotalPrice { get; set; }
        public string UserId { get; set; }
        public List<Order_Ticket> Order_Tickets { get; set; }
    }
    public class Order_Ticket
    {
        public int ID { get; set; }
        public int Ticket_ID { get; set; }
        public int Order_ID { get; set; }
        public Order Order { get; set; }
        public TicketBE Ticket { get; set; }
    }
}
