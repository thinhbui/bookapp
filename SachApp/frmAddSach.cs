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
using SachApp.Service.Dao;
using SachApp.Service.BLL;

namespace SachApp
{
    public partial class frmAddSach : DevExpress.XtraEditors.XtraForm
    {
        public frmAddSach()
        {
            InitializeComponent();
        }

        public bool IsInsert = false;
        public EventHandler LamMoi;
        Sach obj = new Sach();
        SachBus sachBus = new SachBus();
        TheLoaiBus tlBus = new TheLoaiBus();
        NhaXuatBanBus nxbBus = new NhaXuatBanBus();
        TacGiaBus tgBus = new TacGiaBus();
    //    ChiTietPhieuNhapBus ctpnBus = new ChiTietPhieuNhapBus();


        public string maPN;
        public int maSach;

        public delegate void loadDataChiTiet(string tenSach);

        public loadDataChiTiet getData;



        private void frmAddSach_Load(object sender, EventArgs e)
        {
            txtMasach.Enabled = false;

            luTacGia.Properties.DataSource = tgBus.GetTacGia();
            luTacGia.Properties.ValueMember = "MATG";
            luTacGia.Properties.DisplayMember = "TENTG";

            luNXB.Properties.DataSource = nxbBus.GetNXB();
            luNXB.Properties.ValueMember = "MANXB";
            luNXB.Properties.DisplayMember = "TENNXB";

            luTheLoai.Properties.DataSource = tlBus.GetTheLoai();
            luTheLoai.Properties.ValueMember = "MATHELOAI";
            luTheLoai.Properties.DisplayMember = "TENTHELOAI";

            //update nếu là sửa
            if (IsInsert == false)
            {
                DataTable dt = new DataTable();
                dt = sachBus.GetDataByID(maSach);
                txtMasach.Text = dt.Rows[0]["MASACH"].ToString();
                txtTenSach.Text = dt.Rows[0]["TENSACH"].ToString();
                txtBarcode.Text = dt.Rows[0]["BARCODE"].ToString();
                luTacGia.EditValue = int.Parse(dt.Rows[0]["MATG"].ToString());
                luNXB.EditValue = int.Parse(dt.Rows[0]["MANXB"].ToString());
                luTheLoai.EditValue = int.Parse(dt.Rows[0]["MATHELOAI"].ToString());
                txtNamXuatBan.Text = dt.Rows[0]["NAMXUATBAN"].ToString();
                txtGiaMua.Text = dt.Rows[0]["GIAMUA"].ToString();
                txtGiaBan.Text = dt.Rows[0]["GIABAN"].ToString();
                spSoLuong.Text = dt.Rows[0]["SOLUONGKHO"].ToString();
                txtMota.Text = dt.Rows[0]["MOTA"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            obj.TENSACH = txtTenSach.Text;
            obj.BARCODE = txtBarcode.Text;
            obj.MATG = int.Parse(luTacGia.EditValue.ToString());
            obj.MANXB = int.Parse(luNXB.EditValue.ToString());
            obj.MATHELOAI = int.Parse(luTheLoai.EditValue.ToString());
            obj.NAMXUATBAN = int.Parse(txtNamXuatBan.Text);
            obj.GIAMUA = decimal.Parse(txtGiaMua.Text);
            obj.GIABAN = decimal.Parse(txtGiaBan.Text);
            obj.SOLUONGKHO = int.Parse(spSoLuong.Text);
            obj.MOTA = txtMota.Text;
            obj.CREATEDATE = DateTime.Now;

            if (IsInsert == true)
            {
                sachBus.Insert(obj);
                //get MaSach
                obj = sachBus.GetNew();
                //add chitietPhieuNhap
                //ChiTietPhieuNhap ctpnObj = new ChiTietPhieuNhap();
                //ctpnObj.MAPN = maPN;
                //ctpnObj.MASACH = obj.MASACH;
                //ctpnObj.SOLUONG = obj.SOLUONGKHO;
                //ctpnObj.DONGIA = obj.GIAMUA;
                //ctpnObj.THANHTIEN = obj.GIAMUA * obj.SOLUONGKHO;
                //ctpnBus.Insert(ctpnObj);

                //Get Data
                getData(obj.TENSACH);

                XtraMessageBox.Show("Thêm thành công");
                this.Close();
            }
            //sUA
            else
            {
                obj.MASACH = int.Parse(txtMasach.Text);
                sachBus.Update(obj);
                ChiTietPhieuNhap ctpnObj = new ChiTietPhieuNhap();
                ctpnObj.MAPN = maPN;
                ctpnObj.MASACH = obj.MASACH;
                ctpnObj.SOLUONG = obj.SOLUONGKHO;
                ctpnObj.DONGIA = obj.GIAMUA;
                ctpnObj.THANHTIEN = obj.GIAMUA * obj.SOLUONGKHO;
                //ctpnBus.Update(ctpnObj);

                getData(obj.TENSACH);

                XtraMessageBox.Show("Sửa thành công");
                this.Close();
            }

        }
    }
}