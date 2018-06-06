using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SachApp.Service.Models;
using SachApp.Service.BLL;
using System.Data;

namespace SachApp
{
    public partial class reportPhieuNhap : DevExpress.XtraReports.UI.XtraReport
    {
        public reportPhieuNhap(string maPn)
        {
            InitializeComponent();
            //PhieuNhap pnObj = new PhieuNhap();
            PhieuNhapBus pnBus = new PhieuNhapBus();
            DataTable dt = pnBus.GetPrintfData(maPn);
            if (dt.Rows.Count > 0)
            {
                lbNgayLap.Text = dt.Rows[0]["NGAYLAP"].ToString();
                lbNhanVien.Text = dt.Rows[0]["TENNV"].ToString();
                lbNhaPhanPhoi.Text = dt.Rows[0]["TENNPP"].ToString();
                lbDienThoai.Text = dt.Rows[0]["DIENTHOAI"].ToString();
                lbTongTien.Text = dt.Rows[0]["TONGTIEN"].ToString();
            }

            this.Parameters["maPN"].Value = Int64.Parse(dt.Rows[0]["MAPN"].ToString());
            
            //lbDienThoai = 
        }

    }
}
