using BE;
using DAL;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class TicketBLL
    {
        public int Create(TicketBE T)
        {
            TicketDAL TDAL = new TicketDAL();
            return TDAL.Create(T);
        }
        public List <TicketBE> getall()
        {
            TicketDAL TDAL = new TicketDAL();
            return TDAL.getall();
        }
        public List<TicketBE> Search(List<string> search)
        {
            TicketDAL TDAL = new TicketDAL();
            return TDAL.Search(search);
        }
        public int gettotall()
        {
            TicketDAL TDAL = new TicketDAL();
            return TDAL.gettotall();
        }
        public List<TicketBE> getskip(int C)
        {
            TicketDAL TDAL = new TicketDAL();
            return TDAL.getskip(C) ;
        }
        public void Update(TicketBE T)
        {
            TicketDAL TDAL = new TicketDAL();
            TDAL.Update(T);
        }
        public List<TicketBE> Search(string Ticket)
        {
            TicketDAL TDAL = new TicketDAL();
            return TDAL.Search(Ticket);
        }
        public TicketBE SearchById(int id)
        {
            TicketDAL TDAL = new TicketDAL();
            return TDAL.SearchById(id);
        }
        public List<TicketBE> GetAllCompany()
        {
            TicketDAL TDAL = new TicketDAL();
            return TDAL.GetAllCompany();
        }
        public List<TicketBE> SearchById(List<int> ids)
        {
            TicketDAL TDAL = new TicketDAL();
            return TDAL.SearchById(ids);
        }
    }
}
