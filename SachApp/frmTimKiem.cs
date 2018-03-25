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
    public partial class frmTimKiem : DevExpress.XtraEditors.XtraForm
    {
        public frmTimKiem()
        {
            InitializeComponent();
        }
        
        ThongTinTimKiemBus timkiemBus = new ThongTinTimKiemBus();
        public void HienThi()
        {
            ThongTinTimKiem timkiem = new ThongTinTimKiem();
            if (ckbSach.Checked)
            {
                timkiem.TENSACH = txtSach.Text;
            }
            if (ckbTacGia.Checked)
            {
                timkiem.TENTG = txtTacGia.Text;
            }
            if (ckbNXB.Checked)
            {
                timkiem.MANXB = Convert.ToInt32(cbNXB.EditValue);
            }
            if (ckbTheLoai.Checked)
            {
                timkiem.MATHELOAI = Convert.ToInt32(cbTheLoai.EditValue);
            }
            
            if (ckbNamXB.Checked)
            {
                cbNamXB.Properties.NullText = "2016";
                timkiem.NAMXB = Int32.Parse(cbNamXB.Text);
            }
            if (ckbGia.Checked)
            {
                timkiem.giaMAX = Decimal.Parse(txtGiaMax.Text);
                timkiem.giaMIN = Decimal.Parse(txtGiaMin.Text);
            }
            gridControlTimKiem.DataSource = timkiemBus.GetData(timkiem);


        }

        private void frmTimKiem_Load(object sender, EventArgs e)
        {

            HienThi();
            NhaXuatBanBus nxbBus = new NhaXuatBanBus();
            cbNXB.Properties.DataSource = nxbBus.GetNXB();
            cbNXB.Properties.DisplayMember = "TENNXB";
            cbNXB.Properties.ValueMember = "MANXB";

            TheLoaiBus theloaiBus = new TheLoaiBus();
            cbTheLoai.Properties.DataSource = theloaiBus.GetTheLoai();
            cbTheLoai.Properties.DisplayMember = "TENTHELOAI";
            cbTheLoai.Properties.ValueMember = "MATHELOAI";

            SachBus sachBus = new SachBus();
            cbNamXB.Properties.DataSource = sachBus.GetData();
            cbNamXB.Properties.DisplayMember = "NAMXUATBAN";
            cbNamXB.Properties.ValueMember = "MASACH";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
