using BE;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public  class OrderDAL
    {
        public void Create(Order O)
        {
            DB db = new DB();
             db.Order.Add(O);
            db.SaveChanges();
            
        }
        public List<Order> getall()
        {
            DB db = new DB();
            var q = from i in db.Order select i;
            return q.ToList();
        }
        public Order SearchById(int id)
        {
            DB db = new DB();
            var q = from i in db.Order where i.ID == id select i;
            return q.SingleOrDefault();
        }
        public List<Order> getskip(int O)
        {
            int T = O * 10;
            DB db = new DB();
            var q = db.Order.Skip(T).Take(10);
            return q.ToList();
        }
    }
}
