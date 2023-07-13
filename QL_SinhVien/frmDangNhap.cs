using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_SinhVien
{
    public partial class frmDangNhap : Form
    {
        private frmMain fMain;
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public frmDangNhap(frmMain fm)
            : this()
        {
            fMain = fm;
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.Text = "alo";
            txtMSSV.Text = "B1809293";
            txtMatKhau.PasswordChar = '*';
            txtMSSV.Focus();
            ;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlCommand cmdCommand;
            SqlDataReader drReader;
            string sqlSelect, strPasswordSV;
            try
            {
                MyPublics.ConnectDatabase();
                if (MyPublics.conMyConnection.State == ConnectionState.Open)
                {
                    MyPublics.strMSSV = txtMSSV.Text;
                    strPasswordSV = txtMatKhau.Text;
                    sqlSelect = "Select MSLop, QuyenSQ From SinhVien Where MSSV = @MSSV And MatKhau = @MatKhau";
                    cmdCommand = new SqlCommand(sqlSelect, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MSSV", txtMSSV.Text);
                    cmdCommand.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                    drReader = cmdCommand.ExecuteReader();
                    if (drReader.HasRows)
                    {
                        drReader.Read();
                        MyPublics.strLop = drReader.GetString(0);
                        MyPublics.strQuyenSD = drReader.GetString(1);
                        drReader.Close();
                        MyPublics.XacDinhNKHK();
                        fMain.mnuDuLieu.Enabled = true;
                        fMain.mnuDoiMK.Enabled = true;
                        fMain.mnuDangXuat.Enabled = true;
                        fMain.mnuCapNhat.Enabled = true;
                        fMain.mnuDangNhap.Enabled = true;
                        MessageBox.Show("Đăng nhập thành công !!!");
                        MyPublics.conMyConnection.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("MSSV hoặc mật khẫu sai !!!");
                        txtMSSV.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Kết nối không thành công", "Lổi server");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thực hiện kết nói", "Thông báo");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MyPublics.conMyConnection != null)
                MyPublics.conMyConnection = null;
            fMain.mnuDuLieu.Enabled = false;
            fMain.mnuDoiMK.Enabled = false;
            fMain.mnuDangXuat.Enabled = false;
            fMain.mnuCapNhat.Enabled = false;
            this.Close();
        }
    }
}
