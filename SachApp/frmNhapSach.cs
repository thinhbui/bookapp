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
using DevExpress.XtraReports.UI;

namespace SachApp
{
    public partial class frmNhapSach : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapSach()
        {
            InitializeComponent();
        }
        SachBus sachBus = new SachBus();
        NhaPhanPhoiBus nppBus = new NhaPhanPhoiBus();
        PhieuNhapBus pnBus = new PhieuNhapBus();
        ChiTietPhieuNhapBus ctpnBus = new ChiTietPhieuNhapBus();
        DataTable dtNPP = new DataTable();
        DataTable dtCTPN = new DataTable();
        PhieuNhap pnObj = new PhieuNhap();
        ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
        public NhanVien nvObj = new NhanVien();
        Sach sach = new Sach();
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
            btnThemMoi.Enabled = true;
            btnTinhTien.Enabled = false;
            lkBook.Enabled = false;
            btnHuy.Enabled = false;
            spinQuanity.Enabled = false;
            btnNhap.Enabled = false;
            btnAddSach.Enabled = false;
        }

        void MoKhoaDieuKhien()
        {
            txtTenNv.Enabled = false;
            dEditNgayLap.Enabled = false;
            luNPP.Enabled = true;
            txtTenSach.Enabled = false;
            txtTongTien.Enabled = false;
            btnAddNPP.Enabled = true;         
            btnThemMoi.Enabled = false;
            btnTinhTien.Enabled = true;
            lkBook.Enabled = true;
            spinQuanity.Enabled = true;
            btnNhap.Enabled = true;
            btnHuy.Enabled = true;
            btnAddSach.Enabled = true;
        }

        void XoaText()
        {
            txtTS.Text = "_____";
            txtTT.Text = "_____";
            dEditNgayLap.Text = string.Empty;

        }

        private void frmNhapSach_Load(object sender, EventArgs e)
        {
            DataTable dt = nppBus.GetNPP();
            DataTable dtSach = sachBus.GetData();
            loadSach(dtSach);
            LoadNhaPhanPhoi(dt);
            txtTenNv.Text = nvObj.TENNV;
            KhoaDieuKhien();
        }
        private void LoadNhaPhanPhoi(DataTable dt)
        {
            luNPP.Properties.DataSource = dt;
            luNPP.Properties.ValueMember = "MANPP";
            luNPP.Properties.DisplayMember = "TENNPP";
            luNPP.ItemIndex = dt.Rows.Count > 0 ? dt.Rows.Count - 1 : 0;
        }
        private void loadSach(DataTable dt)
        {
            lkBook.Properties.DataSource = dt;
            lkBook.Properties.ValueMember = "MASACH";
            lkBook.Properties.DisplayMember = "TENSACH";
            lkBook.ItemIndex = dt.Rows.Count > 0 ? dt.Rows.Count - 1 : 1;
        }
        private void LoadChiTietPhieuNhap(string tenSach)
        {
            dtCTPN = ctpnBus.GetData(pnObj.MAPN);
            gridChiTietPhieuNhap.DataSource = dtCTPN;
            gridChiTietPhieuNhap.ForceInitialize();
            if(tenSach!= null) txtTS.Text = tenSach;
            try
            {
                txtTT.Text = dgvPhieuNhap.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString();
            }
            catch { }

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
                    catch { }
                }

            }
            if ((e.RowHandle >= 0) && (e.Column.FieldName.Equals("Unbound")))
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
            try { pnBus.UpdateNPP(pnObj); }
            catch { }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //XtraMessageBox.Show(luNPP.EditValue.ToString());
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MoKhoaDieuKhien();

            //dtNPP = nppBus.GetNPP();
            //    LoadNhaPhanPhoi(dtNPP);
          //  try
//{
                //luNPP.ItemIndex = -1;

                dEditNgayLap.Text = DateTime.Now.ToString();
                pnObj.MAPN = DateTime.Now.ToString("yyyyMMddhhmmss");
                pnObj.NGAYLAP = DateTime.Parse(dEditNgayLap.Text.ToString());
                pnObj.MANV = nvObj.MANV;
                pnObj.MANPP = int.Parse(luNPP.EditValue.ToString());
                pnObj.TONGTIEN = 0;
                pnBus.Insert(pnObj);
                pnObj = pnBus.GetNewPhieuNhap();
          //  }
            //catch { }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            try
            {
                pnObj.TONGTIEN = int.Parse(txtTT.Text);
                pnBus.Update(pnObj);
                gridChiTietPhieuNhap.DataSource = null;
                dgvPhieuNhap.Columns.Clear();
                reportPhieuNhap rp = new reportPhieuNhap(pnObj.MAPN);
                rp.ShowPreview();
            }
            catch { }
            XoaText();
            KhoaDieuKhien();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            ctpn.MAPN = pnObj.MAPN;
            ctpn.MASACH = int.Parse(lkBook.EditValue.ToString());
            ctpn.SOLUONG = int.Parse(spinQuanity.Text.ToString());
            ctpn.DONGIA = sach.GIABAN;
            ctpn.THANHTIEN = ctpn.SOLUONG * ctpn.DONGIA;
            ctpnBus.Insert(ctpn);
            LoadChiTietPhieuNhap(null);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try {
                pnBus.Delete(pnObj.MAPN);
                dgvPhieuNhap.Columns.Clear();
                KhoaDieuKhien();
            } catch { }
        }

        private void lkBook_EditValueChanged(object sender, EventArgs e)
        {
            sach = sachBus.GetSachByID(int.Parse(lkBook.EditValue.ToString()));
        }

        private void gridChiTietPhieuNhap_Click(object sender, EventArgs e)
        {

        }
    }
}