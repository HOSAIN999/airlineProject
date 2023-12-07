using BE;
using DAL;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
	public  class CompanyBLL
	{
		public void Create(Company C)
		{
			CompanyDAL CDAL = new CompanyDAL();
			CDAL.Create(C);
		}
		public void Update(Company C)
		{
			CompanyDAL CDAL = new CompanyDAL();
			CDAL.Update(C);
		}
		public List<Company> getall()
		{
			CompanyDAL CDAL = new CompanyDAL();
			return CDAL.getall();
		}
		public int gettotall()
		{
			CompanyDAL CDAL = new CompanyDAL();
			return CDAL.gettotall();
		}
		public List<Company> getskip(int C)
		{
			CompanyDAL CDAL = new CompanyDAL();
			return CDAL.getskip(C);
		}
		public List<Company> Search(List<string> tags)
		{
			CompanyDAL CDAL = new CompanyDAL();
			return CDAL.Search(tags);
		}

		public List<int> GetCompanyTicket(int id)
        {
			CompanyDAL CDAL = new CompanyDAL();
			return CDAL.GetCompanyTicket(id);
		}
	}
}
