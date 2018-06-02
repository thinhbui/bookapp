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
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using SachApp.Service.BLL;

namespace SachApp
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBus bus = new NhanVienBus();
        QuyenBus qBus = new QuyenBus();
        bool isThem = false;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        void lockControl()
        {
            txtMa.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtDienThoai.Enabled = false;
            txtNgaySinh.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtTen.Enabled = false;
            layout1.Enabled = false;
            cbGT.Enabled = false;
            txtMatKhau.Enabled = false;
            deNgaySinh.Enabled = false;

            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;

        }
        void openControl()
        {
            txtMa.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtTaiKhoan.Enabled = true;
            txtTen.Enabled = true;
            layout1.Enabled = true;
            cbGT.Enabled = true;
            txtMatKhau.Enabled = false;
            deNgaySinh.Enabled = true;

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;

        }
        void show()
        {
            gridControl1.DataSource = bus.GetData();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cuaHangSachDataSet.Quyen' table. You can move, or remove it, as needed.
            //   this.quyenTableAdapter.Fill(this.cuaHangSachDataSet.Quyen);
            loadQuyen();
            lockControl();
            show();
        }

        private void loadQuyen()
        {
            DataTable dt = qBus.getQuyen();
            lkQuyen.Properties.DataSource = dt;
            lkQuyen.Properties.DisplayMember = "TENQUYEN";
            lkQuyen.Properties.ValueMember = "MAQUYEN";
            lkQuyen.ItemIndex = dt.Rows.Count > 0 ? dt.Rows.Count - 1 : 1;
        }

        void init()
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            openControl();
            txtMatKhau.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            openControl();
            txtMatKhau.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                bus.Delete(int.Parse(txtMa.Text));
                show();
            }
            catch { }

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVien obj = new NhanVien();
            try
            {
                if (txtTen.Text != "")
                    obj.TENNV = txtTen.Text;
                if (cbGT.SelectedItem.ToString() != "")
                    obj.GT = cbGT.SelectedItem.ToString();
                if (deNgaySinh.EditValue.ToString() != "")
                    obj.NGAYSINH = Convert.ToDateTime(Convert.ToDateTime(deNgaySinh.EditValue.ToString()).ToString("yyyy/MM/dd"));
                if (txtDienThoai.Text != "")
                    obj.DIENTHOAI = txtDienThoai.Text;
                if (txtDiaChi.Text != "")
                    obj.DIACHI = txtDiaChi.Text;
                if (txtTaiKhoan.Text != "")
                    obj.TAIKHOAN = txtTaiKhoan.Text;
                if (txtMatKhau.Text != "")
                    obj.MATKHAU = txtMatKhau.Text;
                if (txtEmail.Text != "")
                    obj.EMAIL = txtEmail.Text;
                if (lkQuyen.EditValue.ToString() != "")
                    obj.MAQUYEN = int.Parse(lkQuyen.EditValue.ToString());


            }
            catch { }
            //obj.NGAYSINH = Convert.ToDateTime(DateTime.ParseExact(deNgaySinh.EditValue.ToString(), "dd/MM/yyyy", new CultureInfo("fr-FR")).ToString("yyyy/MM/dd"));

            if (isThem)
            {
                bus.Insert(obj);
                XtraMessageBox.Show("Thêm thành công!");
                show();
                lockControl();
            }
            else
            {
                obj.MANV = int.Parse(txtMa.Text);
                bus.Update(obj);
                XtraMessageBox.Show("Lưu thành công!");
                show();
                lockControl();
            }
            isThem = false;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            lockControl();
            try
            {
                txtMa.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtTen.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                cbGT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                deNgaySinh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
                txtDienThoai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
                txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                txtTaiKhoan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
                txtEmail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7]).ToString();
                lkQuyen.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8]).ToString();
            }
            catch { }
        }


    }
}