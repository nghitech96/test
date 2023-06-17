namespace Quanly_NhaSach.GUI
{
    partial class TheLoaiForm
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
            this.dgTheLoai = new System.Windows.Forms.DataGridView();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grCapNhat = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grGrid = new System.Windows.Forms.GroupBox();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTheLoai)).BeginInit();
            this.grCapNhat.SuspendLayout();
            this.grGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTheLoai
            // 
            this.dgTheLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTheLoai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ten});
            this.dgTheLoai.Location = new System.Drawing.Point(12, 177);
            this.dgTheLoai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgTheLoai.Name = "dgTheLoai";
            this.dgTheLoai.RowHeadersWidth = 51;
            this.dgTheLoai.Size = new System.Drawing.Size(465, 423);
            this.dgTheLoai.TabIndex = 0;
            // 
            // Ten
            // 
            this.Ten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ten.DataPropertyName = "Ten";
            this.Ten.HeaderText = "Thể Loại";
            this.Ten.MinimumWidth = 6;
            this.Ten.Name = "Ten";
            this.Ten.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 229);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thể Loại";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(111, 218);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(257, 27);
            this.txtTen.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(269, 329);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 35);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(27, 325);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grCapNhat
            // 
            this.grCapNhat.Controls.Add(this.label3);
            this.grCapNhat.Controls.Add(this.txtTen);
            this.grCapNhat.Controls.Add(this.btnHuy);
            this.grCapNhat.Controls.Add(this.label1);
            this.grCapNhat.Controls.Add(this.btnOK);
            this.grCapNhat.Location = new System.Drawing.Point(65, 80);
            this.grCapNhat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grCapNhat.Name = "grCapNhat";
            this.grCapNhat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grCapNhat.Size = new System.Drawing.Size(424, 429);
            this.grCapNhat.TabIndex = 12;
            this.grCapNhat.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(124, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 36);
            this.label3.TabIndex = 13;
            this.label3.Text = "THỂ LOẠI";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(251, 634);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(131, 634);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 635);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // grGrid
            // 
            this.grGrid.Controls.Add(this.btnQuayLai);
            this.grGrid.Controls.Add(this.label4);
            this.grGrid.Controls.Add(this.dgTheLoai);
            this.grGrid.Controls.Add(this.btnXoa);
            this.grGrid.Controls.Add(this.btnThem);
            this.grGrid.Controls.Add(this.btnSua);
            this.grGrid.Location = new System.Drawing.Point(36, 25);
            this.grGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grGrid.Name = "grGrid";
            this.grGrid.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grGrid.Size = new System.Drawing.Size(488, 709);
            this.grGrid.TabIndex = 16;
            this.grGrid.TabStop = false;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Location = new System.Drawing.Point(380, 634);
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(100, 35);
            this.btnQuayLai.TabIndex = 17;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(53, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 36);
            this.label4.TabIndex = 16;
            this.label4.Text = "DANH SÁCH THỂ LOẠI";
            // 
            // TheLoaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 886);
            this.Controls.Add(this.grGrid);
            this.Controls.Add(this.grCapNhat);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TheLoaiForm";
            this.Text = "Thể Loại";
            ((System.ComponentModel.ISupportInitialize)(this.dgTheLoai)).EndInit();
            this.grCapNhat.ResumeLayout(false);
            this.grCapNhat.PerformLayout();
            this.grGrid.ResumeLayout(false);
            this.grGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgTheLoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.GroupBox grGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQuayLai;
    }
}