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
    public class KhachHangDao : dbContext
    {
        public DataTable GetKH()
        {
            return base.GetData("KHACHHANG_GETALL", null);
        }

        public int Insert(KhachHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TENKH",obj.TENKH),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("DIACHI",obj.DIACHI),
            };
            return base.ExecuteSQL("KHACHHANG_INSERT", para);
        }
        public DataTable GetData()
        {
            return base.GetData("KHACHHANG_SELECTALL", null);
        }


        public int Update(KhachHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("ID",obj.MAKH),
                new SqlParameter("TENKH",obj.TENKH),
                new SqlParameter("SDT",obj.DIENTHOAI),
                new SqlParameter("DIACHI",obj.DIACHI),

            };
            return base.ExecuteSQL("KHACHHANG_UPDATE", para);
        }
        public int Delete(int id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("ID",id)
            };
            return base.ExecuteSQL("KHACHHANG_DELETE", para);
        }
        public int SelectById(int id)
        {
            SqlParameter[] para =
           {
                new SqlParameter("ID",id)
            };
            return base.ExecuteSQL("KHACHHANG_SELECT_BYID", para);
        }
        public DataTable SelectHoaDon(int makh)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MAKH",makh)
            };
            return base.GetData("HOADON_SELECT_BY_KH", para);
        }
    }
}
