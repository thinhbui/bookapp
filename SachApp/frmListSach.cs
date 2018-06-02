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
    public partial class frmListSach : DevExpress.XtraEditors.XtraForm
    {
        public frmListSach()
        {
            InitializeComponent();
        }

        SachDao sDao = new SachDao();
        Sach book = new Sach();

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
            frm.reloadData = new frmAddSach.loadSach(LoadListSach);
            //frm.LamMoi += new EventHandler(btnHienThi_Click);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadListSach();
        }
        private void lockControl()
        {
            btnXoa.Enabled = false;
        }
        private void openControl()
        {
            btnXoa.Enabled = true;
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            openControl();
            try
            {
                book.MASACH = int.Parse(dgvListSach.GetRowCellValue(dgvListSach.FocusedRowHandle, dgvListSach.Columns[0]).ToString());
            }
            catch { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                sDao.Delete(book.MASACH);
                LoadListSach();
            }
            catch { }
        }
    }
}