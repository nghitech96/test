namespace Quanly_NhaSach
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Hethong_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.Hethong_Dangnhap_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.Hethong_DangXuat_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.Hethong_TheLoai_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.Hethong_Sach_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.Hethong_Tacgia_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.Hethong_QuyDinh_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.Hethong_Thoat_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.BanHang_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.BanHang_Sach_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.BanHang_Phieuthu_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.BanHang_Khachhang_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.NhapHang_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.NhapHang_PhieuNhap_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.Baocao_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.Baocao_XuatNhap_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.Baocao_CongNo_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.Baocao_TracuuSach_mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Nguoidung = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Hethong_mnu,
            this.NhapHang_mnu,
            this.BanHang_mnu,
            this.Baocao_mnu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1300, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Hethong_mnu
            // 
            this.Hethong_mnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Hethong_Dangnhap_mnu,
            this.Hethong_DangXuat_mnu,
            this.toolStripMenuItem2,
            this.Hethong_Sach_mnu,
            this.Hethong_TheLoai_mnu,
            this.Hethong_Tacgia_mnu,
            this.Hethong_QuyDinh_mnu,
            this.toolStripMenuItem1,
            this.Hethong_Thoat_mnu});
            this.Hethong_mnu.Name = "Hethong_mnu";
            this.Hethong_mnu.Size = new System.Drawing.Size(64, 24);
            this.Hethong_mnu.Text = "Menu ";
            // 
            // Hethong_Dangnhap_mnu
            // 
            this.Hethong_Dangnhap_mnu.Name = "Hethong_Dangnhap_mnu";
            this.Hethong_Dangnhap_mnu.Size = new System.Drawing.Size(224, 26);
            this.Hethong_Dangnhap_mnu.Text = "Đăng nhập";
            this.Hethong_Dangnhap_mnu.Click += new System.EventHandler(this.Hethong_Dangnhap_mnu_Click);
            // 
            // Hethong_DangXuat_mnu
            // 
            this.Hethong_DangXuat_mnu.Name = "Hethong_DangXuat_mnu";
            this.Hethong_DangXuat_mnu.Size = new System.Drawing.Size(224, 26);
            this.Hethong_DangXuat_mnu.Text = "Đăng xuất";
            this.Hethong_DangXuat_mnu.Click += new System.EventHandler(this.Hethong_DangXuat_mnu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // Hethong_TheLoai_mnu
            // 
            this.Hethong_TheLoai_mnu.Name = "Hethong_TheLoai_mnu";
            this.Hethong_TheLoai_mnu.Size = new System.Drawing.Size(224, 26);
            this.Hethong_TheLoai_mnu.Text = "Thể Loại Sách";
            this.Hethong_TheLoai_mnu.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.Hethong_TheLoai_mnu.Click += new System.EventHandler(this.Hethong_TheLoai_mnu_Click);
            // 
            // Hethong_Sach_mnu
            // 
            this.Hethong_Sach_mnu.Name = "Hethong_Sach_mnu";
            this.Hethong_Sach_mnu.Size = new System.Drawing.Size(224, 26);
            this.Hethong_Sach_mnu.Text = "Danh sách Sách";
            this.Hethong_Sach_mnu.Click += new System.EventHandler(this.Hethong_Sach_mnu_Click);
            // 
            // Hethong_Tacgia_mnu
            // 
            this.Hethong_Tacgia_mnu.Name = "Hethong_Tacgia_mnu";
            this.Hethong_Tacgia_mnu.Size = new System.Drawing.Size(224, 26);
            this.Hethong_Tacgia_mnu.Text = "Tác Giả";
            this.Hethong_Tacgia_mnu.Click += new System.EventHandler(this.Hethong_Tacgia_mnu_Click);
            // 
            // Hethong_QuyDinh_mnu
            // 
            this.Hethong_QuyDinh_mnu.Name = "Hethong_QuyDinh_mnu";
            this.Hethong_QuyDinh_mnu.Size = new System.Drawing.Size(224, 26);
            this.Hethong_QuyDinh_mnu.Text = "Quy định";
            this.Hethong_QuyDinh_mnu.Click += new System.EventHandler(this.Hethong_QuyDinh_mnu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // Hethong_Thoat_mnu
            // 
            this.Hethong_Thoat_mnu.Name = "Hethong_Thoat_mnu";
            this.Hethong_Thoat_mnu.Size = new System.Drawing.Size(224, 26);
            this.Hethong_Thoat_mnu.Text = "Thoát";
            this.Hethong_Thoat_mnu.Click += new System.EventHandler(this.Hethong_Thoat_mnu_Click);
            // 
            // BanHang_mnu
            // 
            this.BanHang_mnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BanHang_Khachhang_mnu,
            this.BanHang_Phieuthu_mnu,
            this.BanHang_Sach_mnu});
            this.BanHang_mnu.Name = "BanHang_mnu";
            this.BanHang_mnu.Size = new System.Drawing.Size(88, 24);
            this.BanHang_mnu.Text = "Bán Hàng";
            // 
            // BanHang_Sach_mnu
            // 
            this.BanHang_Sach_mnu.Name = "BanHang_Sach_mnu";
            this.BanHang_Sach_mnu.Size = new System.Drawing.Size(224, 26);
            this.BanHang_Sach_mnu.Text = "Hóa đơn bán hàng";
            this.BanHang_Sach_mnu.Click += new System.EventHandler(this.BanHang_Sach_mnu_Click);
            // 
            // BanHang_Phieuthu_mnu
            // 
            this.BanHang_Phieuthu_mnu.Name = "BanHang_Phieuthu_mnu";
            this.BanHang_Phieuthu_mnu.Size = new System.Drawing.Size(224, 26);
            this.BanHang_Phieuthu_mnu.Text = "Phiếu thu tiền";
            this.BanHang_Phieuthu_mnu.Click += new System.EventHandler(this.BanHang_Phieuthu_mnu_Click);
            // 
            // BanHang_Khachhang_mnu
            // 
            this.BanHang_Khachhang_mnu.Name = "BanHang_Khachhang_mnu";
            this.BanHang_Khachhang_mnu.Size = new System.Drawing.Size(224, 26);
            this.BanHang_Khachhang_mnu.Text = "Khách hàng";
            this.BanHang_Khachhang_mnu.Click += new System.EventHandler(this.BanHang_Khachhang_mnu_Click);
            // 
            // NhapHang_mnu
            // 
            this.NhapHang_mnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NhapHang_PhieuNhap_mnu});
            this.NhapHang_mnu.Name = "NhapHang_mnu";
            this.NhapHang_mnu.Size = new System.Drawing.Size(99, 24);
            this.NhapHang_mnu.Text = "Nhập Hàng";
            // 
            // NhapHang_PhieuNhap_mnu
            // 
            this.NhapHang_PhieuNhap_mnu.Name = "NhapHang_PhieuNhap_mnu";
            this.NhapHang_PhieuNhap_mnu.Size = new System.Drawing.Size(224, 26);
            this.NhapHang_PhieuNhap_mnu.Text = "Phiếu Nhập sách";
            this.NhapHang_PhieuNhap_mnu.Click += new System.EventHandler(this.NhapHang_PhieuNhap_mnu_Click);
            // 
            // Baocao_mnu
            // 
            this.Baocao_mnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Baocao_XuatNhap_mnu,
            this.Baocao_CongNo_mnu,
            this.Baocao_TracuuSach_mnu});
            this.Baocao_mnu.Name = "Baocao_mnu";
            this.Baocao_mnu.Size = new System.Drawing.Size(152, 24);
            this.Baocao_mnu.Text = "Thống kê - Báo cáo";
            // 
            // Baocao_XuatNhap_mnu
            // 
            this.Baocao_XuatNhap_mnu.Name = "Baocao_XuatNhap_mnu";
            this.Baocao_XuatNhap_mnu.Size = new System.Drawing.Size(243, 26);
            this.Baocao_XuatNhap_mnu.Text = "Báo cáo Xuất nhập tồn";
            this.Baocao_XuatNhap_mnu.Click += new System.EventHandler(this.Baocao_XuatNhap_mnu_Click);
            // 
            // Baocao_CongNo_mnu
            // 
            this.Baocao_CongNo_mnu.Name = "Baocao_CongNo_mnu";
            this.Baocao_CongNo_mnu.Size = new System.Drawing.Size(243, 26);
            this.Baocao_CongNo_mnu.Text = "Báo cáo Công nợ";
            this.Baocao_CongNo_mnu.Click += new System.EventHandler(this.Baocao_CongNo_mnu_Click);
            // 
            // Baocao_TracuuSach_mnu
            // 
            this.Baocao_TracuuSach_mnu.Name = "Baocao_TracuuSach_mnu";
            this.Baocao_TracuuSach_mnu.Size = new System.Drawing.Size(243, 26);
            this.Baocao_TracuuSach_mnu.Text = "Tra cứu Sách";
            this.Baocao_TracuuSach_mnu.Click += new System.EventHandler(this.Baocao_TracuuSach_mnu_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Nguoidung});
            this.statusStrip1.Location = new System.Drawing.Point(0, 697);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1300, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Nguoidung
            // 
            this.toolStripStatusLabel_Nguoidung.Name = "toolStripStatusLabel_Nguoidung";
            this.toolStripStatusLabel_Nguoidung.Size = new System.Drawing.Size(116, 20);
            this.toolStripStatusLabel_Nguoidung.Text = "Tên Người dùng";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 723);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Quản lý Nhà sách V1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Hethong_mnu;
        private System.Windows.Forms.ToolStripMenuItem Hethong_Dangnhap_mnu;
        private System.Windows.Forms.ToolStripMenuItem Hethong_DangXuat_mnu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Hethong_Thoat_mnu;
        private System.Windows.Forms.ToolStripMenuItem NhapHang_mnu;
        private System.Windows.Forms.ToolStripMenuItem BanHang_mnu;
        private System.Windows.Forms.ToolStripMenuItem BanHang_Sach_mnu;
        private System.Windows.Forms.ToolStripMenuItem BanHang_Phieuthu_mnu;
        private System.Windows.Forms.ToolStripMenuItem Baocao_mnu;
        private System.Windows.Forms.ToolStripMenuItem Baocao_XuatNhap_mnu;
        private System.Windows.Forms.ToolStripMenuItem Baocao_CongNo_mnu;
        private System.Windows.Forms.ToolStripMenuItem Baocao_TracuuSach_mnu;
        private System.Windows.Forms.ToolStripMenuItem NhapHang_PhieuNhap_mnu;
        private System.Windows.Forms.ToolStripMenuItem Hethong_QuyDinh_mnu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Hethong_TheLoai_mnu;
        private System.Windows.Forms.ToolStripMenuItem Hethong_Sach_mnu;
        private System.Windows.Forms.ToolStripMenuItem Hethong_Tacgia_mnu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Nguoidung;
        private System.Windows.Forms.ToolStripMenuItem BanHang_Khachhang_mnu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
