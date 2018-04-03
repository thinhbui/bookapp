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
    public class ChiTietHoaDonBus
    {
        ChiTietHoaDonDao dao = new ChiTietHoaDonDao();
        public DataTable GetData(string maHD)
        {
            return dao.GetData(maHD);
        }

        public DataTable GetDataById(int maHD, int maSach)
        {
            return dao.GetDataById(maHD, maSach);
        }

        public int Insert(ChiTietHoaDon obj)
        {
            return dao.Insert(obj);
        }
        public int Update(ChiTietHoaDon obj)
        {
            return dao.Update(obj);
        }
        public int Delete(string maHD, int maSach, int soLuong)
        {
            return dao.Delete(maHD, maSach, soLuong);
        }
    }
}
