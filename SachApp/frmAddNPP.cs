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

namespace SachApp
{
    public partial class frmAddNPP : DevExpress.XtraEditors.XtraForm
    {
        public frmAddNPP()
        {
            InitializeComponent();
        }

        NhaPhanPhoiBus nppBus = new NhaPhanPhoiBus();

        public delegate void getDataSoucre(DataTable dt);

        public getDataSoucre getData;


        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhaPhanPhoi obj = new NhaPhanPhoi();
            obj.TENNPP = txtTenNPP.Text;
            obj.DIACHI = txtDiaChi.Text;
            obj.DIENTHOAI = txtSoDT.Text;
            obj.FAX = txtSoFax.Text;
            obj.EMAIL = txtEmail.Text;

            nppBus.Insert(obj);

            DataTable dt = nppBus.GetNPP();
            getData(dt);

            XtraMessageBox.Show("Thêm thành công");
            this.Close();
        }

        private void frmAddNPP_Load(object sender, EventArgs e)
        {
            txtMaNPP.Enabled = false;
        }
    }
}