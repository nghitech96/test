namespace Quanly_NhaSach.UI
{
    partial class frmSach
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
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTensach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTacgia = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColTheLoai = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoluongTon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSachId = new System.Windows.Forms.TextBox();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.txtNhanVienId = new System.Windows.Forms.TextBox();
            this.cbTacgia = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTheloai = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColTensach,
            this.colSoluong,
            this.colTacgia,
            this.ColTheLoai});
            this.dgvSach.Location = new System.Drawing.Point(1, 9);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 29;
            this.dgvSach.Size = new System.Drawing.Size(594, 507);
            this.dgvSach.TabIndex = 14;
            this.dgvSach.SelectionChanged += new System.EventHandler(this.dgvSach_SelectionChanged);
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "Id";
            this.ColID.Frozen = true;
            this.ColID.HeaderText = "ID";
            this.ColID.MinimumWidth = 6;
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Width = 40;
            // 
            // ColTensach
            // 
            this.ColTensach.DataPropertyName = "Ten";
            this.ColTensach.HeaderText = "Tên sách";
            this.ColTensach.MinimumWidth = 6;
            this.ColTensach.Name = "ColTensach";
            this.ColTensach.ReadOnly = true;
            this.ColTensach.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTensach.Width = 200;
            // 
            // colSoluong
            // 
            this.colSoluong.DataPropertyName = "SoluongTon";
            this.colSoluong.HeaderText = "SL Tồn";
            this.colSoluong.MinimumWidth = 6;
            this.colSoluong.Name = "colSoluong";
            this.colSoluong.Width = 125;
            // 
            // colTacgia
            // 
            this.colTacgia.DataPropertyName = "IdTacgia";
            this.colTacgia.HeaderText = "Tác giả";
            this.colTacgia.MinimumWidth = 6;
            this.colTacgia.Name = "colTacgia";
            this.colTacgia.ReadOnly = true;
            this.colTacgia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTacgia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTacgia.Width = 200;
            // 
            // ColTheLoai
            // 
            this.ColTheLoai.DataPropertyName = "IdTheloai";
            this.ColTheLoai.HeaderText = "Thể loại";
            this.ColTheLoai.MinimumWidth = 6;
            this.ColTheLoai.Name = "ColTheLoai";
            this.ColTheLoai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTheLoai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColTheLoai.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(802, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN SÁCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Image = global::Quanly_NhaSach.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(736, 326);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 42);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Image = global::Quanly_NhaSach.Properties.Resources.modify;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(832, 326);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 42);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Image = global::Quanly_NhaSach.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(928, 326);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 42);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFind.Image = global::Quanly_NhaSach.Properties.Resources.find;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(1024, 326);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(90, 42);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "Tìm";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Image = global::Quanly_NhaSach.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1120, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 42);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Đóng";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(767, 130);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(427, 27);
            this.txtTenSach.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên sách";
            // 
            // txtSoluongTon
            // 
            this.txtSoluongTon.Location = new System.Drawing.Point(767, 182);
            this.txtSoluongTon.Name = "txtSoluongTon";
            this.txtSoluongTon.ReadOnly = true;
            this.txtSoluongTon.Size = new System.Drawing.Size(427, 27);
            this.txtSoluongTon.TabIndex = 6;
            this.txtSoluongTon.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Số lượng tồn";
            // 
            // txtSachId
            // 
            this.txtSachId.Location = new System.Drawing.Point(601, 12);
            this.txtSachId.Name = "txtSachId";
            this.txtSachId.Size = new System.Drawing.Size(66, 27);
            this.txtSachId.TabIndex = 15;
            this.txtSachId.Text = "0";
            this.txtSachId.Visible = false;
            // 
            // btnGetAll
            // 
            this.btnGetAll.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGetAll.Image = global::Quanly_NhaSach.Properties.Resources.load;
            this.btnGetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetAll.Location = new System.Drawing.Point(640, 326);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(90, 42);
            this.btnGetAll.TabIndex = 16;
            this.btnGetAll.Text = "Tất cả";
            this.btnGetAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Visible = false;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // txtNhanVienId
            // 
            this.txtNhanVienId.Location = new System.Drawing.Point(601, 45);
            this.txtNhanVienId.Name = "txtNhanVienId";
            this.txtNhanVienId.Size = new System.Drawing.Size(66, 27);
            this.txtNhanVienId.TabIndex = 18;
            this.txtNhanVienId.Text = "0";
            this.txtNhanVienId.Visible = false;
            // 
            // cbTacgia
            // 
            this.cbTacgia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTacgia.FormattingEnabled = true;
            this.cbTacgia.Location = new System.Drawing.Point(767, 231);
            this.cbTacgia.Name = "cbTacgia";
            this.cbTacgia.Size = new System.Drawing.Size(427, 28);
            this.cbTacgia.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(635, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tác giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thể loại";
            // 
            // cbTheloai
            // 
            this.cbTheloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheloai.FormattingEnabled = true;
            this.cbTheloai.Location = new System.Drawing.Point(767, 80);
            this.cbTheloai.Name = "cbTheloai";
            this.cbTheloai.Size = new System.Drawing.Size(427, 28);
            this.cbTheloai.TabIndex = 17;
            // 
            // frmSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 517);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTacgia);
            this.Controls.Add(this.txtNhanVienId);
            this.Controls.Add(this.cbTheloai);
            this.Controls.Add(this.btnGetAll);
            this.Controls.Add(this.txtSachId);
            this.Controls.Add(this.txtSoluongTon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvSach);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSach";
            this.Text = "Sách";
            this.Load += new System.EventHandler(this.frmSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoluongTon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSachId;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.TextBox txtNhanVienId;
        private System.Windows.Forms.ComboBox cbTacgia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTheloai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTensach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoluong;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTacgia;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColTheLoai;
    }
}