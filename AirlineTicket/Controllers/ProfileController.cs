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
    [Authorize]
    public class ProfileController : Controller
    {

        public IActionResult Index(string Showbasket, string Message = null)
        {
            ViewBag.Showbasket = Showbasket;
            if (!string.IsNullOrWhiteSpace(Message))
            {
                ViewBag.successpayment = Message;
            }
            return View();
        }
    }
}
