using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SachApp;
using SachApp.Service.Models;
using SachApp.Service.BLL;

namespace CuaHangSach
{
    public partial class frmDoiMK : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMK()
        {
            InitializeComponent();
        }
        NhanVien obj = new NhanVien();
        NhanVienBus bus = new NhanVienBus();

        private void btnDoi_Click(object sender, EventArgs e)
        { 
        //{
        //    if(XtraMessageBox.Show("Bạn có muốn đổi không?", "Thông Báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        string MKcu = frmDangNhap.pass;
        //        if (txtMKcu1.Text == txtMKcu2.Text && txtMKcu1.Text == MKcu)
        //        {
        //            obj.MaNV = frmDangNhap.manv;
        //            obj.MatKhau = txtMKmoi.Text;
        //            bus.Update_MK(obj);
        //            XtraMessageBox.Show("Đổi mật khẩu thành công!");
        //            this.Hide();
        //        }
        //        else
        //        {
        //            if (txtMKcu1.Text != MKcu)
        //            {
        //                XtraMessageBox.Show("Bạn đã nhập mật khẩu sai!", "Thông báo!!!");
        //            }
        //            else
        //            {
        //                XtraMessageBox.Show("Bạn đã nhập lại sai!", "Thông báo!!!");
        //            }
        //        }
        //    }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}