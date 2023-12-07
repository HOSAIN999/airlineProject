using BE;
using DAL;
using BLL;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace AirlineTicket.Controllers.Admin
{
	public class CompanyController : Controller
	{
		private IWebHostEnvironment Environment;
		public CompanyController(IWebHostEnvironment _environment)
		{
			Environment = _environment;
		}
		public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
		public IActionResult Create(Models.CompanyM C)
        {
			CompanyBLL CBLL = new CompanyBLL();
			Company CBE = new Company();
			CBE.Name = C.Name;
			CBE.Addres = C.Addres;
			CBE.Phone = C.Phone;
			UpLoadfile UPF = new UpLoadfile(Environment);
			CBE.pic = UPF.UpLoad(C.pic);
			CBLL.Create(CBE);
			return RedirectToAction("Index", "Company");
        }
        [HttpPost]
		public string Update(Models.CompanyM C)
        {
			UpLoadfile UPF = new UpLoadfile(Environment);
			CompanyBLL CBLL = new CompanyBLL();
			Company CBE = new Company();
			CBE.ID = C.ID;
			CBE.Name = C.Name;
			CBE.Addres = C.Addres;
			CBE.Phone = C.Phone;
			if (CBE.pic != null)
				CBE.pic = UPF.UpLoad(C.pic);
			CBLL.Update(CBE);
			return "";
        }
		public IActionResult getskip(int C)
		{
			CompanyBLL CBLL = new CompanyBLL();
			return View("Index", CBLL.getskip(C));
		}
		public IActionResult Showall()
		{
			CompanyBLL CBLL = new CompanyBLL();

			return View("Index", CBLL.getskip(0));
		}
	}
}
