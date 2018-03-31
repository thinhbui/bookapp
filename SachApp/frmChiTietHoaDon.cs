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
    public partial class frmChiTietHoaDon : DevExpress.XtraEditors.XtraForm
    {
        string id;
        public frmChiTietHoaDon(string id)
        {
            InitializeComponent();
            this.id = id;
        }
       
        ChiTietHoaDonBus bus = new ChiTietHoaDonBus();
        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
        void show()
        {
            gridControl1.DataSource = bus.GetData(id);
        }
        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            show();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}