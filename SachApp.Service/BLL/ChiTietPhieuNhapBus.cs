﻿using SachApp.Service.Dao;
using SachApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.BLL
{
    public class ChiTietPhieuNhapBus
    {
        ChiTietPhieuNhapDao dao = new ChiTietPhieuNhapDao();
        public DataTable GetData(string maPN)
        {
            return dao.GetDataByMaPN(maPN);
        }

        public DataTable GetDataById(int maPN,int maSach)
        {
            return dao.GetDataById(maPN,maSach);
        }

        public int Insert(ChiTietPhieuNhap obj)
        {
            return dao.Insert(obj);
        }
        public int Update(ChiTietPhieuNhap obj)
        {
            return dao.Update(obj);
        }
        public int Delete(string maPN,int maSach)
        {
            return dao.Delete(maPN, maSach);
        }
    }
}
