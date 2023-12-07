using BE;
using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL
{
    public class DB : IdentityDbContext<UserApp>
    {
        public DB() : base() { }
        public DB(DbContextOptions<DB> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source =.; initial catalog = AireLineTicket; integrated security = True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Order> Order { get; set; }
        public DbSet<TicketBE> Tickets { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Order_Ticket> Order_Tickets { get; set; }
        public DbSet<Company_Ticket> Company_Tickets { get; set; }

    }
}
