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
using SachApp.Service.BLL;
using DevExpress.XtraGrid.Columns;

namespace SachApp
{
    public partial class frmNhapSach : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapSach()
        {
            InitializeComponent();
        }

        NhaPhanPhoiBus nppBus = new NhaPhanPhoiBus();
        PhieuNhapBus pnBus = new PhieuNhapBus();
        ChiTietPhieuNhapBus ctpnBus = new ChiTietPhieuNhapBus();
        DataTable dtNPP = new DataTable();
        DataTable dtCTPN = new DataTable();
        PhieuNhap pnObj = new PhieuNhap();

        public NhanVien nvObj = new NhanVien();

       // List<ChiTietPhieuNhap> listChiTiet = new List<ChiTietPhieuNhap>();
        //  BindingList<>

        void KhoaDieuKhien()
        {
            txtTenNv.Enabled = false;
            dEditNgayLap.Enabled = false;
            luNPP.Enabled = false;
            txtTenSach.Enabled = false;
            txtTongTien.Enabled = false;
            btnAddNPP.Enabled = false;
            btnAddSach.Enabled = false;
            btnThemMoi.Enabled = true;
            btnTinhTien.Enabled = false;
            btnIn.Enabled = false;
        }

        void MoKhoaDieuKhien()
        {
            txtTenNv.Enabled = false;
            dEditNgayLap.Enabled = false;
            luNPP.Enabled = true;
            txtTenSach.Enabled = false;
            txtTongTien.Enabled = false;
            btnAddNPP.Enabled = true;
            btnAddSach.Enabled = true;
            btnThemMoi.Enabled = false;
            btnTinhTien.Enabled = true;
            btnIn.Enabled = true;
        }

        void XoaText()
        {
            txtTS.Text = "_____";
            txtTT.Text = "_____";
            dEditNgayLap.Text = string.Empty;

        }

        private void frmNhapSach_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cuaHangSachDataSet.NhaPhanPhoi' table. You can move, or remove it, as needed.
            this.nhaPhanPhoiTableAdapter.Fill(this.cuaHangSachDataSet.NhaPhanPhoi);
            txtTenNv.Text = nvObj.TENNV;
            KhoaDieuKhien();
            //dEditNgayLap.Text = DateTime.Now.ToString();
            
        }

        private void LoadNhaPhanPhoi(DataTable dt)
        {
            luNPP.Properties.DataSource = dt;
            luNPP.Properties.ValueMember = "MANPP";
            luNPP.Properties.DisplayMember = "TENNPP";
            luNPP.ItemIndex = dt.Rows.Count - 1;
        }

        private void LoadChiTietPhieuNhap(string tenSach)
        {
            dtCTPN = ctpnBus.GetData(pnObj.MAPN);
            gridChiTietPhieuNhap.DataSource = dtCTPN;
            gridChiTietPhieuNhap.ForceInitialize();
            txtTS.Text = tenSach;
            txtTT.Text= dgvPhieuNhap.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString();

            GridColumn clumnSua = dgvPhieuNhap.Columns["Unbound"];
            if (clumnSua == null)
            {
                GridColumn col = dgvPhieuNhap.Columns.AddVisible("Unbound", "Sửa");
                col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                col.AppearanceCell.ForeColor = Color.Blue;
                col.AppearanceCell.Font = new Font("Tahoma", 9, FontStyle.Bold);
                col.Width = 50;
            }


            GridColumn clumnXoa = dgvPhieuNhap.Columns["UnboundXoa"];
            if (clumnXoa == null)
            {
                GridColumn col = dgvPhieuNhap.Columns.AddVisible("UnboundXoa", "Xóa sách");
                col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                col.AppearanceCell.ForeColor = Color.Red;
                col.AppearanceCell.Font = new Font("Tahoma", 9, FontStyle.Bold);
                col.Width = 50;
            }
           


        }

        private void dgvPhieuNhap_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName.Equals("UnboundXoa"))
            {
                e.DisplayText = "Xóa";
            }
            if (e.Column.FieldName.Equals("Unbound"))
            {
                e.DisplayText = "Sửa";
            }
        }

        private void dgvPhieuNhap_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if ((e.RowHandle >= 0) && (e.Column.FieldName.Equals("UnboundXoa")))
            {
                int maSach = int.Parse(dgvPhieuNhap.GetRowCellValue(e.RowHandle, dgvPhieuNhap.Columns["MASACH"]).ToString());
                if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        ctpnBus.Delete(pnObj.MAPN, maSach);
                        XtraMessageBox.Show("Đã xóa thành công");
                        LoadChiTietPhieuNhap("______");
                    }
                    catch
                    {
                    }

                }

            }
            if((e.RowHandle>=0)&&(e.Column.FieldName.Equals("Unbound")))
            {
                int maSach = int.Parse(dgvPhieuNhap.GetRowCellValue(e.RowHandle, dgvPhieuNhap.Columns["MASACH"]).ToString());
                frmAddSach frm = new frmAddSach();
                frm.maSach = maSach;
                frm.maPN = pnObj.MAPN;
                frm.IsInsert = false;
                frm.getData = new frmAddSach.loadDataChiTiet(LoadChiTietPhieuNhap);
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
        }






        private void btnAddSach_Click(object sender, EventArgs e)
        {
            frmAddSach frm = new frmAddSach();
            frm.IsInsert = true;
            frm.maPN = pnObj.MAPN;
            frm.getData = new frmAddSach.loadDataChiTiet(LoadChiTietPhieuNhap);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnAddNPP_Click(object sender, EventArgs e)
        {
            frmAddNPP frm = new frmAddNPP();
            frm.ShowInTaskbar = false;
            frm.getData = new frmAddNPP.getDataSoucre(LoadNhaPhanPhoi);
            frm.ShowDialog();
        }

        private void luNPP_EditValueChanged(object sender, EventArgs e)
        {
            pnObj.MANPP = int.Parse(luNPP.EditValue.ToString());
            pnBus.UpdateNPP(pnObj);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //XtraMessageBox.Show(luNPP.EditValue.ToString());
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MoKhoaDieuKhien();

            dtNPP = nppBus.GetNPP();
            LoadNhaPhanPhoi(dtNPP);
            luNPP.ItemIndex = -1;

            dEditNgayLap.Text = DateTime.Now.ToString();

            pnObj.NGAYLAP = DateTime.Parse(dEditNgayLap.Text.ToString());
            pnObj.MANV = nvObj.MANV;//Chua co nhan vien
            pnObj.MANPP = int.Parse(luNPP.EditValue.ToString());
            pnObj.TONGTIEN = 0;
            pnBus.Insert(pnObj);
            pnObj = pnBus.GetNewPhieuNhap();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            pnObj.TONGTIEN = int.Parse(txtTT.Text);
            pnBus.Update(pnObj);
            XoaText();
            gridChiTietPhieuNhap.DataSource = null;
            dgvPhieuNhap.Columns.Clear();
            KhoaDieuKhien();
        }

       
    }
}