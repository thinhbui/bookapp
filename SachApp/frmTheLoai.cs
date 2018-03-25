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
    public partial class frmTheLoai : DevExpress.XtraEditors.XtraForm
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }
        TheLoai theloai = new TheLoai();
        TheLoaiBus theloaiBus = new TheLoaiBus();
        bool IsInsert = false;

        void KhoaDieuKhien()
        {
            txtTenTheLoai.Enabled = false;
            txtMota.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }
        void MoKhoaDieuKhien()
        {

            txtTenTheLoai.Enabled = true;
            txtMota.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        void XoaText()
        {
            txtTenTheLoai.Text = string.Empty;
            txtMota.Text = string.Empty;
        }

        public void HienThi()
        {
            gridControlTheLoai.DataSource = theloaiBus.GetTheLoai();
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
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
                    theloaiBus.Delete(int.Parse(dgvTheLoai.GetRowCellValue(dgvTheLoai.FocusedRowHandle, dgvTheLoai.Columns[1]).ToString()));
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
            theloai.TENTHELOAI = txtTenTheLoai.Text;
            theloai.MOTA = txtMota.Text;
            if (IsInsert == true)
            {
                //insert
                theloaiBus.Insert(theloai);
                XtraMessageBox.Show("Thêm thành công!");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }
            else
            {
                //update
                theloai.MATHELOAI = int.Parse(dgvTheLoai.GetRowCellValue(dgvTheLoai.FocusedRowHandle, dgvTheLoai.Columns[0]).ToString());
                theloaiBus.Update(theloai);
                XtraMessageBox.Show("Sửa thành công!");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }
        }

        private void dgvTheLoai_Click(object sender, EventArgs e)
        {
            txtTenTheLoai.Text = dgvTheLoai.GetRowCellValue(dgvTheLoai.FocusedRowHandle, dgvTheLoai.Columns["TENTHELOAI"]).ToString();
            txtMota.Text = dgvTheLoai.GetRowCellValue(dgvTheLoai.FocusedRowHandle, dgvTheLoai.Columns["MOTA"]).ToString();
        }
    }
}