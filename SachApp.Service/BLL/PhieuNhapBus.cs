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
    public class PhieuNhapBus
    {
        PhieuNhapDao dao = new PhieuNhapDao();
        
        public PhieuNhap GetNewPhieuNhap()
        {
            PhieuNhap obj = new PhieuNhap();
            DataTable dt = dao.GetNew();
            if (dt.Rows.Count > 0)
            {
                obj.MAPN = dt.Rows[0]["MAPN"].ToString();
                obj.MANV = int.Parse(dt.Rows[0]["MANV"].ToString());
                obj.MANPP = int.Parse(dt.Rows[0]["MANPP"].ToString());
                obj.NGAYLAP = DateTime.Parse(dt.Rows[0]["NGAYLAP"].ToString());
                obj.TONGTIEN = decimal.Parse(dt.Rows[0]["TONGTIEN"].ToString());
                return obj;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetPN()
        {
            return dao.GetPN();
        }
        public int Insert(PhieuNhap obj)
        {
            return dao.Insert(obj);
        }

        public int Update(PhieuNhap obj)
        {
            return dao.Update(obj);
        }

        public int UpdateNPP(PhieuNhap obj)
        {
            return dao.UpdateNPP(obj);
        }
        public DataTable GetPrintfData(string maPN)
        {
            return dao.GetPrintfData(maPN);
        }
        public int Delete(string MAPN)
        {
            return dao.Delete(MAPN);
        }
        public DataTable ThongKePhieuNhap(int nv_id, string time1, string time2)
        {
            return dao.ThongKePhieuNhap(nv_id, time1, time2);
        }
    }
}
