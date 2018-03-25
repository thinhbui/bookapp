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
    public class NhanVienBus
    {
        NhanVienDao dao = new NhanVienDao();

        public DataTable GetData()
        {
            return dao.GetData();
        }
        public DataTable GetDataByAccount(string TK, string MK)
        {
            return dao.GetDataByAccount(TK, MK);
        }

        public int Insert(NhanVien obj)
        {
            return dao.Insert(obj);
        }
        public int Update(NhanVien obj)
        {
            return dao.Update(obj);
        }
        public int Update_MK(NhanVien obj)
        {
            return dao.Update_MK(obj);
        }
        public int Delete(int id)
        {
            return dao.Delete(id);
        }

        public NhanVien GetUser(string userName, string password)
        {
            NhanVien obj = new NhanVien();
            DataTable dt = dao.GetDataByName(userName, password);
            if (dt.Rows.Count > 0)
            {
                obj.MANV = int.Parse(dt.Rows[0]["MANV"].ToString());
                obj.TENNV = dt.Rows[0]["TENNV"].ToString();
                obj.GT = dt.Rows[0]["GT"].ToString();
                obj.NGAYSINH = DateTime.Parse(dt.Rows[0]["NGAYSINH"].ToString());
                obj.DIENTHOAI = dt.Rows[0]["DIENTHOAI"].ToString();
                obj.DIACHI = dt.Rows[0]["DIACHI"].ToString();
                obj.TAIKHOAN = dt.Rows[0]["TAIKHOAN"].ToString();
                obj.MATKHAU = dt.Rows[0]["MATKHAU"].ToString();
                obj.EMAIL = dt.Rows[0]["EMAIL"].ToString();
                obj.MAQUYEN = int.Parse(dt.Rows[0]["MAQUYEN"].ToString());

                return obj;
            }
            else
            {
                return null;
            }

        }
    }
}
