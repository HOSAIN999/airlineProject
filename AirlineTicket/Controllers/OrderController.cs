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
    public class OrderController : Controller
    {
        public async Task<IActionResult> AddToBasket(int TicketId)
        {
            var basketlist = new List<int>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                basketlist = JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket")).ToList();
            }
            basketlist.Add(TicketId);
            HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basketlist));
            return RedirectToAction("Details", "Ticket", new { id = TicketId });
        }
    }
}
