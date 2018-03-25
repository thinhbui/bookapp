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
    public partial class frmNhaXuatBan : DevExpress.XtraEditors.XtraForm
    {
        public frmNhaXuatBan()
        {
            InitializeComponent();
        }
    
    NhaXuatBan nxb = new NhaXuatBan();
    NhaXuatBanBus nxbBus = new NhaXuatBanBus();
    bool IsInsert = false;
    void KhoaDieuKhien()
    {

        txtTenNXB.Enabled = false;
        txtDiaChi.Enabled = false;
        txtDienThoai.Enabled = false;
        txtEmail.Enabled = false;

        btnThem.Enabled = true;
        btnSua.Enabled = true;
        btnXoa.Enabled = true;
        btnLuu.Enabled = false;
    }
    void MoKhoaDieuKhien()
    {
        txtTenNXB.Enabled = true;
        txtDiaChi.Enabled = true;
        txtDienThoai.Enabled = true;
        txtEmail.Enabled = true;
        

        btnThem.Enabled = false;
        btnSua.Enabled = false;
        btnXoa.Enabled = false;
        btnLuu.Enabled = true;
    }
    void XoaText()
    {
        txtTenNXB.Text = string.Empty;
        txtDiaChi.Text = string.Empty;
        txtDienThoai.Text = string.Empty;
        txtEmail.Text = string.Empty;

    }
    void HienThi()
    {
        gridControlNXB.DataSource = nxbBus.GetNXB();
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
                nxbBus.Delete(int.Parse(dgvNXB.GetRowCellValue(dgvNXB.FocusedRowHandle, dgvNXB.Columns[0]).ToString()));
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
        nxb.TENNXB = txtTenNXB.Text;
        nxb.DIACHI = txtDiaChi.Text;
        nxb.DIENTHOAI = txtDienThoai.Text;
        nxb.EMAIL = txtEmail.Text;
        if (IsInsert == true)
        {
            //insert
            nxbBus.Insert(nxb);
            XtraMessageBox.Show("Thêm thành công!");
            HienThi();
            XoaText();
            KhoaDieuKhien();
        }
        else
        {
            //update
            nxb.MANXB = int.Parse(dgvNXB.GetRowCellValue(dgvNXB.FocusedRowHandle, dgvNXB.Columns[0]).ToString());
            nxbBus.Update(nxb);
            XtraMessageBox.Show("Sửa thành công!");
            HienThi();
            XoaText();
            KhoaDieuKhien();
        }
    }

    private void dgvNXB_Click(object sender, EventArgs e)
    {
        KhoaDieuKhien();
        try
        {

            txtTenNXB.Text = dgvNXB.GetRowCellValue(dgvNXB.FocusedRowHandle, dgvNXB.Columns[1]).ToString();
            txtDiaChi.Text = dgvNXB.GetRowCellValue(dgvNXB.FocusedRowHandle, dgvNXB.Columns[2]).ToString();
            txtDienThoai.Text = dgvNXB.GetRowCellValue(dgvNXB.FocusedRowHandle, dgvNXB.Columns[3]).ToString();
            txtEmail.Text = dgvNXB.GetRowCellValue(dgvNXB.FocusedRowHandle, dgvNXB.Columns[4]).ToString();

        }
        catch
        {

        }
    }

    private void frmNhaXuatBan_Load(object sender, EventArgs e)
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

    }

}