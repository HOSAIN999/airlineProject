using BE;
using BLL;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using DAL;

namespace AirlineTicket.Controllers.Admin
{
    public class TicketController : Controller
    {
        private IWebHostEnvironment Environment;
        public TicketController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            CompanyBLL CBLL = new CompanyBLL();
            ViewBag.Company = CBLL.getall();

            return View();
        }
        public IActionResult instalTicket()
        {
            return View("CreateTicket");
        }
        [HttpPost]
        public IActionResult instalTicket(Models.TicketM T)
        {
            TicketBLL TBLL = new TicketBLL();
            TicketBE TBE = new TicketBE();
            TBE.Price = T.Price;
            TBE.Mabdae = T.Mabdae;
            TBE.Maghsad = T.Maghsad;
            TBE.numAIR = T.numAIR;
            TBE.TypeAir = T.TypeAir;
            UpLoadfile UPF = new UpLoadfile(Environment);
            TBE.Pic = UPF.UpLoad(T.Pic);
            var add = TBLL.Create(TBE);

            DB db = new DB();
            foreach (var item in T.Companys)
            {
                db.Company_Tickets.Add(new Company_Ticket()
                {
                    CompanyID = item,
                    TicketBEID = add
                });
            }

            db.SaveChanges();
            return RedirectToAction (nameof(getall));
        }
        public IActionResult getskip(int C)
        {
            TicketBLL TBLL = new TicketBLL();
            return View("ShowTicket", TBLL.getskip(C));
        }
        public IActionResult Showall()
        {
            TicketBLL TBLL = new TicketBLL();

            return View("ShowTicket", TBLL.getskip(0));
        }
        public JsonResult tsjson()
        {
            return Json(new { Redirect = "Search" });
        }
        public IActionResult Search(string Ticket)
        {
            TicketBLL TBLL = new TicketBLL();
            List<TicketBE> LT = new List<TicketBE>();
            if (Ticket == null)
            {
                LT = TBLL.getall();
            }
            else
            {
                LT = TBLL.Search(Ticket);
            }
            ViewBag.Ticketall = LT;
            return View("getall");
        }
        [HttpPost]
        public string Update(Models.TicketM T)
        {
            TicketBLL TBLL = new TicketBLL();
            TicketBE TBE = new TicketBE();
            TBE.ID = T.ID;
            TBE.Price = T.Price;
            TBE.Maghsad = T.Maghsad;
            TBE.Mabdae = T.Mabdae;
            TBE.numAIR = T.numAIR;
            TBE.TypeAir = T.TypeAir;
            UpLoadfile UPF = new UpLoadfile(Environment);
            TBE.Pic = UPF.UpLoad(T.Pic);
            TBLL.Update(TBE);
            return "";
        }
        [HttpPost]
        public IActionResult edit(TicketBE T)
        {
            DB db = new DB();
            var q = db.Tickets.Where(i => i.ID == T.ID).FirstOrDefault();
            q.Mabdae = T.Mabdae;
            q.Maghsad = T.Maghsad;
            q.numAIR = T.numAIR;
            q.TypeAir = T.TypeAir;
            q.Price = T.Price;
            q.Pic = T.Pic;
            db.Tickets.Update(q);
            db.SaveChanges();
            return RedirectToAction("Showall");
        }
        public IActionResult getall()
        {
            TicketBLL TBLL = new TicketBLL();
            ViewBag.Ticketall = TBLL.getall();
            return View();
        }
        public ActionResult Edit(int ID)
        {
            TicketBLL TBLL = new TicketBLL();
            CompanyBLL CBLL = new CompanyBLL();
            var beticket = TBLL.SearchById(ID);
            ViewBag.company = CBLL.getall();
            ViewBag.CompanyTicket = CBLL.GetCompanyTicket(ID);
            var modelticket = new Models.TicketM
            {
                ID = beticket.ID,
                Mabdae = beticket.Mabdae,
                Maghsad = beticket.Maghsad,
                Price = beticket.Price,
                numAIR = beticket.numAIR,
                TypeAir = beticket.TypeAir,
                PicUrl = beticket.Pic,
                Companys = beticket.company_Tickets.Select(i => i.Company.ID).ToList()
            };
            return View(modelticket);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editt(Models.TicketM Ticket)
        {
            TicketBLL TBLL = new TicketBLL();
            var beTicket = TBLL.SearchById(Ticket.ID);
            beTicket.ID = Ticket.ID;
            beTicket.Mabdae = Ticket.Mabdae;
            beTicket.Maghsad = Ticket.Maghsad;
            beTicket.Price = Ticket.Price;
            beTicket.numAIR = Ticket.numAIR;
            beTicket.TypeAir = Ticket.TypeAir;
            if (Ticket.Pic != null) 
            {
                UpLoadfile UPF = new UpLoadfile(Environment);
                beTicket.Pic = UPF.UpLoad(Ticket.Pic);
            }
            TBLL.Update(beTicket);
            return RedirectToAction(nameof(getall));
        }
        public ActionResult Details(int id)
        {
            TicketBLL TBLL = new TicketBLL();
            TicketBE TBE = new TicketBE();
            TBE = TBLL.SearchById(id);
            return View(TBE);
        }
    }
}
