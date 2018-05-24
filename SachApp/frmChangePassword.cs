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
using SachApp.Service.Models;
using SachApp.Service.BLL;

namespace SachApp
{
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        public NhanVien nv = new NhanVien();
        NhanVienBus nvBus = new NhanVienBus();
        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPass = nv.MATKHAU;
            if (txtOldPass.Text == oldPass)
                if (txtNewPass.Text == txtComfirm.Text)
                    if (XtraMessageBox.Show("Bạn có muốn đổi không?", "Thông Báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        nv.MATKHAU = txtNewPass.Text;
                        nvBus.Update_MK(nv);
                        XtraMessageBox.Show("Đổi mật khẩu thành công!");
                        this.Hide();
                    }
                else XtraMessageBox.Show("Nhập lại mật khẩu sai!", "Thông báo!!!");
            else XtraMessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo!!!");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}