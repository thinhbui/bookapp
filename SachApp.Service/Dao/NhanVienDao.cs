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
    public class NhanVienDao : dbContext
    {

        public DataTable GetData()
        {
            return base.GetData("NHANVIEN_SELECT_ALL", null);
        }
        public DataTable GetDataByAccount(string TK, string MK)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TAIKHOAN",TK),
                new SqlParameter("MATKHAU",MK)
            };
            return base.GetData("NHANVIEN_SELECT_BYACCOUNT", para);
        }

        public int Insert(NhanVien obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TENNV",obj.TENNV),
                new SqlParameter("GT",obj.GT),
                new SqlParameter("NGAYSINH",obj.NGAYSINH),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("DIACHI",obj.DIACHI),
                new SqlParameter("TAIKHOAN",obj.TAIKHOAN),
                new SqlParameter("MATKHAU",obj.MATKHAU),
                new SqlParameter("EMAIL",obj.EMAIL),
                new SqlParameter("MAQUYEN",obj.MAQUYEN)
            };
            return base.ExecuteSQL("NHANVIEN_INSERT", para);
        }
        public int Update(NhanVien obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MANV",obj.MANV),
                new SqlParameter("TENNV",obj.TENNV),
                new SqlParameter("GT",obj.GT),
                new SqlParameter("NGAYSINH",obj.NGAYSINH),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("DIACHI",obj.DIACHI),
                new SqlParameter("TAIKHOAN",obj.TAIKHOAN),
                new SqlParameter("EMAIL",obj.TAIKHOAN),
                new SqlParameter("MAQUYEN",obj.MAQUYEN)
            };
            return base.ExecuteSQL("NHANVIEN_UPDATE", para);
        }
        public int Update_MK(NhanVien obj)
        {
            SqlParameter[] para =
            {   new SqlParameter("MANV",obj.MANV),
                new SqlParameter("MATKHAU",obj.MATKHAU)
            };
            return base.ExecuteSQL("NHANVIEN_UPDATE_MK", para);
        }
        public int Delete(int id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MANV",id)
            };
            return base.ExecuteSQL("NHANVIEN_DELETE", para);
        }
        public DataTable GetDataByName(string userName, string password)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TAIKHOAN", userName),
                new SqlParameter("MATKHAU",password)
            };
            return base.GetData("NHANVIEN_GET_BY_USER", para);

        }
    }
}
