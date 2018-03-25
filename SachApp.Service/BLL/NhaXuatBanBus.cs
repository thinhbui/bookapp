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
    public class NhaXuatBanBus
    {
        NhaXuatBanDao dao = new NhaXuatBanDao();
        public DataTable GetNXB()
        {
            return dao.GetNXB();
        }
        public int Insert(NhaXuatBan obj)
        {
            return dao.Insert(obj);
        }
        public int Update(NhaXuatBan obj)
        {
            return dao.Update(obj);
        }
        public int Delete(int maNXB)
        {
            return dao.Delete(maNXB);
        }
    }
}
