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

namespace SachApp
{
    public partial class frmListSach : DevExpress.XtraEditors.XtraForm
    {
        public frmListSach()
        {
            InitializeComponent();
        }

        SachDao sDao = new SachDao();

        private void LoadListSach()
        {
            DataTable dt = new DataTable();
            dt = sDao.GetData();
            gridControl1.DataSource = dt;
            dgvListSach.ExpandAllGroups(); 
        }


        private void frmListSach_Load(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            LoadListSach();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            frmAddSach frm = new frmAddSach();
            frm.IsInsert = true;
            frm.LamMoi += new EventHandler(btnHienThi_Click);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadListSach();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}