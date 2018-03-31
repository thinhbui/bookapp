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
    public class ChiTietPhieuNhapDao : dbContext
    {
        public DataTable GetData(int maPN)
        {
            SqlParameter[] para =
           {
                new SqlParameter("MAPN", maPN)
            };
            return base.GetData("CHITIETPHIEUNHAP_GET_BY_MAPN", para);
        }

        public DataTable GetDataById(int maPN,int maSach)
        {
            SqlParameter[] para =
           {
                new SqlParameter("MAPN", maPN),
                new SqlParameter("MASACH", maSach)
            };
            return base.GetData("CHITIETPHIEUNHAP_GET_BY_MASACH", para);
        }


        public int Insert(ChiTietPhieuNhap obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MAPN",obj.MAPN),
                new SqlParameter("MASACH",obj.MASACH),
                new SqlParameter("SOLUONG",obj.SOLUONG),
                new SqlParameter("DONGIA",obj.DONGIA),
                new SqlParameter("THANHTIEN",obj.THANHTIEN)
            };
            return base.ExecuteSQL("CHITIETPHIEUNHAP_INSERT", para);
        }


        public int Update(ChiTietPhieuNhap obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MAPN",obj.MAPN),
                new SqlParameter("MASACH",obj.MASACH),
                new SqlParameter("SOLUONG",obj.SOLUONG),
                new SqlParameter("DONGIA",obj.DONGIA),
                new SqlParameter("THANHTIEN",obj.THANHTIEN)
            };
            return base.ExecuteSQL("CHITIETPHIEUNHAP_UPDATE", para);
        }


        public int Delete(string maPN,int maSach)
        {
            SqlParameter[] para =
               {
                new SqlParameter("MAPN", maPN),
                new SqlParameter("MASACH", maSach)
                };
            return base.ExecuteSQL("CHITIETPHIEUNHAP_DELETE", para);
        }
    }
}
