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
    public class PhieuNhapDao : dbContext
    {
        public DataTable GetData()
        {
            return base.GetData("PHIEUNHAP_GETALL", null);
        }
        public DataTable GetDataByID(int MAPN)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MAPN", MAPN)
            };
            return base.GetData("PHIEUNHAP_GET_BYID", para);
        }

        public DataTable GetNew()
        {
            return base.GetData("PHIEUNHAP_GETNEW", null);
        }

        public int Insert(PhieuNhap obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MANV",obj.MANV),
                new SqlParameter("NGAYLAP",obj.NGAYLAP),
                new SqlParameter("MANPP",obj.MANPP),
                new SqlParameter("TONGTIEN",obj.TONGTIEN)
            };
            return base.ExecuteSQL("PHIEUNHAP_INSERT", para);
        }

        public int Update(PhieuNhap obj)
        {
            SqlParameter[] para =
           {
                new SqlParameter("MAPN",obj.MAPN),
                new SqlParameter("TONGTIEN",obj.TONGTIEN)
            };
            return base.ExecuteSQL("PHIEUNHAP_UPDATE", para);
        }

        public int UpdateNPP(PhieuNhap obj)
        {
            SqlParameter[] para =
           {
                new SqlParameter("MAPN",obj.MAPN),
                new SqlParameter("MANPP",obj.MANPP)
            };
            return base.ExecuteSQL("PHIEUNHAP_UPDATE_NPP", para);
        }


        public int Delete(int MAPN)
        {
            SqlParameter[] para =
               {
                new SqlParameter("MAPN", MAPN)
            };
            return base.ExecuteSQL("PHIEUNHAP_DELETE", para);
        }
        public DataTable ThongKePhieuNhap(int nv_id, string time1, string time2)
        {
            SqlParameter[] para =
          {
                new SqlParameter("TIME1",time1),
                new SqlParameter("TIME2",time2),
                new SqlParameter("MANV",nv_id),
            };
            return base.GetData("PHIEUNHAP_SELECT_MANY", para);
        }
    }
}
