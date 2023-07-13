using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            :this()
        {
            fMain = fm;
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
            txtMSSV.Focus();
;       }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
        }




    }
}
