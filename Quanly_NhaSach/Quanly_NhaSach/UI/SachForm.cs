using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanly_NhaSach.GUI
{
    public partial class SachForm : Form
    {
        private CapNhat _capNhat;
        public BindingSource DSSach { get; set; }
        public BindingSource DSTacGia { get; set; }
        public BindingSource DSTheLoai { get; set; }
        public SachForm()
        {
            InitializeComponent();
            grCapNhat.Visible = false; 
            dgSach.AutoGenerateColumns = false;
            dgSach.AllowUserToAddRows = false;
            cbTacGia.MaxDropDownItems = 100;

            var column = dgSach.Columns[1] as DataGridViewComboBoxColumn;         
            column.DataSource = BL.Ins.TheLoai.LayDuLieu();
            column.DisplayMember = "Ten";
            column.ValueMember = "Id";

            column = dgSach.Columns[2] as DataGridViewComboBoxColumn;
            column.DataSource = BL.Ins.TacGia.LayDuLieu();
            column.DisplayMember = "Ten";
            column.ValueMember = "Id";

            DSSach = new BindingSource
            {
                DataSource = BL.Ins.Sach.LayDuLieu()
            };
            DSTacGia = new BindingSource
            {
                DataSource = BL.Ins.TacGia.LayDuLieu()
            };
            DSTheLoai = new BindingSource
            {
                DataSource = BL.Ins.TheLoai.LayDuLieu()
            };

            cbTacGia.DataSource = DSTacGia;
            cbTacGia.DisplayMember = "Ten";
            cbTacGia.ValueMember = "Id";

            cbTheLoai.DataSource = DSTheLoai;
            cbTheLoai.DisplayMember = "Ten";
            cbTheLoai.ValueMember = "Id";
            dgSach.DataSource = DSSach;
        }
        private void AnHienGroupGrid()
        {
            grGrid.Visible = !grGrid.Visible;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var ten = txtTen.Text;
            int idTheLoai = (int)cbTheLoai.SelectedValue;
            int idTacGia = (int)cbTacGia.SelectedValue;
            if (string.IsNullOrEmpty(ten))
            {
                return;
            }

            var tg = new Sach() { 
                Ten = ten,
                IdTacGia= idTacGia,
                IdTheLoai= idTheLoai,
                
            };
            Predicate<Sach> pre = BL.Ins.Sach.Them;
            if (_capNhat == CapNhat.Sua)
            {
                pre = BL.Ins.Sach.Sua;
                tg.Id = ((Sach)dgSach.CurrentRow.DataBoundItem).Id;
            }


            var kq = pre(tg);
            if (!kq)
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DSSach = new BindingSource
            {
                DataSource = BL.Ins.Sach.LayDuLieu()
            };

            dgSach.DataSource = DSSach;
            
            grCapNhat.Visible = false;
            AnHienGroupGrid();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            AnHienGroupGrid();
            grCapNhat.Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTen.Text = String.Empty;
            cbTacGia.SelectedIndex = 0;
            cbTheLoai.SelectedIndex = 0;
            _capNhat = CapNhat.Them;
            grCapNhat.Visible = true;
            AnHienGroupGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var sach = dgSach.CurrentRow?.DataBoundItem as Sach;
            if (sach == null) return;
            txtTen.Text = sach.Ten;
            cbTheLoai.SelectedValue = sach.IdTheLoai;
            cbTacGia.SelectedValue = sach.IdTacGia;
            
            AnHienGroupGrid();
            _capNhat = CapNhat.Sua;
            grCapNhat.Visible = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var sach = (Sach)dgSach.CurrentRow?.DataBoundItem;
            sach.ChiTietNhapSaches = null;
            sach.ChiTietHoaDons = null;
            
            if(sach == null) return;
            var kq = BL.Ins.Sach.Xoa(sach);
            if(kq)
            {
                DSSach.Remove(sach);
            }
            else
            {
                MessageBox.Show("Không thể xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
