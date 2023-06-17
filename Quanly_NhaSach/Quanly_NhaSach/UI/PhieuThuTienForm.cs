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
    public partial class PhieuThuTienForm : Form
    {
        private CapNhat _capNhat;
        public BindingSource DSPhieuThuTien { get; set; }
        public BindingSource DSKhachHang { get; set; }
        public PhieuThuTienForm()
        {
            InitializeComponent();
            dgPhieuThuTien.AutoGenerateColumns = false;
            dgPhieuThuTien.AllowUserToAddRows = false;
            cbKhachHang.DisplayMember = "Ten";
            cbKhachHang.ValueMember = "Id";
            grCapNhat.Visible = false;

            var cot = dgPhieuThuTien.Columns[2] as DataGridViewComboBoxColumn;
            cot.ValueMember = "Id";
            cot.DisplayMember = "Ten";

            DSPhieuThuTien = new BindingSource
            {
                DataSource = BL.Ins.PhieuThuTien.LayDuLieu()
            };
            DSKhachHang = new BindingSource
            {
                DataSource = BL.Ins.KhachHang.LayDuLieu()
            };
            cot.DataSource = DSKhachHang;
            cbKhachHang.DataSource = DSKhachHang;
            dgPhieuThuTien.DataSource = DSPhieuThuTien;
        }
        private void AnHienGroupGrid()
        {
            grGrid.Visible = !grGrid.Visible;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSo.Text = String.Empty;
            cbKhachHang.SelectedIndex = 0;
            txtTien.Text = "0";
            _capNhat = CapNhat.Them;
            grCapNhat.Visible = true;
            AnHienGroupGrid();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var maSo = txtMaSo.Text;
            if (string.IsNullOrEmpty(maSo))
            {
                return;
            }

            var ptt = new PhieuThuTien()
            {
                Id = maSo,
                Ngay = dtNgay.Value,
                IdKhachHang = cbKhachHang.SelectedValue.ToInt32(),
                Tien = txtTien.Text.ToInt64()
            };

            bool kq = false;
            if (_capNhat == CapNhat.Sua)
            {
                var id = ((PhieuThuTien)dgPhieuThuTien.CurrentRow.DataBoundItem)?.Id;
                kq = BL.Ins.PhieuThuTien.Sua(ptt, id);             
            }

            if (_capNhat == CapNhat.Them)
            {
                kq = BL.Ins.PhieuThuTien.Them(ptt);               
            }

            if (!kq)
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DSPhieuThuTien = new BindingSource
            {
                DataSource = BL.Ins.PhieuThuTien.LayDuLieu()
            };
            dgPhieuThuTien.DataSource = DSPhieuThuTien;



            grCapNhat.Visible = false;
            AnHienGroupGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var curRow = dgPhieuThuTien.CurrentRow;
            if (curRow == null) return;
            var ptt = curRow.DataBoundItem as PhieuThuTien;
            txtMaSo.Text = ptt.Id;
            var date = ptt.Ngay;
            dtNgay.Value = date == null ? DateTime.Now : date;
            cbKhachHang.SelectedValue = ptt.IdKhachHang;
            txtTien.Text = ptt.Tien.ToString();
            AnHienGroupGrid();
            _capNhat = CapNhat.Sua;
            grCapNhat.Visible = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            AnHienGroupGrid();
            grCapNhat.Visible = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var tg = ((PhieuThuTien)dgPhieuThuTien.CurrentRow?.DataBoundItem);
            if (tg == null) return;
            var kq = BL.Ins.PhieuThuTien.Xoa(tg);
            if (kq)
            {
                DSPhieuThuTien.Remove(tg);
                dgPhieuThuTien.Update();
                dgPhieuThuTien.Refresh();
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
