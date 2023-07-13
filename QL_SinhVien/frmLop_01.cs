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

        void DieuKhienKhiThem()
        {
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            txtMSLop.ReadOnly = false;
            txtTenLop.ReadOnly = false;
            txtKhoaHoc.ReadOnly = false;
            txtMSLop.Clear();
            txtTenLop.Clear();
            txtKhoaHoc.Clear();
            txtMSLop.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            bsLop.AddNew();
            DieuKhienKhiThem();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bsLop.MoveFirst();
            DieuKhienTheoViTri();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bsLop.MovePrevious();
            DieuKhienTheoViTri();
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            bsLop.MoveNext();
            DieuKhienTheoViTri();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bsLop.MoveLast();
            DieuKhienTheoViTri();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MyPublics.TonTaiKhoaChinh(txtMSLop.Text, "MSLop", "SinhVien"))
                MessageBox.Show("Phải xóa sinh viên thuộc lớp trước");
            else
            {
                DialogResult btnDongY;
                btnDongY = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác  nhận", MessageBoxButtons.YesNo);
                if (btnDongY == DialogResult.Yes)
                {
                    bsLop.RemoveCurrent();
                    daLop.Update(dsLop, "Lop");
                    dsLop.AcceptChanges();
                }
            }
            DieuKhienKhiBinhThuong();
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            bsLop.EndEdit();
            dsLop.RejectChanges();
            blnThem = false;
            DieuKhienKhiBinhThuong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int khoa;
            if ((txtMSLop.Text == "") || (txtTenLop.Text == "") || (!int.TryParse(txtKhoaHoc.Text, out khoa)) || (khoa <= 0))
                MessageBox.Show("Lỗi nhập dữ liệu");
            else
                if ((blnThem) && (MyPublics.TonTaiKhoaChinh(txtMSLop.Text, "MSLop", "Lop")))
            {
                MessageBox.Show("Mã số lớp tồn tại !!!");
                txtMSLop.Focus();
            }
            else
            {
                bsLop.EndEdit();
                daLop.Update(dsLop, "Lop");
                dsLop.AcceptChanges();
                blnThem = false;
                DieuKhienKhiBinhThuong();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            txtTenLop.ReadOnly = false;
            txtKhoaHoc.ReadOnly = false;
            txtTenLop.Focus();
        }
    }
}
