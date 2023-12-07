using BE;
using DAL;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class OrderBLL
    {
        public void Create(Order O)
        {
            OrderDAL ODAL = new OrderDAL();
            ODAL.Create(O);
        }
        public List<Order> getall()
        {
            OrderDAL ODAL = new OrderDAL();
            return ODAL.getall();
        }
        public Order SearchById(int id)
        {
            OrderDAL ODAL = new OrderDAL();
            return ODAL.SearchById(id);
        }
        public List<Order> getskip(int O)
        {
            OrderDAL ODAL = new OrderDAL();
            return ODAL.getskip(O);
        }
    }
}
