using BE;
using BLL;
using DAL;
using System;
using System.Linq;
using Newtonsoft.Json;
using AirlineTicket.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AirlineTicket.Controllers
{

    public class PaymentController : Controller
    {
        private UserManager<UserApp> userManager;
        public PaymentController(UserManager<UserApp> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Payment()
        {
            var TicketIds = new List<int>();
            if (HttpContext.Session.GetString("basket") != null)
            {
               TicketIds = JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket"));
               var TBLL = new TicketBLL();
               var Ticket=TBLL.SearchById(TicketIds);
               var user = await userManager.FindByNameAsync(User.Identity.Name);
               OrderBLL OBLL = new OrderBLL();
               var OrderTickets = new List<Order_Ticket>();
               foreach(var item in Ticket)
               {
                   OrderTickets.Add(new Order_Ticket { Ticket_ID = item.ID });
               }
                OBLL.Create(new Order 
                { 
                   Order_Tickets = OrderTickets,
                   TotalPrice = Ticket.Sum(s => s.Price),
                   UserId = user.Id
                });
            }
            return RedirectToAction("Index", "Profile", new { Message = "پرداخت با موفقیت انجام شد" });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
