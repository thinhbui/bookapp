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
using SachApp.Service.Models;
using SachApp.Service.BLL;

namespace SachApp
{
    public partial class frmAddKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmAddKhachHang()
        {
            InitializeComponent();
        }

        KhachHangBus khBus = new KhachHangBus();

        public delegate void getDataSoucre(DataTable dt);

        public getDataSoucre getData;




        private void frmAddKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhachHang obj = new KhachHang();
            obj.TENKH = txtTenKH.Text;
            obj.DIACHI = txtDiaChi.Text;
            obj.DIENTHOAI = txtPhone.Text;

            khBus.Insert(obj);

            DataTable dt = khBus.GetKH();
            getData(dt);

            XtraMessageBox.Show("Thêm thành công");
            this.Close();
        }
    }
}