using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace AirlineTicket.Models
{
    public class TicketM
    {
        public int ID { get; set; }
        public string Mabdae { get; set; }
        public string Maghsad { get; set; }
        public float Price { get; set; }
        public string numAIR { get; set; }
        public string TypeAir { get; set; }
        public IFormFile Pic { get; set; }
        public string PicUrl { get; set; }
        public List<int> Companys { get; set; }
    }
    public class CompanyM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }
        public IFormFile pic { get; set; }
        
    }
}
