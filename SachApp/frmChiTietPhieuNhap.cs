using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SachApp.Service.Dao;
using SachApp.Service.BLL;

namespace SachApp
{
    public partial class frmChiTietPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmChiTietPhieuNhap(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        int id;
        ChiTietPhieuNhapBus bus = new ChiTietPhieuNhapBus();
        private void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = bus.GetData(id);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}