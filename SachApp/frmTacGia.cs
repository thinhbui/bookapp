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
    public partial class frmTacGia : DevExpress.XtraEditors.XtraForm
    {
        public frmTacGia()
        {
            InitializeComponent();
        }
        TacGiaBus tacgiaBus = new TacGiaBus();
        TacGia tacgia = new TacGia();
        bool IsInsert = false;

        public void HienThi()
        {
            gridControlTacGia.DataSource =tacgiaBus.GetTacGia();
        }
        void KhoaDieuKhien()
        {
            txtTenTG.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            txtGioiThieu.Enabled = false;
            txtEmail.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }
        void MoKhoaDieuKhien()
        {
            txtTenTG.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtGioiThieu.Enabled = true;
            txtEmail.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        private void frmTacGia_Load(object sender, EventArgs e)
        {
            HienThi();
            KhoaDieuKhien();
        }
        void XoaText()
        {
            txtTenTG.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtGioiThieu.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaText();
            MoKhoaDieuKhien();
            IsInsert = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MoKhoaDieuKhien();
            IsInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông Báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    tacgiaBus.Delete(int.Parse(dgvTacGia.GetRowCellValue(dgvTacGia.FocusedRowHandle, dgvTacGia.Columns[0]).ToString()));
                    XtraMessageBox.Show("Đã xóa thành công");
                    XoaText();
                    KhoaDieuKhien();
                    HienThi();
                }
                catch
                {
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            tacgia.TENTG = txtTenTG.Text;
            tacgia.DIACHI = txtDiaChi.Text;
            tacgia.DIENTHOAI = txtDienThoai.Text;
            tacgia.GIOITHIEU = txtGioiThieu.Text;
            tacgia.EMAIL = txtEmail.Text;
            if (IsInsert == true)
            {
                //insert
                tacgiaBus.Insert(tacgia);
                XtraMessageBox.Show("Thêm thành công!");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }
            else
            {
                //update
                tacgia.MATG = int.Parse(dgvTacGia.GetRowCellValue(dgvTacGia.FocusedRowHandle, dgvTacGia.Columns[0]).ToString());
                tacgiaBus.Update(tacgia);
                XtraMessageBox.Show("Sửa thành công!");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }
        }

        private void dgvTacGia_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                txtTenTG.Text = dgvTacGia.GetRowCellValue(dgvTacGia.FocusedRowHandle, dgvTacGia.Columns["TENTG"]).ToString();
                txtDiaChi.Text = dgvTacGia.GetRowCellValue(dgvTacGia.FocusedRowHandle, dgvTacGia.Columns["DIACHI"]).ToString();
                txtDienThoai.Text = dgvTacGia.GetRowCellValue(dgvTacGia.FocusedRowHandle, dgvTacGia.Columns["DIENTHOAI"]).ToString();
                txtEmail.Text = dgvTacGia.GetRowCellValue(dgvTacGia.FocusedRowHandle, dgvTacGia.Columns["EMAIL"]).ToString();
                txtGioiThieu.Text = dgvTacGia.GetRowCellValue(dgvTacGia.FocusedRowHandle, dgvTacGia.Columns["GIOITHIEU"]).ToString();
            }
            catch
            {

            }
        }
    }
}
