using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SachApp.Service.Models;
using SachApp;
using SachApp.Service.BLL;

namespace CuaHangSach
{
    public partial class frmThongTinCaNhan : DevExpress.XtraEditors.XtraForm
    {
        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }
        NhanVien obj = new NhanVien();
        NhanVienBus bus = new NhanVienBus();
     //   bool IsUpdate = false;

        void KhoaDieuKhien()
        {
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            dtNgaySinh.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtMatKhau.Enabled = false;
            txtChucVu.Enabled = false;

            btnDoiMK.Enabled = true;
            btnDoiThongTin.Enabled = true;
            btnLuu.Enabled = false;
        }
        void MoKhoaDieuKhien()
        {
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = true;
          
            dtNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            txtTaiKhoan.Enabled = false;
            txtMatKhau.Enabled = false;
            txtChucVu.Enabled = false;

            btnDoiMK.Enabled = false;
            btnDoiThongTin.Enabled = false;
            btnLuu.Enabled = true;
        }
        void Hienthi()
        {

            DataTable dt = new DataTable();
            //dt = bus.GetDataByAccount(frmDangNhap.user,frmDangNhap.pass);
            txtMaNV.Text = dt.Rows[0]["MANV"].ToString();
            txtTenNV.Text = dt.Rows[0]["TENNV"].ToString();
           
            dtNgaySinh.Text = dt.Rows[0]["NGAYSINH"].ToString();
            txtSDT.Text = dt.Rows[0]["DIENTHOAI"].ToString();
            txtDiaChi.Text = dt.Rows[0]["DIACHI"].ToString();
            txtTaiKhoan.Text = dt.Rows[0]["TAIKHOAN"].ToString();
            txtMatKhau.Text = dt.Rows[0]["MATKHAU"].ToString();
            txtChucVu.Text = dt.Rows[0]["QUYEN"].ToString();
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            Hienthi();
        }

        private void btnDoiThongTin_Click(object sender, EventArgs e)
        {
            MoKhoaDieuKhien();
        //    IsUpdate = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //obj.MaNV = txtMaNV.Text;
            //obj.TenNV = txtTenNV.Text;
            //obj.GioiTinh = txtGioitinh.Text;
            //obj.NgaySinh = DateTime.Parse(dtNgaySinh.Text);
            //obj.DienThoai = txtSDT.Text;
            //obj.DiaChi = txtDiaChi.Text;
            //obj.TaiKhoan = txtTaiKhoan.Text;
            //obj.MatKhau = txtMatKhau.Text;
            //obj.QUYEN = txtChucVu.Text;

            //bus.Update(obj);
            //XtraMessageBox.Show("Sửa thành công!");
            //Hienthi();
            //KhoaDieuKhien();
        }

        private void radGT_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtGioitinh.Text = radGT.EditValue.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmDoiMK frm = new frmDoiMK();
            frm.ShowDialog();
        }

        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}