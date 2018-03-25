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
    public class TacGiaBus
    {
        TacGiaDao dao = new TacGiaDao();
        public DataTable GetTacGia()
        {
            return dao.GetTacGia();
        }
        public int Insert(TacGia obj)
        {
            return dao.Insert(obj);
        }
        public int Update(TacGia obj)
        {
            return dao.Update(obj);
        }
        public int Delete(int maTG)
        {
            return dao.Delete(maTG);
        }
    }
}
