using BE;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public  class CompanyDAL
	{
		public void Create(Company C)
		{
			DB db = new DB();
			db.Add(C);
			db.SaveChanges();
		}
		public List<Company> getall()
		{
			DB db = new DB();
			var q = from i in db.Companies select i;
			return q.ToList();
		}
		public int gettotall()
		{
			DB db = new DB();
			return db.Companies.Count();
		}
		public List<Company> getskip(int C)
		{
			int T = C * 10;
			DB db = new DB();
			var q = db.Companies.Skip(T).Take(10);
			return q.ToList();
		}
		public List<Company> Search(List<string> tags)
		{
			List<Company> LT = new List<Company>();
			foreach (var item in tags)
			{
				DB db = new DB();
				var q = from i in db.Companies where i.Name.Contains(item.ToString()) || i.Addres.Contains(item.ToString()) select i;
				LT = LT.Concat(q.ToList()).ToList();
			}
			return LT;
		}
		public void Update(Company C)
		{
			DB db = new DB();
			var q = from i in db.Companies where i.ID == C.ID select i;
			q.Single().Name = C.Name;
			q.Single().Phone = C.Phone;
			q.Single().Addres = C.Addres;
			q.Single().pic = C.pic;
			db.SaveChanges();
		}

		public List<int> GetCompanyTicket(int id)
        {
			DB db = new DB();
			return db.Company_Tickets.Where(t => t.TicketBEID == id).Select(t => t.CompanyID).ToList();
        }
	}
}
