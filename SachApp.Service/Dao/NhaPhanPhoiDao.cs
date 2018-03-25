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
    public class NhaPhanPhoiDao : dbContext
    {
        public DataTable GetNPP()
        {
            return base.GetData("NPP_GETALL", null);
        }

        public int Insert(NhaPhanPhoi obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TENNPP",obj.TENNPP),
                new SqlParameter("DIACHI",obj.DIACHI),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("FAX",obj.FAX),
                new SqlParameter("EMAIL",obj.EMAIL)
            };
            return base.ExecuteSQL("NPP_INSERT", para);
        }
        public int Delete(int maNPP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MANPP",maNPP)
            };
            return base.ExecuteSQL("NPP_DELETE", para);
        }
        public int Update(NhaPhanPhoi obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MANPP",obj.MANPP),
                new SqlParameter("TENNPP",obj.TENNPP),
                new SqlParameter("DIACHI",obj.DIACHI),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("EMAIL",obj.EMAIL),
                new SqlParameter("FAX",obj.FAX)
            };
            return base.ExecuteSQL("NPP_UPDATE", para);
        }
    }
}
