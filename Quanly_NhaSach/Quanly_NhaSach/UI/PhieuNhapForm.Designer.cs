namespace Quanly_NhaSach.GUI
{
    partial class PhieuNhapForm
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
            this.dgChiTiet = new System.Windows.Forms.DataGridView();
            this.Sach = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbNgay = new System.Windows.Forms.Label();
            this.txtMaSo = new System.Windows.Forms.TextBox();
            this.lbMaSo = new System.Windows.Forms.Label();
            this.grGrid = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgPhieuNhap = new System.Windows.Forms.DataGridView();
            this.MaSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.grCapNhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChiTiet)).BeginInit();
            this.grGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // grCapNhat
            // 
            this.grCapNhat.Controls.Add(this.label5);
            this.grCapNhat.Controls.Add(this.dgChiTiet);
            this.grCapNhat.Controls.Add(this.dtNgay);
            this.grCapNhat.Controls.Add(this.btnHuy);
            this.grCapNhat.Controls.Add(this.btnOk);
            this.grCapNhat.Controls.Add(this.lbNgay);
            this.grCapNhat.Controls.Add(this.txtMaSo);
            this.grCapNhat.Controls.Add(this.lbMaSo);
            this.grCapNhat.Location = new System.Drawing.Point(35, 12);
            this.grCapNhat.Name = "grCapNhat";
            this.grCapNhat.Size = new System.Drawing.Size(409, 434);
            this.grCapNhat.TabIndex = 7;
            this.grCapNhat.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(97, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 29);
            this.label5.TabIndex = 19;
            this.label5.Text = "PHIẾU NHẬP SÁCH";
            // 
            // dgChiTiet
            // 
            this.dgChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sach,
            this.SoLuong});
            this.dgChiTiet.Location = new System.Drawing.Point(32, 205);
            this.dgChiTiet.Name = "dgChiTiet";
            this.dgChiTiet.Size = new System.Drawing.Size(347, 151);
            this.dgChiTiet.TabIndex = 9;
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
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(102, 145);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(277, 20);
            this.dtNgay.TabIndex = 8;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(304, 390);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(32, 390);
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
            this.lbNgay.Location = new System.Drawing.Point(29, 152);
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.Size(32, 13);
            this.lbNgay.TabIndex = 2;
            this.lbNgay.Text = "Ngày";
            // 
            // txtMaSo
            // 
            this.txtMaSo.Location = new System.Drawing.Point(102, 105);
            this.txtMaSo.Name = "txtMaSo";
            this.txtMaSo.Size = new System.Drawing.Size(277, 20);
            this.txtMaSo.TabIndex = 1;
            // 
            // lbMaSo
            // 
            this.lbMaSo.AutoSize = true;
            this.lbMaSo.Location = new System.Drawing.Point(29, 112);
            this.lbMaSo.Name = "lbMaSo";
            this.lbMaSo.Size = new System.Drawing.Size(36, 13);
            this.lbMaSo.TabIndex = 0;
            this.lbMaSo.Text = "Mã số";
            // 
            // grGrid
            // 
            this.grGrid.Controls.Add(this.btnQuayLai);
            this.grGrid.Controls.Add(this.label1);
            this.grGrid.Controls.Add(this.dgPhieuNhap);
            this.grGrid.Controls.Add(this.btnXoa);
            this.grGrid.Controls.Add(this.btnThem);
            this.grGrid.Controls.Add(this.btnSua);
            this.grGrid.Location = new System.Drawing.Point(35, 15);
            this.grGrid.Name = "grGrid";
            this.grGrid.Size = new System.Drawing.Size(453, 447);
            this.grGrid.TabIndex = 6;
            this.grGrid.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 29);
            this.label1.TabIndex = 20;
            this.label1.Text = "DANH SÁCH PHIẾU NHẬP";
            // 
            // dgPhieuNhap
            // 
            this.dgPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSo,
            this.Ngay});
            this.dgPhieuNhap.Location = new System.Drawing.Point(26, 106);
            this.dgPhieuNhap.Name = "dgPhieuNhap";
            this.dgPhieuNhap.Size = new System.Drawing.Size(404, 248);
            this.dgPhieuNhap.TabIndex = 4;
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
            this.Ngay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ngay.DataPropertyName = "Ngay";
            this.Ngay.HeaderText = "Ngày";
            this.Ngay.Name = "Ngay";
            this.Ngay.ReadOnly = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(213, 390);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(26, 390);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(116, 390);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Location = new System.Drawing.Point(355, 390);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(75, 23);
            this.btnQuayLai.TabIndex = 21;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // PhieuNhapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 505);
            this.Controls.Add(this.grCapNhat);
            this.Controls.Add(this.grGrid);
            this.Name = "PhieuNhapForm";
            this.Text = "PhieuNhapForm";
            this.grCapNhat.ResumeLayout(false);
            this.grCapNhat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChiTiet)).EndInit();
            this.grGrid.ResumeLayout(false);
            this.grGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPhieuNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grCapNhat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbNgay;
        private System.Windows.Forms.TextBox txtMaSo;
        private System.Windows.Forms.Label lbMaSo;
        private System.Windows.Forms.GroupBox grGrid;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgPhieuNhap;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.DataGridView dgChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Sach;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.Button btnQuayLai;
    }
}