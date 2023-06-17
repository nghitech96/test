namespace Quanly_NhaSach.UI
{
    partial class frmBaoCao_CongNo
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
            this.ColKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDauKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhatSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNoCuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIDKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThongke = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongke)).BeginInit();
            this.SuspendLayout();
            // 
            // cbThang
            // 
            this.cbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Location = new System.Drawing.Point(138, 55);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(73, 28);
            this.cbThang.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "BÁO CÁO CÔNG NỢ CỦA KHÁCH HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tháng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Năm";
            // 
            // cbNam
            // 
            this.cbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(302, 55);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(73, 28);
            this.cbNam.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Khách hàng";
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(138, 91);
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
            this.ColKhachHang,
            this.ColDauKy,
            this.ColPhatSinh,
            this.ColNoCuoi,
            this.ColTang,
            this.ColGiam,
            this.ColIDKhachHang});
            this.dgvThongke.Location = new System.Drawing.Point(2, 174);
            this.dgvThongke.Name = "dgvThongke";
            this.dgvThongke.ReadOnly = true;
            this.dgvThongke.RowHeadersWidth = 51;
            this.dgvThongke.RowTemplate.Height = 29;
            this.dgvThongke.Size = new System.Drawing.Size(959, 276);
            this.dgvThongke.TabIndex = 7;
            // 
            // ColKhachHang
            // 
            this.ColKhachHang.DataPropertyName = "TenKhachHang";
            this.ColKhachHang.HeaderText = "Khách hàng";
            this.ColKhachHang.MinimumWidth = 6;
            this.ColKhachHang.Name = "ColKhachHang";
            this.ColKhachHang.ReadOnly = true;
            this.ColKhachHang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColKhachHang.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColKhachHang.Width = 325;
            // 
            // ColDauKy
            // 
            this.ColDauKy.DataPropertyName = "DauKy";
            this.ColDauKy.HeaderText = "Nợ đầu";
            this.ColDauKy.MinimumWidth = 6;
            this.ColDauKy.Name = "ColDauKy";
            this.ColDauKy.ReadOnly = true;
            this.ColDauKy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDauKy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDauKy.Width = 125;
            // 
            // ColPhatSinh
            // 
            this.ColPhatSinh.DataPropertyName = "Phatsinh";
            this.ColPhatSinh.HeaderText = "Phát Sinh";
            this.ColPhatSinh.MinimumWidth = 6;
            this.ColPhatSinh.Name = "ColPhatSinh";
            this.ColPhatSinh.ReadOnly = true;
            this.ColPhatSinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPhatSinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPhatSinh.Width = 125;
            // 
            // ColNoCuoi
            // 
            this.ColNoCuoi.DataPropertyName = "CuoiKy";
            this.ColNoCuoi.HeaderText = "Nợ cuối";
            this.ColNoCuoi.MinimumWidth = 6;
            this.ColNoCuoi.Name = "ColNoCuoi";
            this.ColNoCuoi.ReadOnly = true;
            this.ColNoCuoi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColNoCuoi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNoCuoi.Width = 125;
            // 
            // ColTang
            // 
            this.ColTang.DataPropertyName = "Tang";
            this.ColTang.HeaderText = "Tăng";
            this.ColTang.MinimumWidth = 6;
            this.ColTang.Name = "ColTang";
            this.ColTang.ReadOnly = true;
            this.ColTang.Visible = false;
            this.ColTang.Width = 125;
            // 
            // ColGiam
            // 
            this.ColGiam.DataPropertyName = "Giam";
            this.ColGiam.HeaderText = "Giảm";
            this.ColGiam.MinimumWidth = 6;
            this.ColGiam.Name = "ColGiam";
            this.ColGiam.ReadOnly = true;
            this.ColGiam.Visible = false;
            this.ColGiam.Width = 125;
            // 
            // ColIDKhachHang
            // 
            this.ColIDKhachHang.DataPropertyName = "IdKhachHang";
            this.ColIDKhachHang.HeaderText = "IDKH";
            this.ColIDKhachHang.MinimumWidth = 6;
            this.ColIDKhachHang.Name = "ColIDKhachHang";
            this.ColIDKhachHang.ReadOnly = true;
            this.ColIDKhachHang.Visible = false;
            this.ColIDKhachHang.Width = 125;
            // 
            // btnThongke
            // 
            this.btnThongke.Location = new System.Drawing.Point(138, 136);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.Size = new System.Drawing.Size(94, 29);
            this.btnThongke.TabIndex = 6;
            this.btnThongke.Text = "Xem";
            this.btnThongke.UseVisualStyleBackColor = true;
            this.btnThongke.Click += new System.EventHandler(this.btnThongke_Click);
            // 
            // frmBaoCao_CongNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 450);
            this.Controls.Add(this.btnThongke);
            this.Controls.Add(this.dgvThongke);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbKhachHang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbThang);
            this.Name = "frmBaoCao_CongNo";
            this.Text = "Báo cáo công nợ";
            this.Load += new System.EventHandler(this.frmBaoCao_CongNo_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDauKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhatSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNoCuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIDKhachHang;
    }
}