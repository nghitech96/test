namespace Quanly_NhaSach.GUI
{
    partial class HoaDonBanHangForm
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
            this.grCapNhat = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTongThanhTien = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbKhachHang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgChiTiet = new System.Windows.Forms.DataGridView();
            this.Sach = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbNgay = new System.Windows.Forms.Label();
            this.txtMaSo = new System.Windows.Forms.TextBox();
            this.lbMaSo = new System.Windows.Forms.Label();
            this.grGrid = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgHoaDon = new System.Windows.Forms.DataGridView();
            this.MaSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhachHang = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TongThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.grCapNhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChiTiet)).BeginInit();
            this.grGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // grCapNhat
            // 
            this.grCapNhat.Controls.Add(this.label5);
            this.grCapNhat.Controls.Add(this.lbTongThanhTien);
            this.grCapNhat.Controls.Add(this.label3);
            this.grCapNhat.Controls.Add(this.cbKhachHang);
            this.grCapNhat.Controls.Add(this.label2);
            this.grCapNhat.Controls.Add(this.dgChiTiet);
            this.grCapNhat.Controls.Add(this.dtNgay);
            this.grCapNhat.Controls.Add(this.btnHuy);
            this.grCapNhat.Controls.Add(this.btnOk);
            this.grCapNhat.Controls.Add(this.lbNgay);
            this.grCapNhat.Controls.Add(this.txtMaSo);
            this.grCapNhat.Controls.Add(this.lbMaSo);
            this.grCapNhat.Location = new System.Drawing.Point(29, 22);
            this.grCapNhat.Name = "grCapNhat";
            this.grCapNhat.Size = new System.Drawing.Size(548, 558);
            this.grCapNhat.TabIndex = 9;
            this.grCapNhat.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(194, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "HÓA ĐƠN";
            // 
            // lbTongThanhTien
            // 
            this.lbTongThanhTien.AutoSize = true;
            this.lbTongThanhTien.Location = new System.Drawing.Point(457, 459);
            this.lbTongThanhTien.Name = "lbTongThanhTien";
            this.lbTongThanhTien.Size = new System.Drawing.Size(13, 13);
            this.lbTongThanhTien.TabIndex = 13;
            this.lbTongThanhTien.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tổng thành tiền";
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(96, 175);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(415, 21);
            this.cbKhachHang.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Khách Hàng";
            // 
            // dgChiTiet
            // 
            this.dgChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sach,
            this.DonGia,
            this.SoLuong,
            this.ThanhTien});
            this.dgChiTiet.Location = new System.Drawing.Point(26, 247);
            this.dgChiTiet.Name = "dgChiTiet";
            this.dgChiTiet.Size = new System.Drawing.Size(485, 176);
            this.dgChiTiet.TabIndex = 9;
            this.dgChiTiet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgChiTiet_CellValueChanged);
            this.dgChiTiet.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgChiTiet_DataBindingComplete);
            this.dgChiTiet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgChiTiet_MouseClick);
            // 
            // Sach
            // 
            this.Sach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sach.DataPropertyName = "IdSach";
            this.Sach.HeaderText = "Sách";
            this.Sach.Name = "Sach";
            this.Sach.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sach.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.Name = "DonGia";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(96, 134);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(415, 20);
            this.dtNgay.TabIndex = 8;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(436, 512);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(26, 512);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lbNgay
            // 
            this.lbNgay.AutoSize = true;
            this.lbNgay.Location = new System.Drawing.Point(23, 141);
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.Size(32, 13);
            this.lbNgay.TabIndex = 2;
            this.lbNgay.Text = "Ngày";
            // 
            // txtMaSo
            // 
            this.txtMaSo.Location = new System.Drawing.Point(96, 94);
            this.txtMaSo.Name = "txtMaSo";
            this.txtMaSo.Size = new System.Drawing.Size(415, 20);
            this.txtMaSo.TabIndex = 1;
            // 
            // lbMaSo
            // 
            this.lbMaSo.AutoSize = true;
            this.lbMaSo.Location = new System.Drawing.Point(23, 101);
            this.lbMaSo.Name = "lbMaSo";
            this.lbMaSo.Size = new System.Drawing.Size(36, 13);
            this.lbMaSo.TabIndex = 0;
            this.lbMaSo.Text = "Mã số";
            // 
            // grGrid
            // 
            this.grGrid.Controls.Add(this.btnQuayLai);
            this.grGrid.Controls.Add(this.label1);
            this.grGrid.Controls.Add(this.dgHoaDon);
            this.grGrid.Controls.Add(this.btnXoa);
            this.grGrid.Controls.Add(this.btnThem);
            this.grGrid.Controls.Add(this.btnSua);
            this.grGrid.Location = new System.Drawing.Point(32, 45);
            this.grGrid.Name = "grGrid";
            this.grGrid.Size = new System.Drawing.Size(551, 558);
            this.grGrid.TabIndex = 8;
            this.grGrid.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "DANH SÁCH HÓA ĐƠN BÁN HÀNG";
            // 
            // dgHoaDon
            // 
            this.dgHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSo,
            this.Ngay,
            this.KhachHang,
            this.TongThanhTien});
            this.dgHoaDon.Location = new System.Drawing.Point(9, 98);
            this.dgHoaDon.Name = "dgHoaDon";
            this.dgHoaDon.Size = new System.Drawing.Size(522, 374);
            this.dgHoaDon.TabIndex = 4;
            // 
            // MaSo
            // 
            this.MaSo.DataPropertyName = "Id";
            this.MaSo.HeaderText = "Mã hóa đơn";
            this.MaSo.Name = "MaSo";
            this.MaSo.ReadOnly = true;
            // 
            // Ngay
            // 
            this.Ngay.DataPropertyName = "Ngay";
            this.Ngay.HeaderText = "Ngày";
            this.Ngay.Name = "Ngay";
            this.Ngay.ReadOnly = true;
            this.Ngay.Width = 46;
            // 
            // KhachHang
            // 
            this.KhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KhachHang.DataPropertyName = "IdKhachHang";
            this.KhachHang.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.KhachHang.HeaderText = "Khách Hàng";
            this.KhachHang.Name = "KhachHang";
            this.KhachHang.ReadOnly = true;
            // 
            // TongThanhTien
            // 
            this.TongThanhTien.DataPropertyName = "ThanhTien";
            this.TongThanhTien.HeaderText = "Thành tiền";
            this.TongThanhTien.Name = "TongThanhTien";
            this.TongThanhTien.ReadOnly = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(275, 512);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(7, 512);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(130, 512);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Location = new System.Drawing.Point(456, 512);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(75, 23);
            this.btnQuayLai.TabIndex = 11;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // HoaDonBanHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 635);
            this.Controls.Add(this.grCapNhat);
            this.Controls.Add(this.grGrid);
            this.Name = "HoaDonBanHangForm";
            this.Text = "HoaDonBanHangForm";
            this.grCapNhat.ResumeLayout(false);
            this.grCapNhat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChiTiet)).EndInit();
            this.grGrid.ResumeLayout(false);
            this.grGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grCapNhat;
        private System.Windows.Forms.ComboBox cbKhachHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgChiTiet;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbNgay;
        private System.Windows.Forms.TextBox txtMaSo;
        private System.Windows.Forms.Label lbMaSo;
        private System.Windows.Forms.GroupBox grGrid;
        private System.Windows.Forms.DataGridView dgHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTongThanhTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay;
        private System.Windows.Forms.DataGridViewComboBoxColumn KhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThanhTien;
        private System.Windows.Forms.DataGridViewComboBoxColumn Sach;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.Button btnQuayLai;
    }
}