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
    public partial class frmLop_02 : Form
    {
        DataSet dsLop = new DataSet();
        SqlDataAdapter daLop = new SqlDataAdapter();
        BindingSource bsLop = new BindingSource();
        bool blnThem = false;

        public frmLop_02()
        {
            InitializeComponent();
        }

        private void frmLop_02_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From Lop";
            MyPublics.OpenData(strSelect, dsLop, "Lop", daLop);


            bsLop.DataSource = dsLop;
            bsLop.DataMember = "Lop";
            txtMSLop.MaxLength = 8;
            txtTenLop.MaxLength = 40;
            GanDuLieu();
            dgvLop.DataSource = dsLop;
            dgvLop.DataMember = "Lop";
            dgvLop.Width = 440;
            dgvLop.Columns[0].Width = 95;
            dgvLop.Columns[1].Width = 190;
            dgvLop.Columns[2].Width = 95;

            dgvLop.Columns[0].HeaderText = "Mã số";
            dgvLop.Columns[1].HeaderText = "Tên lớp";
            dgvLop.Columns[2].HeaderText = "Khóa học";

            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.EditMode = DataGridViewEditMode.EditProgrammatically;
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
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bsLop.Position = dgvLop.CurrentRow.Index;
        }

        void DieuKhienKhiThem()
        {
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

        void DieuKhienKhiSua()
        {
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            bsLop.AddNew();
            bsLop.Position = bsLop.Count;
            dgvLop.CurrentCell = dgvLop[0, bsLop.Count - 1];
            DieuKhienKhiThem();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiSua();
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

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            bsLop.EndEdit();
            dsLop.RejectChanges();
            blnThem = false;
            DieuKhienKhiBinhThuong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {         
            if (MyPublics.TonTaiKhoaChinh(txtMSLop.Text, "MSLop", "SinhVien"))
                MessageBox.Show("Phải xóa sinh viên thuộc lớp trước");
            else
            {
                DialogResult btnDongY;
                btnDongY = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (btnDongY == DialogResult.Yes)
                {
                    bsLop.RemoveCurrent();
                    daLop.Update(dsLop, "Lop");
                    dsLop.AcceptChanges();
                }
            }
            DieuKhienKhiBinhThuong();
        }
    }
}
