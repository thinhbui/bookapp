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
    public class TheLoaiBus
    {
        TheLoaiDao dao = new TheLoaiDao();
        public DataTable GetTheLoai()
        {
            return dao.GetTheLoai();
        }
        public int Insert(TheLoai obj)
        {
            return dao.Insert(obj);
        }
        public int Update(TheLoai obj)
        {
            return dao.Update(obj);
        }
        public int Delete(int maTL)
        {
            return dao.Delete(maTL);
        }
    }
}
