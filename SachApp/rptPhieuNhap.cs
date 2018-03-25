using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SachApp
{
    public partial class rptPhieuNhap : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPhieuNhap()
        {
            InitializeComponent();
            lbNgayLap.Text = DateTime.Now.ToString();
        }

    }
}
