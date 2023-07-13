namespace QL_SinhVien
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnuQuanLySV = new System.Windows.Forms.MenuStrip();
            this.mnuDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSVTheoLop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCapNhat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChonHKNK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKetQuaHT = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuTienIch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuQuanLySV.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuQuanLySV
            // 
            this.mnuQuanLySV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuQuanLySV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDuLieu,
            this.mnuCapNhat,
            this.MnuTienIch});
            this.mnuQuanLySV.Location = new System.Drawing.Point(0, 0);
            this.mnuQuanLySV.Name = "mnuQuanLySV";
            this.mnuQuanLySV.Size = new System.Drawing.Size(800, 28);
            this.mnuQuanLySV.TabIndex = 0;
            this.mnuQuanLySV.Text = "menuStrip1";
            // 
            // mnuDuLieu
            // 
            this.mnuDuLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLop,
            this.mnuSinhVien,
            this.mnuMonHoc,
            this.mnuSVTheoLop});
            this.mnuDuLieu.Name = "mnuDuLieu";
            this.mnuDuLieu.Size = new System.Drawing.Size(69, 24);
            this.mnuDuLieu.Text = "Dữ liệu";
            // 
            // mnuLop
            // 
            this.mnuLop.Name = "mnuLop";
            this.mnuLop.Size = new System.Drawing.Size(203, 26);
            this.mnuLop.Text = "Lớp ";
            this.mnuLop.Click += new System.EventHandler(this.mnuLop_Click);
            // 
            // mnuSinhVien
            // 
            this.mnuSinhVien.Name = "mnuSinhVien";
            this.mnuSinhVien.Size = new System.Drawing.Size(203, 26);
            this.mnuSinhVien.Text = "Sinh viên";
            // 
            // mnuMonHoc
            // 
            this.mnuMonHoc.Name = "mnuMonHoc";
            this.mnuMonHoc.Size = new System.Drawing.Size(203, 26);
            this.mnuMonHoc.Text = "Môn học";
            // 
            // mnuSVTheoLop
            // 
            this.mnuSVTheoLop.Name = "mnuSVTheoLop";
            this.mnuSVTheoLop.Size = new System.Drawing.Size(203, 26);
            this.mnuSVTheoLop.Text = "Sinh viên theo lớp";
            // 
            // mnuCapNhat
            // 
            this.mnuCapNhat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChonHKNK,
            this.mnuKetQuaHT});
            this.mnuCapNhat.Name = "mnuCapNhat";
            this.mnuCapNhat.Size = new System.Drawing.Size(80, 24);
            this.mnuCapNhat.Text = "Cập nhật";
            this.mnuCapNhat.Click += new System.EventHandler(this.cậpNhậtToolStripMenuItem_Click);
            // 
            // mnuChonHKNK
            // 
            this.mnuChonHKNK.Name = "mnuChonHKNK";
            this.mnuChonHKNK.Size = new System.Drawing.Size(189, 26);
            this.mnuChonHKNK.Text = "Chọn học kỳ";
            // 
            // mnuKetQuaHT
            // 
            this.mnuKetQuaHT.Name = "mnuKetQuaHT";
            this.mnuKetQuaHT.Size = new System.Drawing.Size(189, 26);
            this.mnuKetQuaHT.Text = "Kết quả học tập";
            // 
            // MnuTienIch
            // 
            this.MnuTienIch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuDangXuat,
            this.mnuDoiMK,
            this.mnuGioiThieu,
            this.mnuThoat});
            this.MnuTienIch.Name = "MnuTienIch";
            this.MnuTienIch.Size = new System.Drawing.Size(72, 24);
            this.MnuTienIch.Text = "Tiện ích";
            // 
            // mnuDangNhap
            // 
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.Size = new System.Drawing.Size(216, 26);
            this.mnuDangNhap.Text = "Đăng nhập";
            this.mnuDangNhap.Click += new System.EventHandler(this.mnuDangNhap_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(216, 26);
            this.mnuDangXuat.Text = "Đăng xuất";
            // 
            // mnuDoiMK
            // 
            this.mnuDoiMK.Name = "mnuDoiMK";
            this.mnuDoiMK.Size = new System.Drawing.Size(216, 26);
            this.mnuDoiMK.Text = "Đổi mật khẩu";
            // 
            // mnuGioiThieu
            // 
            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Size = new System.Drawing.Size(216, 26);
            this.mnuGioiThieu.Text = "Giới thiệu";
            this.mnuGioiThieu.Click += new System.EventHandler(this.mnuGioiThieu_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(216, 26);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mnuQuanLySV);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuQuanLySV;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuQuanLySV.ResumeLayout(false);
            this.mnuQuanLySV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuQuanLySV;
        private System.Windows.Forms.ToolStripMenuItem mnuLop;
        private System.Windows.Forms.ToolStripMenuItem mnuSinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuSVTheoLop;
        private System.Windows.Forms.ToolStripMenuItem mnuChonHKNK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuKetQuaHT;
        private System.Windows.Forms.ToolStripMenuItem MnuTienIch;
        private System.Windows.Forms.ToolStripMenuItem mnuGioiThieu;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        public System.Windows.Forms.ToolStripMenuItem mnuDuLieu;
        public System.Windows.Forms.ToolStripMenuItem mnuCapNhat;
        public System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        public System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        public System.Windows.Forms.ToolStripMenuItem mnuDoiMK;
    }
}

