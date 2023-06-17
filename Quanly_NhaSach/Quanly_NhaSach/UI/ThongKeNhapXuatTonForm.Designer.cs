namespace Quanly_NhaSach.GUI
{
    partial class ThongKeNhapXuatTonForm
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
            this.dgNXT = new System.Windows.Forms.DataGridView();
            this.HoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.cbSach = new System.Windows.Forms.ComboBox();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.lbTonDauKy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTongNhap = new System.Windows.Forms.Label();
            this.lbTongXuat = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTonCuoiKy = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgNXT)).BeginInit();
            this.SuspendLayout();
            // 
            // dgNXT
            // 
            this.dgNXT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNXT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoaDon,
            this.Ngay,
            this.Loai,
            this.SoLuong,
            this.Ton});
            this.dgNXT.Location = new System.Drawing.Point(45, 198);
            this.dgNXT.Name = "dgNXT";
            this.dgNXT.Size = new System.Drawing.Size(564, 162);
            this.dgNXT.TabIndex = 18;
            // 
            // HoaDon
            // 
            this.HoaDon.DataPropertyName = "Id";
            this.HoaDon.HeaderText = "Mã số";
            this.HoaDon.Name = "HoaDon";
            this.HoaDon.ReadOnly = true;
            // 
            // Ngay
            // 
            this.Ngay.DataPropertyName = "Ngay";
            this.Ngay.HeaderText = "Ngày";
            this.Ngay.Name = "Ngay";
            this.Ngay.ReadOnly = true;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            this.Loai.ReadOnly = true;
            this.Loai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // Ton
            // 
            this.Ton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ton.DataPropertyName = "Ton";
            this.Ton.HeaderText = "Tồn";
            this.Ton.Name = "Ton";
            this.Ton.ReadOnly = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(534, 129);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 17;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // cbSach
            // 
            this.cbSach.FormattingEnabled = true;
            this.cbSach.Location = new System.Drawing.Point(391, 129);
            this.cbSach.Name = "cbSach";
            this.cbSach.Size = new System.Drawing.Size(121, 21);
            this.cbSach.TabIndex = 19;
            // 
            // cbThang
            // 
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Location = new System.Drawing.Point(49, 128);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(47, 21);
            this.cbThang.TabIndex = 20;
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(112, 129);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(44, 20);
            this.txtNam.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "NHẬP XUẤT TỒN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tháng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Năm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Sách";
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Location = new System.Drawing.Point(534, 379);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(75, 23);
            this.btnQuayLai.TabIndex = 26;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // lbTonDauKy
            // 
            this.lbTonDauKy.AutoSize = true;
            this.lbTonDauKy.Location = new System.Drawing.Point(501, 171);
            this.lbTonDauKy.Name = "lbTonDauKy";
            this.lbTonDauKy.Size = new System.Drawing.Size(0, 13);
            this.lbTonDauKy.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Tồn đầu kỳ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Tổng nhập:";
            // 
            // lbTongNhap
            // 
            this.lbTongNhap.AutoSize = true;
            this.lbTongNhap.Location = new System.Drawing.Point(144, 389);
            this.lbTongNhap.Name = "lbTongNhap";
            this.lbTongNhap.Size = new System.Drawing.Size(0, 13);
            this.lbTongNhap.TabIndex = 30;
            // 
            // lbTongXuat
            // 
            this.lbTongXuat.AutoSize = true;
            this.lbTongXuat.Location = new System.Drawing.Point(144, 416);
            this.lbTongXuat.Name = "lbTongXuat";
            this.lbTongXuat.Size = new System.Drawing.Size(0, 13);
            this.lbTongXuat.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Tổng xuất:";
            // 
            // lbTonCuoiKy
            // 
            this.lbTonCuoiKy.AutoSize = true;
            this.lbTonCuoiKy.Location = new System.Drawing.Point(144, 443);
            this.lbTonCuoiKy.Name = "lbTonCuoiKy";
            this.lbTonCuoiKy.Size = new System.Drawing.Size(0, 13);
            this.lbTonCuoiKy.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 443);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Tồn cuối kỳ:";
            // 
            // ThongKeNhapXuatTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 496);
            this.Controls.Add(this.lbTonCuoiKy);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbTongXuat);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbTongNhap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbTonDauKy);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.cbThang);
            this.Controls.Add(this.cbSach);
            this.Controls.Add(this.dgNXT);
            this.Controls.Add(this.btnThongKe);
            this.Name = "ThongKeNhapXuatTon";
            this.Text = "ThongKeNhapXuatTon";
            ((System.ComponentModel.ISupportInitialize)(this.dgNXT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNXT;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ComboBox cbSach;
        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ton;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Label lbTonDauKy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTongNhap;
        private System.Windows.Forms.Label lbTongXuat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTonCuoiKy;
        private System.Windows.Forms.Label label11;
    }
}