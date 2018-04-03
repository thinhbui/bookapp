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
using SachApp.Service.BLL;
using SachApp.Service.Models;
using SachApp.Service.Dao;

namespace SachApp
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        NhanVienBus nvBus = new NhanVienBus();
        NhanVienDao nvDao = new NhanVienDao();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            NhanVien obj = new NhanVien();
            obj = nvBus.GetUser(txtUserName.Text, txtPassword.Text);
            //obj = nvDao.GetDataByName(txtUserName.Text, txtPassword.Text);
            if (obj != null)
            {
                frmMain frm = new frmMain();
              //  frm.nvObj = obj;
                frm.Show();
                Hide();
            }
            else
            {
                XtraMessageBox.Show("Đăng nhập thất bại", "Thông báo!");
                txtPassword.Text = string.Empty;
                txtUserName.Text = string.Empty;
                txtUserName.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}