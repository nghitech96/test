namespace Quanly_NhaSach.UI
{
    partial class frmBaocao_XuatNhap
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
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSach = new System.Windows.Forms.ComboBox();
            this.dgvThongke = new System.Windows.Forms.DataGridView();
            this.ColStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSoluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThongke = new System.Windows.Forms.Button();
            this.txtDauky = new System.Windows.Forms.TextBox();
            this.txtCuoiky = new System.Windows.Forms.TextBox();
            this.txtTang = new System.Windows.Forms.TextBox();
            this.txtGiam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongke)).BeginInit();
            this.SuspendLayout();
            // 
            // cbThang
            // 
            this.cbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Location = new System.Drawing.Point(131, 61);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(73, 28);
            this.cbThang.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "BÁO CÁO XUẤT - NHẬP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tháng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Năm";
            // 
            // cbNam
            // 
            this.cbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(295, 61);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(73, 28);
            this.cbNam.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sách";
            // 
            // cbSach
            // 
            this.cbSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSach.FormattingEnabled = true;
            this.cbSach.Location = new System.Drawing.Point(131, 97);
            this.cbSach.Name = "cbSach";
            this.cbSach.Size = new System.Drawing.Size(323, 28);
            this.cbSach.TabIndex = 5;
            // 
            // dgvThongke
            // 
            this.dgvThongke.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColStt,
            this.ColNgay,
            this.ColMaPhieu,
            this.ColLoai,
            this.ColSoluong,
            this.ColTon});
            this.dgvThongke.Location = new System.Drawing.Point(2, 177);
            this.dgvThongke.Name = "dgvThongke";
            this.dgvThongke.RowHeadersWidth = 51;
            this.dgvThongke.RowTemplate.Height = 29;
            this.dgvThongke.Size = new System.Drawing.Size(877, 261);
            this.dgvThongke.TabIndex = 7;
            // 
            // ColStt
            // 
            this.ColStt.DataPropertyName = "stt";
            this.ColStt.HeaderText = "STT";
            this.ColStt.MinimumWidth = 6;
            this.ColStt.Name = "ColStt";
            this.ColStt.Width = 50;
            // 
            // ColNgay
            // 
            this.ColNgay.DataPropertyName = "Ngay";
            this.ColNgay.HeaderText = "Ngày";
            this.ColNgay.MinimumWidth = 6;
            this.ColNgay.Name = "ColNgay";
            this.ColNgay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColNgay.Width = 125;
            // 
            // ColMaPhieu
            // 
            this.ColMaPhieu.DataPropertyName = "Id";
            this.ColMaPhieu.HeaderText = "Mã";
            this.ColMaPhieu.MinimumWidth = 6;
            this.ColMaPhieu.Name = "ColMaPhieu";
            this.ColMaPhieu.Width = 80;
            // 
            // ColLoai
            // 
            this.ColLoai.DataPropertyName = "Loai";
            this.ColLoai.HeaderText = "Loại";
            this.ColLoai.MinimumWidth = 6;
            this.ColLoai.Name = "ColLoai";
            this.ColLoai.Width = 125;
            // 
            // ColSoluong
            // 
            this.ColSoluong.DataPropertyName = "Soluong";
            this.ColSoluong.HeaderText = "Số lượng";
            this.ColSoluong.MinimumWidth = 6;
            this.ColSoluong.Name = "ColSoluong";
            this.ColSoluong.Width = 125;
            // 
            // ColTon
            // 
            this.ColTon.DataPropertyName = "Ton";
            this.ColTon.HeaderText = "Tồn";
            this.ColTon.MinimumWidth = 6;
            this.ColTon.Name = "ColTon";
            this.ColTon.Width = 125;
            // 
            // btnThongke
            // 
            this.btnThongke.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThongke.ForeColor = System.Drawing.Color.Blue;
            this.btnThongke.Location = new System.Drawing.Point(131, 142);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.Size = new System.Drawing.Size(94, 29);
            this.btnThongke.TabIndex = 6;
            this.btnThongke.Text = "Xem";
            this.btnThongke.UseVisualStyleBackColor = true;
            this.btnThongke.Click += new System.EventHandler(this.btnThongke_Click);
            // 
            // txtDauky
            // 
            this.txtDauky.Location = new System.Drawing.Point(689, 39);
            this.txtDauky.Name = "txtDauky";
            this.txtDauky.ReadOnly = true;
            this.txtDauky.Size = new System.Drawing.Size(125, 27);
            this.txtDauky.TabIndex = 9;
            // 
            // txtCuoiky
            // 
            this.txtCuoiky.Location = new System.Drawing.Point(689, 72);
            this.txtCuoiky.Name = "txtCuoiky";
            this.txtCuoiky.ReadOnly = true;
            this.txtCuoiky.Size = new System.Drawing.Size(125, 27);
            this.txtCuoiky.TabIndex = 10;
            // 
            // txtTang
            // 
            this.txtTang.Location = new System.Drawing.Point(689, 102);
            this.txtTang.Name = "txtTang";
            this.txtTang.ReadOnly = true;
            this.txtTang.Size = new System.Drawing.Size(125, 27);
            this.txtTang.TabIndex = 11;
            // 
            // txtGiam
            // 
            this.txtGiam.Location = new System.Drawing.Point(689, 134);
            this.txtGiam.Name = "txtGiam";
            this.txtGiam.ReadOnly = true;
            this.txtGiam.Size = new System.Drawing.Size(125, 27);
            this.txtGiam.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Đầu kỳ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(595, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Cuối kỳ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(595, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tổng nhập";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(595, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tổng xuất";
            // 
            // frmBaocao_XuatNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGiam);
            this.Controls.Add(this.txtTang);
            this.Controls.Add(this.txtCuoiky);
            this.Controls.Add(this.txtDauky);
            this.Controls.Add(this.btnThongke);
            this.Controls.Add(this.dgvThongke);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbThang);
            this.Name = "frmBaocao_XuatNhap";
            this.Text = "Báo cáo Xuất - Nhập";
            this.Load += new System.EventHandler(this.frmBaocao_XuatNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSach;
        private System.Windows.Forms.DataGridView dgvThongke;
        private System.Windows.Forms.Button btnThongke;
        private System.Windows.Forms.TextBox txtDauky;
        private System.Windows.Forms.TextBox txtCuoiky;
        private System.Windows.Forms.TextBox txtTang;
        private System.Windows.Forms.TextBox txtGiam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNoDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSoluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTon;
    }
}