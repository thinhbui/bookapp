using SachApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Dao
{
    public class ChiTietHoaDonDao : dbContext
    {
        public DataTable GetData(string maHD)
        {
            SqlParameter[] para =
           {
                new SqlParameter("MAHD", maHD)
            };
            return base.GetData("CHITIETHOADON_GET_BY_MAHD", para);
        }

        public DataTable GetDataById(int maHD, int maSach)
        {
            SqlParameter[] para =
           {
                new SqlParameter("MAHD", maHD),
                new SqlParameter("MASACH", maSach)
            };
            return base.GetData("CHITIETHOADON_GET_BY_MASACH", para);
        }

        public int Insert(ChiTietHoaDon obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MAHD",obj.MAHD),
                new SqlParameter("MASACH",obj.MASACH),
                new SqlParameter("SOLUONG",obj.SOLUONG),
                new SqlParameter("GIASACH",obj.GIASACH),
                new SqlParameter("THANHTIEN",obj.THANHTIEN)
            };
            return base.ExecuteSQL("CHITIETHOADON_INSERT", para);
        }

        public int Update(ChiTietHoaDon obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MAHD",obj.MAHD),
                new SqlParameter("MASACH",obj.MASACH),
                new SqlParameter("SOLUONG",obj.SOLUONG),
                new SqlParameter("GIASACH",obj.GIASACH),
                new SqlParameter("THANHTIEN",obj.THANHTIEN)
            };
            return base.ExecuteSQL("CHITIETHOADON_UPDATE", para);
        }

        public int Delete(string maHD, int maSach, int soLuong)
        {
            SqlParameter[] para =
               {
                new SqlParameter("MAHD", maHD),
                new SqlParameter("MASACH", maSach),
                new SqlParameter("SOLUONG", soLuong),
                };
            return base.ExecuteSQL("CHITIETHOADON_DELETE", para);
        }
    }
}
