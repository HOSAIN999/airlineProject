using BE;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TicketDAL
    {
        public int Create(TicketBE T)
        {
            DB db = new DB();
            var add=db.Tickets.Add(T);
            db.SaveChanges();
            return add.Entity.ID;
        }
        public List<TicketBE> getall()
        {
            DB db = new DB();
            var q = from i in db.Tickets select i;
            return q.ToList();
        }

        public List<TicketBE> Search(List<string> Search)
        {
            List<TicketBE> LT = new List<TicketBE>();
            foreach (var item in Search)
            {
                DB db = new DB();
                var q = from i in db.Tickets where i.Mabdae.Contains(item.ToString()) || i.Maghsad.Contains(item.ToString()) || i.Price == Convert.ToInt32(item) select i;
                LT = LT.Concat(q.ToList()).ToList();
            }
            return LT;
        }
        public int gettotall()
        {
            DB db = new DB();
            return db.Tickets.Count();
        }
        public List<TicketBE> getskip(int C)
        {
            int T = C * 10;
            DB db = new DB();
            var q = db.Tickets.Skip(T).Take(10);
            return q.ToList();
        }
   
        public void Update(TicketBE T)
        {
            DB db = new DB();
            var q = from i in db.Tickets where i.ID == T.ID select i;
            q.Single().TypeAir = T.TypeAir;
            q.Single().Price = T.Price;
            q.Single().numAIR = T.numAIR;
            q.Single().Mabdae = T.Mabdae;
            q.Single().Maghsad = T.Maghsad;
            q.Single().Pic = T.Pic;
            db.SaveChanges();
        }
        public List<TicketBE> Search(string Ticket)
        {
            int n = 0;
            DB db = new DB();
            var q = from i in db.Tickets where i.Mabdae.Contains(Ticket.ToString()) 
                    || i.Maghsad.Contains(Ticket.ToString()) 
                    || (int.TryParse(Ticket, out n) ? i.Price == n : false) select i;
            return q.ToList();
        }
        public TicketBE SearchById(int id)
        {
            DB db = new DB();
            var q = from i in db.Tickets.Include(i => i.company_Tickets).ThenInclude(i => i.Company) where i.ID == id select i;
            return q.SingleOrDefault();
        }
       public List<TicketBE> GetAllCompany()
        {
            DB db = new DB();
            var q = db.Tickets.Include(s => s.company_Tickets).ThenInclude(s => s.Company).ToList();
            return q.ToList();
        }
        public List<TicketBE> SearchById(List<int> ids)
        {
            DB db = new DB();
            var q = from i in db.Tickets where ids.Contains(i.ID) select i;
            return q.ToList();
        }
    }
}
