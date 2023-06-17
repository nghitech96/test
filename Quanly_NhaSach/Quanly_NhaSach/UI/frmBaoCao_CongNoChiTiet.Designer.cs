namespace Quanly_NhaSach.UI
{
    partial class frmBaoCao_CongNoChiTiet
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
            this.cbKhachHang = new System.Windows.Forms.ComboBox();
            this.dgvThongke = new System.Windows.Forms.DataGridView();
            this.ColSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKhachHang = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColDauKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhatSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNoCuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cbThang.Location = new System.Drawing.Point(131, 54);
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
            this.label1.Size = new System.Drawing.Size(281, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "BÁO CÁO CÔNG NỢ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tháng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Năm";
            // 
            // cbNam
            // 
            this.cbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(295, 54);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(73, 28);
            this.cbNam.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Khách hàng";
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(131, 90);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(323, 28);
            this.cbKhachHang.TabIndex = 5;
            // 
            // dgvThongke
            // 
            this.dgvThongke.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSTT,
            this.ColKhachHang,
            this.ColDauKy,
            this.ColPhatSinh,
            this.ColNoCuoi});
            this.dgvThongke.Location = new System.Drawing.Point(2, 173);
            this.dgvThongke.Name = "dgvThongke";
            this.dgvThongke.RowHeadersWidth = 51;
            this.dgvThongke.RowTemplate.Height = 29;
            this.dgvThongke.Size = new System.Drawing.Size(959, 277);
            this.dgvThongke.TabIndex = 7;
            // 
            // ColSTT
            // 
            this.ColSTT.HeaderText = "STT";
            this.ColSTT.MinimumWidth = 6;
            this.ColSTT.Name = "ColSTT";
            this.ColSTT.Width = 80;
            // 
            // ColKhachHang
            // 
            this.ColKhachHang.DataPropertyName = "IdKhachHang";
            this.ColKhachHang.HeaderText = "Khách hàng";
            this.ColKhachHang.MinimumWidth = 6;
            this.ColKhachHang.Name = "ColKhachHang";
            this.ColKhachHang.Width = 325;
            // 
            // ColDauKy
            // 
            this.ColDauKy.HeaderText = "Nợ đầu";
            this.ColDauKy.MinimumWidth = 6;
            this.ColDauKy.Name = "ColDauKy";
            this.ColDauKy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDauKy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDauKy.Width = 125;
            // 
            // ColPhatSinh
            // 
            this.ColPhatSinh.HeaderText = "Phát Sinh";
            this.ColPhatSinh.MinimumWidth = 6;
            this.ColPhatSinh.Name = "ColPhatSinh";
            this.ColPhatSinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPhatSinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPhatSinh.Width = 125;
            // 
            // ColNoCuoi
            // 
            this.ColNoCuoi.HeaderText = "Nợ cuối";
            this.ColNoCuoi.MinimumWidth = 6;
            this.ColNoCuoi.Name = "ColNoCuoi";
            this.ColNoCuoi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColNoCuoi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNoCuoi.Width = 125;
            // 
            // btnThongke
            // 
            this.btnThongke.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThongke.ForeColor = System.Drawing.Color.Blue;
            this.btnThongke.Location = new System.Drawing.Point(131, 135);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.Size = new System.Drawing.Size(94, 29);
            this.btnThongke.TabIndex = 6;
            this.btnThongke.Text = "Xem";
            this.btnThongke.UseVisualStyleBackColor = true;
            this.btnThongke.Click += new System.EventHandler(this.btnThongke_Click);
            // 
            // txtDauky
            // 
            this.txtDauky.Location = new System.Drawing.Point(666, 32);
            this.txtDauky.Name = "txtDauky";
            this.txtDauky.ReadOnly = true;
            this.txtDauky.Size = new System.Drawing.Size(125, 27);
            this.txtDauky.TabIndex = 9;
            // 
            // txtCuoiky
            // 
            this.txtCuoiky.Location = new System.Drawing.Point(666, 65);
            this.txtCuoiky.Name = "txtCuoiky";
            this.txtCuoiky.ReadOnly = true;
            this.txtCuoiky.Size = new System.Drawing.Size(125, 27);
            this.txtCuoiky.TabIndex = 10;
            // 
            // txtTang
            // 
            this.txtTang.Location = new System.Drawing.Point(666, 95);
            this.txtTang.Name = "txtTang";
            this.txtTang.ReadOnly = true;
            this.txtTang.Size = new System.Drawing.Size(125, 27);
            this.txtTang.TabIndex = 11;
            // 
            // txtGiam
            // 
            this.txtGiam.Location = new System.Drawing.Point(666, 127);
            this.txtGiam.Name = "txtGiam";
            this.txtGiam.ReadOnly = true;
            this.txtGiam.Size = new System.Drawing.Size(125, 27);
            this.txtGiam.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Đầu kỳ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(595, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Cuối kỳ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(595, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tăng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(595, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Giảm";
            // 
            // frmBaoCao_CongNoChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 450);
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
            this.Controls.Add(this.cbKhachHang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbThang);
            this.Name = "frmBaoCao_CongNoChiTiet";
            this.Text = "Báo cáo công nợ";
            this.Load += new System.EventHandler(this.frmBaoCao_CongNoChiTiet_Load);
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
        private System.Windows.Forms.ComboBox cbKhachHang;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSTT;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDauKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhatSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNoCuoi;
    }
}