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
    public partial class frmNhaPhanPhoi : DevExpress.XtraEditors.XtraForm
    {
        public frmNhaPhanPhoi()
        {
            InitializeComponent();
        }
        NhaPhanPhoi npp = new NhaPhanPhoi();
        NhaPhanPhoiBus nppBus = new NhaPhanPhoiBus();
        bool IsInsert = false;
        void KhoaDieuKhien()
        {

            txtTenNPP.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            txtEmail.Enabled = false;
            txtFax.Enabled = false;

            btnLamMoi.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }
        void MoKhoaDieuKhien()
        {
            txtTenNPP.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtEmail.Enabled = true;
            txtFax.Enabled = true;
             
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        void XoaText()
        {
            txtTenNPP.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFax.Text = string.Empty;
        }
        void HienThi()
        {
            gridControlNPP.DataSource = nppBus.GetNPP();
        }


       
        private void frmNhaXuatBan_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
        }

        private void gridControlNPP_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                
                txtTenNPP.Text = dgvNhaPhanPhoi.GetRowCellValue(dgvNhaPhanPhoi.FocusedRowHandle, dgvNhaPhanPhoi.Columns["TENNPP"]).ToString();
                txtDiaChi.Text = dgvNhaPhanPhoi.GetRowCellValue(dgvNhaPhanPhoi.FocusedRowHandle, dgvNhaPhanPhoi.Columns["DIACHI"]).ToString();
                txtDienThoai.Text = dgvNhaPhanPhoi.GetRowCellValue(dgvNhaPhanPhoi.FocusedRowHandle, dgvNhaPhanPhoi.Columns["DIENTHOAI"]).ToString();
                txtEmail.Text = dgvNhaPhanPhoi.GetRowCellValue(dgvNhaPhanPhoi.FocusedRowHandle, dgvNhaPhanPhoi.Columns["EMAIL"]).ToString();
                txtFax.Text= dgvNhaPhanPhoi.GetRowCellValue(dgvNhaPhanPhoi.FocusedRowHandle, dgvNhaPhanPhoi.Columns["FAX"]).ToString();
            }
            catch
            {

            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            MoKhoaDieuKhien();
            IsInsert = true;
        }

        private void frmNhaPhanPhoi_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
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
                    nppBus.Delete(int.Parse(dgvNhaPhanPhoi.GetRowCellValue(dgvNhaPhanPhoi.FocusedRowHandle, dgvNhaPhanPhoi.Columns[0]).ToString()));
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
            if (!IsInsert) {
                try
                {
                    npp.MANPP = int.Parse(dgvNhaPhanPhoi.GetRowCellValue(dgvNhaPhanPhoi.FocusedRowHandle, dgvNhaPhanPhoi.Columns[0]).ToString());
                    npp.TENNPP = txtTenNPP.Text;
                    npp.DIACHI = txtDiaChi.Text;
                    npp.DIENTHOAI = txtDienThoai.Text;
                    npp.EMAIL = txtEmail.Text;
                    npp.FAX = txtFax.Text;
                    nppBus.Update(npp);
                    XtraMessageBox.Show("Sửa thành công!");
                    HienThi();
                    XoaText();
                    KhoaDieuKhien();
                }
                catch { }
            } else
            {
                try
                {
                   // npp.MANPP = int.Parse(dgvNhaPhanPhoi.GetRowCellValue(dgvNhaPhanPhoi.FocusedRowHandle, dgvNhaPhanPhoi.Columns[0]).ToString());
                    npp.TENNPP = txtTenNPP.Text;
                    npp.DIACHI = txtDiaChi.Text;
                    npp.DIENTHOAI = txtDienThoai.Text;
                    npp.EMAIL = txtEmail.Text;
                    npp.FAX = txtFax.Text;
                    nppBus.Insert(npp);
                    XtraMessageBox.Show("Thêm thành công!");
                    HienThi();
                    XoaText();
                    KhoaDieuKhien();
                }
                catch { }
            }
          
            

            //update
            

        }
    }

}
