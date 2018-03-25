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
    public class TheLoaiDao : dbContext
    {
        public DataTable GetTheLoai()
        {
            return base.GetData("THELOAI_GETALL", null);
        }
        public int Delete(int Ma)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MATHELOAI",Ma)
            };
            return base.ExecuteSQL("THELOAI_DELETE", para);
        }
        public int Insert(TheLoai obj)
        {
            SqlParameter[] para =
            {   
                new SqlParameter("TENTHELOAI",obj.TENTHELOAI),
                new SqlParameter("MOTA",obj.MOTA)
            };
            return base.ExecuteSQL("THELOAI_INSERT", para);
        }
        public int Update(TheLoai obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MATHELOAI",obj.MATHELOAI),
                new SqlParameter("TENTHELOAI",obj.TENTHELOAI),
                new SqlParameter("MOTA",obj.MOTA)
            };
            return base.ExecuteSQL("THELOAI_UPDATE", para);
        }
    }
}
