using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SachApp.Service.Models;
using SachApp.Service.BLL;

namespace SachApp
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
          //  nvObj = new NhanVienBus().GetUser("admin", "admin");
        }

        public NhanVien nvObj;





        Form CheckActiveForm(Type fType)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                    return f;
            }
            return null;
        }

        private void btnSach_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmListSach));
            if (frm != null)
                frm.Activate();
            else
            {
                frmListSach fr = new frmListSach();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnTheLoai_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmTheLoai));
            if (frm != null)
                frm.Activate();
            else
            {
                frmTheLoai fr = new frmTheLoai();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnNhapSach_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmNhapSach));
            if (frm != null)
                frm.Activate();
            else
            {
                frmNhapSach fr = new frmNhapSach();
                fr.nvObj = nvObj;
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnTacGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmTacGia));
            if (frm != null)
                frm.Activate();
            else
            {
                frmTacGia fr = new frmTacGia();
                //fr.nvObj = nvObj;
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnBanSach_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmBanSach));
            if (frm != null)
                frm.Activate();
            else
            {
                frmBanSach fr = new frmBanSach();
                fr.nvObj = nvObj;
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (nvObj.MAQUYEN == 2)
            {
                //btnBanSach.Enabled = false;
                //btnNhapSach.Enabled = false;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnNXB_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmNhaXuatBan));
            if (frm != null)
                frm.Activate();
            else
            {
                frmNhaXuatBan fr = new frmNhaXuatBan();
                //fr.nvObj = nvObj;
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmKhachHang));
            if (frm != null)
                frm.Activate();
            else
            {
                frmKhachHang fr = new frmKhachHang();
                //fr.nvObj = nvObj;
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmNhanVien));
            if (frm != null)
                frm.Activate();
            else
            {
                frmNhanVien fr = new frmNhanVien();
                //fr.nvObj = nvObj;
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmThongKeHoaDon));
            if (frm != null)
                frm.Activate();
            else
            {
                frmThongKeHoaDon fr = new frmThongKeHoaDon();
                //fr.nvObj = nvObj;
                fr.MdiParent = this;
                fr.Show();
            }
        }

    

        private void barChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.nv = nvObj;
            //frm.IsInsert = true;
            //frm.reloadData = new frmAddSach.loadSach(LoadListSach);
            ////frm.LamMoi += new EventHandler(btnHienThi_Click);
            //frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            Hide();
        }

        private void btnNPP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmNhaPhanPhoi));
            if (frm != null)
                frm.Activate();
            else
            {
                frmNhaPhanPhoi fr = new frmNhaPhanPhoi();
                //fr.nvObj = nvObj;
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmThongKePhieuNhap));
            if (frm != null)
                frm.Activate();
            else
            {
                frmThongKePhieuNhap fr = new frmThongKePhieuNhap();
                //fr.nvObj = nvObj;
                fr.MdiParent = this;
                fr.Show();
            }
        }
    }
}