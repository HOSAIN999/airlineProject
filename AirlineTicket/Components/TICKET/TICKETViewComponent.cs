using BLL;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AirlineTicket.ViewComponents.TICKETLI
{
    [ViewComponent(Name = "TICKET")]
    public class TICKETViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            TicketBLL TBLL = new TicketBLL();
            var q = TBLL.GetAllCompany();
            return View("TICKETLI",q);
        }
    }
}
