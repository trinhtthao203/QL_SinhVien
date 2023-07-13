using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_SinhVien
{
    public partial class frmLop_01 : Form
    {
        public frmLop_01()
        {
            InitializeComponent();
        }
        DataSet dsLop = new DataSet();
        SqlDataAdapter daLop = new SqlDataAdapter();
        BindingSource bsLop = new BindingSource();
        bool blnThem = false;
        private void frmLop_01_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From Lop";
            MyPublics.OpenData(strSelect, dsLop, "Lop", daLop);


            bsLop.DataSource = dsLop;
            bsLop.DataMember = "Lop";
            txtMSLop.MaxLength = 8;
            txtTenLop.MaxLength = 40;
            txtViTri.ReadOnly = true;
            txtViTri.BackColor = Color.White;
            GanDuLieu();
            DieuKhienKhiBinhThuong();

        }

        void GanDuLieu()
        {
            txtMSLop.DataBindings.Add(new Binding("Text", bsLop, "MSLop"));
            txtTenLop.DataBindings.Add(new Binding("Text", bsLop, "TenLop"));
            txtKhoaHoc.DataBindings.Add(new Binding("Text", bsLop, "KhoaHoc"));
        }

        void DieuKhienKhiBinhThuong()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtMSLop.BackColor = Color.White;
            txtMSLop.ReadOnly = true;
            txtTenLop.BackColor = Color.White;
            txtTenLop.ReadOnly = true;
            txtKhoaHoc.BackColor = Color.White;
            txtKhoaHoc.ReadOnly = true;

            DieuKhienTheoViTri();
        }

        void DieuKhienTheoViTri()
        {
            txtViTri.Text = (bsLop.Position + 1) + "/" + bsLop.Count;
            btnSua.Enabled = true;
            if (bsLop.Position > 0)
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }
            else
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            if (bsLop.Position < bsLop.Count-1)
            {
                btnKe.Enabled = true;
                btnCuoi.Enabled = true;
            }
            else
            {
                btnKe.Enabled = false;
                btnCuoi.Enabled = false;
            }

        }


    }
}
