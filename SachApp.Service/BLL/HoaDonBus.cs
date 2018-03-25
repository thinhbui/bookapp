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
    public class HoaDonBus
    {
        HoaDonDao dao = new HoaDonDao();
        public HoaDon GetNewHoaDon()
        {
            HoaDon obj = new HoaDon();
            DataTable dt = dao.GetNew();
            if (dt.Rows.Count > 0)
            {
                obj.MAHD = int.Parse(dt.Rows[0]["MAHD"].ToString());
                obj.MANV = int.Parse(dt.Rows[0]["MANV"].ToString());
                obj.MAKH = int.Parse(dt.Rows[0]["MAKH"].ToString());
                obj.NGAYLAP = DateTime.Parse(dt.Rows[0]["NGAYLAP"].ToString());
                obj.TONGTIEN = decimal.Parse(dt.Rows[0]["TONGTIEN"].ToString());
                return obj;
            }
            else
            {
                return null;
            }
        }
        public DataTable ThongKeHoaDon(int nv_id, string time1, string time2)
        {
            return dao.ThongKeHoaDon(nv_id, time1, time2);
        }
        public DataTable GetData()
        {
            return dao.GetData();
        }
        public DataTable GetDataHD()
        {
            return dao.GetDataHD();
        }


        public int Insert(HoaDon obj)
        {
            return dao.Insert(obj);
        }

        public int Update(HoaDon obj)
        {
            return dao.Update(obj);
        }

        public int UpdateKH(HoaDon obj)
        {
            return dao.UpdateKH(obj);
        }

        public int Delete(int maHD)
        {
            return dao.Delete(maHD);
        }


    }
}
