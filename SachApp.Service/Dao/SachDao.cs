
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
    public class SachDao : dbContext
    {
        public DataTable GetData()
        {
            return base.GetData("SACH_GETALL", null);
        }
        public DataTable GetDataByID(int MASACH)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MASACH", MASACH)
            };
            return base.GetData("SACH_GET_BYiD", para);
        }

        public DataTable GetNewSach()
        {
            return base.GetData("SACH_GETNEW", null);
        }


        public int Insert(Sach obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TENSACH",obj.TENSACH),
                new SqlParameter("MATHELOAI",obj.MATHELOAI),
                new SqlParameter("NAMXUATBAN",obj.NAMXUATBAN),
                new SqlParameter("TACGIA",obj.TACGIA),
                new SqlParameter("BARCODE",obj.BARCODE),
                new SqlParameter("GIAMUA",obj.GIAMUA),
                new SqlParameter("GIABAN",obj.GIABAN),
                new SqlParameter("SOLUONGKHO",obj.SOLUONGKHO),
                new SqlParameter("MANXB",obj.MANXB),
                new SqlParameter("MOTA",obj.MOTA),
                new SqlParameter("CREATEDATE",obj.CREATEDATE)
            };
            return base.ExecuteSQL("SACH_INSERT", para);
        }

        public int Update(Sach obj)
        {
            SqlParameter[] para =
           {
                new SqlParameter("MASACH",obj.MASACH),
                new SqlParameter("TENSACH",obj.TENSACH),
                new SqlParameter("MATHELOAI",obj.MATHELOAI),
                new SqlParameter("NAMXUATBAN",obj.NAMXUATBAN),
                new SqlParameter("TACGIA",obj.TACGIA),
                new SqlParameter("BARCODE",obj.BARCODE),
                new SqlParameter("GIAMUA",obj.GIAMUA),
                new SqlParameter("GIABAN",obj.GIABAN),
                new SqlParameter("SOLUONGKHO",obj.SOLUONGKHO),
                new SqlParameter("MANXB",obj.MANXB),
                new SqlParameter("MOTA",obj.MOTA)
                
            };
            return base.ExecuteSQL("SACH_UPDATE", para);
        }
        public int Delete(int MASACH)
        {
            SqlParameter[] para =
               {
                new SqlParameter("MASACH", MASACH)
            };
            return base.ExecuteSQL("SACH_DELETE", para);
        }

    }
}
