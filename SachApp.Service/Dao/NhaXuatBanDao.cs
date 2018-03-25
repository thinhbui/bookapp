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
    public class NhaXuatBanDao : dbContext
    {
        public DataTable GetNXB()
        {
            return base.GetData("NXB_GETALL", null);
        }

        public int Insert(NhaXuatBan obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TENNXB",obj.TENNXB),
                new SqlParameter("DIACHI",obj.DIACHI),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("EMAIL",obj.EMAIL)
            };
            return base.ExecuteSQL("NXB_INSERT", para);
        }
        public int Delete(int maNXB)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MANXB",maNXB)
            };
            return base.ExecuteSQL("NXB_DELETE", para);
        }
        public int Update(NhaXuatBan obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MANXB",obj.MANXB),
                new SqlParameter("TENNXB",obj.TENNXB),
                new SqlParameter("DIACHI",obj.DIACHI),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("EMAIL",obj.EMAIL)
            };
            return base.ExecuteSQL("NXB_UPDATE", para);
        }
    }
}
