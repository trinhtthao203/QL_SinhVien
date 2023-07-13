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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
  
        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chương trình quản lý sinh vien6Version 1.0 \n Bộ môn Tin học Ứng dụng", "Giới thiệu");
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuLop_Click(object sender, EventArgs e)
        {
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap fDangNhap = new frmDangNhap(this);
            fDangNhap.ShowDialog();
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap fDangNhap = new frmDangNhap(this);
            fDangNhap.ShowDialog();
        }

        private void lớpTheoVịTríToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLop_01 fLop_01 = new frmLop_01();
            fLop_01.ShowDialog();
        }

        private void mnuLop02_Click(object sender, EventArgs e)
        {
            frmLop_02 fLop_02 = new frmLop_02();
            fLop_02.ShowDialog();
        }
    }
}
