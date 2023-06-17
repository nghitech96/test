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
    public partial class HoaDonBanHangForm : Form
    {
        private CapNhat _capNhat;
        public BindingSource DSSach { get; set; }
        public BindingSource DSHoaDon { get; set; }
        public BindingSource DSChiTiet { get; set; }
        public BindingSource DSKhachHang { get; set; }
        private ContextMenu _cm = new ContextMenu();
        private DataGridViewRow _row;

        private string _id;

        public HoaDonBanHangForm()
        {
            InitializeComponent();

            grCapNhat.Visible = false;
            dgHoaDon.AutoGenerateColumns = false;
            dgChiTiet.AutoGenerateColumns = false;


            DSSach = new BindingSource
            {
                DataSource = BL.Ins.Sach.LayDuLieu()
            };
            DSKhachHang = new BindingSource
            {
                DataSource = BL.Ins.KhachHang.LayDuLieu()
            };
            DSHoaDon = new BindingSource
            {
                DataSource = BL.Ins.HoaDonBanHang.LayDuLieu()
            };

            var cot = dgChiTiet.Columns[0] as DataGridViewComboBoxColumn;
            cot.DataSource = DSSach;
            cot.ValueMember = "Id";
            cot.DisplayMember = "Ten";


            cot = dgHoaDon.Columns[2] as DataGridViewComboBoxColumn;
            cot.DataSource = DSKhachHang;
            cot.ValueMember = "Id";
            cot.DisplayMember = "Ten";

            cbKhachHang.DataSource = DSKhachHang;
            cbKhachHang.DisplayMember = "Ten";
            cbKhachHang.ValueMember = "Id";

            dgHoaDon.DataSource = DSHoaDon;
            dgChiTiet.DataError += (sender, e) => { };


            this.Load += (o, e) =>
            {
                TinhTongThanhTien();
            };


            var mi = new MenuItem("Xoa", new EventHandler(
                (sender, e) =>
                {
                    if (_row.IsNewRow) return;
                    dgChiTiet.Rows.Remove(_row);
                    TinhTongThanhTien();
                }
                ));

            _cm.MenuItems.Add(mi);

        }
        private void AnHienGroupGrid()
        {
            grGrid.Visible = !grGrid.Visible;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSo.Text = String.Empty;
            cbKhachHang.SelectedIndex = 0;
            dgChiTiet.DataSource = null;
            dgChiTiet.Rows.Clear();
            dgChiTiet.Refresh();
            _capNhat = CapNhat.Them;
            grCapNhat.Visible = true;
            AnHienGroupGrid();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var hd = dgHoaDon.CurrentRow?.DataBoundItem as HoaDonBanHang;
            if (hd == null) return;
            txtMaSo.Text = hd.Id;
            dtNgay.Value = hd.Ngay;
            cbKhachHang.SelectedValue = hd.IdKhachHang;
            var bds = new BindingSource
            {
                AllowNew = true,
            };
            foreach (var ct in hd.ChiTietHoaDons)
            {
                bds.Add(new ChiTietHoaDon
                {
                    IdHoaDon = ct.IdHoaDon,
                    IdSach = ct.IdSach,
                    DonGia = ct.DonGia,
                    SoLuong = ct.SoLuong
                });
            }
            dgChiTiet.DataSource = bds;
            _id = hd.Id;
            AnHienGroupGrid();
            _capNhat = CapNhat.Sua;
            grCapNhat.Visible = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var hd = (HoaDonBanHang)dgHoaDon.CurrentRow?.DataBoundItem;
            if (hd == null) return;
            var kq = BL.Ins.HoaDonBanHang.Xoa(hd);
            if (kq)
            {
                DSHoaDon.Remove(hd);
                dgHoaDon.Update();
                dgHoaDon.Refresh();
            }
            else
            {
                MessageBox.Show("Không thể xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var maSo = txtMaSo.Text;

            if (string.IsNullOrEmpty(maSo))
            {
                return;
            }

            var hd = new HoaDonBanHang
            {
                Id = txtMaSo.Text,
                Ngay = dtNgay.Value,
                IdKhachHang = (int)cbKhachHang.SelectedValue,
                ThanhTien = lbTongThanhTien.Text.ToInt64()
            };

            ICollection<ChiTietHoaDon> ct = new List<ChiTietHoaDon>();
            foreach (DataGridViewRow row in dgChiTiet.Rows)
            {
                if (row.IsNewRow) break;
                var cbCell = row.Cells[0] as DataGridViewComboBoxCell;
                var idSach = (int)cbCell.Value;
                long donGia = row.Cells[1].Value.ToString().ToInt64();
                long soLuong = row.Cells[2].Value.ToString().ToInt64();
                ct.Add(new ChiTietHoaDon
                {
                    IdHoaDon = hd.Id,
                    IdSach = idSach,
                    SoLuong = soLuong,
                    DonGia = donGia,
                });
            }
            hd.ChiTietHoaDons = ct;

            bool kq = false;



            if (_capNhat == CapNhat.Sua)
            {
                kq = BL.Ins.HoaDonBanHang.Sua(hd, _id);             
            }
            else
            {
                kq = BL.Ins.HoaDonBanHang.Them(hd);

            }

            if (!kq)
            {
                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DSHoaDon = new BindingSource
            {
                DataSource = BL.Ins.HoaDonBanHang.LayDuLieu()
            };
            dgHoaDon.DataSource = DSHoaDon;


            grCapNhat.Visible = false;
            AnHienGroupGrid();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            AnHienGroupGrid();
            grCapNhat.Visible = false;
        }

        private void dgChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var colIndex = e.ColumnIndex;
            var rowIndex = e.RowIndex;
            if (rowIndex < 0 || colIndex < 1 || colIndex > 2)
            {
                return;
            }
            var dgStr = dgChiTiet.Rows[rowIndex].Cells[1].Value?.ToString();
            var slStr = dgChiTiet.Rows[rowIndex].Cells[2].Value?.ToString();
            long dg = 0;
            long sl = 0;

            if (long.TryParse(dgStr, out dg) && long.TryParse(slStr, out sl))
            {
                dgChiTiet.Rows[rowIndex].Cells[3].Value = dg * sl;
                TinhTongThanhTien();
            }
        }
        private void TinhTongThanhTien()
        {
            long tong = 0;
            foreach (DataGridViewRow row in dgChiTiet.Rows)
            {
                if (row.IsNewRow) break;
                var str = row.Cells[3].Value?.ToString();
                long tt;
                if (long.TryParse(str, out tt))
                {
                    tong += tt;
                }
            }
            lbTongThanhTien.Text = tong.ToString();
        }

        private void dgChiTiet_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            int currentMouseOverRow = dgChiTiet.HitTest(e.X, e.Y).RowIndex;
            if (currentMouseOverRow >= 0)
            {
                _row = dgChiTiet.Rows[currentMouseOverRow];
                _cm.Show(dgChiTiet, new Point(e.X, e.Y));
            }
        }

        private void dgChiTiet_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = (DataGridView)sender;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var dgStr = row.Cells[1].Value?.ToString();
                var slStr = row.Cells[2].Value?.ToString();
                long dg = 0;
                long sl = 0;

                if (long.TryParse(dgStr, out dg) && long.TryParse(slStr, out sl))
                {
                    row.Cells[3].Value = dg * sl;
                    TinhTongThanhTien();
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
