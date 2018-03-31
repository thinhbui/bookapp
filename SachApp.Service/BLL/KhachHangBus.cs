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
    public class KhachHangBus
    {
        KhachHangDao dao = new KhachHangDao();
        public DataTable GetData()
        {
            return dao.GetData();
        }
        public int Insert(KhachHang obj)
        {
            return dao.Insert(obj);
        }
        public int Update(KhachHang obj)
        {
            return dao.Update(obj);
        }
        public int Delete(int id)
        {
            return dao.Delete(id);
        }
        public int SelectByID(int id)
        {
            return dao.SelectById(id);
        }
        public DataTable SelectByHD(int id)
        {
            return dao.SelectHoaDon(id);
        }
    }
}
