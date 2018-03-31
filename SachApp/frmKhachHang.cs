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

namespace SachApp
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        KhachHangDao dao = new KhachHangDao();
        int id;
        bool isThem = false;
        public frmKhachHang()
        {
            InitializeComponent();   
        }
        void lockControl()
        {
            txtName.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }
        void openControl()
        {
            txtName.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        void showKH()
        {
            bangKH.DataSource = dao.GetData();
        }

        void showHD(int makh)
        {
            bangHD.DataSource = dao.SelectHoaDon(makh);
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            lockControl();
            showKH();
        }


        private void bangKH_Click(object sender, EventArgs e)
        {
            int id = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString());
            txtName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            txtPhone.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            txtAddress.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            showHD(id);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;
            openControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            openControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông Báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dao.Delete(int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString()));
                    XtraMessageBox.Show("Đã xóa thành công");
                    clearText();
                    lockControl();
                    showKH();
                }
                catch
                {
                }
            }
            
        }

        private void clearText()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhachHang obj = new KhachHang();
          
            obj.TENKH = txtName.Text;
            obj.DIACHI = txtAddress.Text;
            obj.DIENTHOAI = txtPhone.Text;
            if (isThem)
            {
                dao.Insert(obj);
                XtraMessageBox.Show("Thêm thành công!");
                showKH();
                clearText();
                lockControl();
            }
            else
            {
                obj.MAKH = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString());
                dao.Update(obj);
            
                XtraMessageBox.Show("Sửa thành công!");
                showKH();
                clearText();
                lockControl();
            }
            isThem = false;
        }

        private void bangHD_DoubleClick(object sender, EventArgs e)
        {
            string id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[0]).ToString();
            frmChiTietHoaDon frm = new frmChiTietHoaDon(id);
            frm.Show();
        }

        private void bangHD_Click(object sender, EventArgs e)
        {

        }
    }
}