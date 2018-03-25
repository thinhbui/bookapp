using SachApp.Service.Dao;
using SachApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.BLL
{
    public class NhaPhanPhoiBus
    {
        NhaPhanPhoiDao dao = new NhaPhanPhoiDao();
        public DataTable GetNPP()
        {
            return dao.GetNPP();
        }
        public int Insert(NhaPhanPhoi obj)
        {
            return dao.Insert(obj);
        }
        public int Update(NhaPhanPhoi obj)
        {
            return dao.Update(obj);
        }
        public int Delete(int maNPP)
        {
            return dao.Delete(maNPP);
        }
    }
}
