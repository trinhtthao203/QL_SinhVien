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
    public partial class frmLop_03 : Form
    {
        public frmLop_03()
        {
            InitializeComponent();
        }

        DataSet dsLop = new DataSet();
        bool blnThem = false;

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

        void GanDuLieu()
        {
            if (dsLop.Tables["Lop"].Rows.Count > 0)
            {
                txtMSLop.Text = dgvLop[0, dgvLop.CurrentRow.Index].Value.ToString();
                txtTenLop.Text = dgvLop[1, dgvLop.CurrentRow.Index].Value.ToString();
                txtKhoaHoc.Text = dgvLop[2, dgvLop.CurrentRow.Index].Value.ToString();
            }
            else
            {
                txtMSLop.Clear();
                txtTenLop.Clear();
                txtKhoaHoc.Clear();
            }
        }

        private void frmLop_03_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * from Lop";
            MyPublics.OpenData(strSelect, dsLop, "Lop");
            dgvLop.DataSource = dsLop;
            dgvLop.DataMember = "Lop";

            txtMSLop.MaxLength = 8;
            txtTenLop.MaxLength = 40;
            GanDuLieu();
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
            GanDuLieu();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            DieuKhienKhiThem();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiSua();
        }

        void LuuLopMoi()
        {
            string strSql = "Insert Into Lop Values(@MSLop, @TenLop, @KhoaHoc)";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdComman = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdComman.Parameters.AddWithValue("@MSLop", txtMSLop.Text);
            cmdComman.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
            cmdComman.Parameters.AddWithValue("@KhoaHoc", txtKhoaHoc.Text);

            cmdComman.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsLop.Tables["Lop"].Rows.Add(txtMSLop.Text, txtTenLop.Text, txtKhoaHoc.Text);
            dgvLop.CurrentCell = dgvLop[0, dgvLop.Rows.Count - 1];
            GanDuLieu();
            blnThem = false;
            DieuKhienKhiBinhThuong();
        }

        void CapNhatLop()
        {
            string strSql = "Update Lop set TenLop=@TenLop, KhoaHoc=@KhoaHoc Where MSLop=@MSLop";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdComman = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdComman.Parameters.AddWithValue("@MSLop", txtMSLop.Text);
            cmdComman.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
            cmdComman.Parameters.AddWithValue("@KhoaHoc", txtKhoaHoc.Text);

            cmdComman.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            int curRow = dgvLop.CurrentRow.Index;
            dsLop.Tables["Lop"].Rows[curRow][1] = txtTenLop.Text;
            dsLop.Tables["Lop"].Rows[curRow][2] = txtKhoaHoc.Text;

            DieuKhienKhiBinhThuong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int khoa;
            if ((txtMSLop.Text == "") || (txtTenLop.Text == "") || (!int.TryParse(txtKhoaHoc.Text, out khoa)) || (khoa <= 0))
                MessageBox.Show("Lỗi nhập dữ liệu");
            else
            {
                if (blnThem)
                    if (MyPublics.TonTaiKhoaChinh(txtMSLop.Text, "MSLop", "Lop"))
                    {
                        MessageBox.Show("Mã số lớp tồn tại !!!");
                        txtMSLop.Focus();
                    }
                    else
                    {
                        LuuLopMoi();

                    }
                else
                {
                    CapNhatLop();
                }
            }
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
                    string strSql = "Delete Lop Where MSLop=@MSLop";
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                        MyPublics.conMyConnection.Open();
                    SqlCommand cmdComman = new SqlCommand(strSql, MyPublics.conMyConnection);
                    cmdComman.Parameters.AddWithValue("@MSLop", txtMSLop.Text);

                    cmdComman.ExecuteNonQuery();
                    MyPublics.conMyConnection.Close();

                    dsLop.Tables["Lop"].Rows.RemoveAt(dgvLop.CurrentRow.Index);
                    GanDuLieu();
                }
            }
            DieuKhienKhiBinhThuong();
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            blnThem = false;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
