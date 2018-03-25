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
    public class SachBus
    {
        SachDao dao = new SachDao();
        public DataTable GetData()
        {
            return dao.GetData();
        }
        public DataTable GetDataByID(int maSach)
        {
            return dao.GetDataByID(maSach);
        }

        public Sach GetNew()
        {
            Sach obj = new Sach();
            DataTable dt = dao.GetNewSach();
            if (dt.Rows.Count > 0)
            {
                obj.MASACH = int.Parse(dt.Rows[0]["MASACH"].ToString());
                obj.TENSACH = dt.Rows[0]["TENSACH"].ToString();
                obj.MATHELOAI = int.Parse(dt.Rows[0]["MATHELOAI"].ToString());
                obj.NAMXUATBAN = int.Parse(dt.Rows[0]["NAMXUATBAN"].ToString());
                obj.MATG = int.Parse(dt.Rows[0]["MATG"].ToString());
                obj.BARCODE = dt.Rows[0]["BARCODE"].ToString();
                obj.GIAMUA = decimal.Parse(dt.Rows[0]["GIAMUA"].ToString());
                obj.GIABAN = decimal.Parse(dt.Rows[0]["GIABAN"].ToString());
                obj.SOLUONGKHO = int.Parse(dt.Rows[0]["SOLUONGKHO"].ToString());
                obj.MANXB = int.Parse(dt.Rows[0]["MANXB"].ToString());
                obj.MOTA = dt.Rows[0]["MOTA"].ToString();
                obj.CREATEDATE = DateTime.Parse(dt.Rows[0]["CREATEDATE"].ToString());
                return obj;
            }
            else
                return null;
        }



        public int Insert(Sach obj)
        {
            return dao.Insert(obj);
        }
        public int Update(Sach obj)
        {
            return dao.Update(obj);
        }
        public int Delete(int maSach)
        {
            return dao.Delete(maSach);
        }
    }
}
