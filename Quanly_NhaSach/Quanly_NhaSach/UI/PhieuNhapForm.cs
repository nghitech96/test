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
    public partial class PhieuNhapForm : Form
    {
        private CapNhat _capNhat;
        public BindingSource DSSach { get; set; }
        public BindingSource DSPhieuNhap { get; set; }
        public BindingSource DSChiTiet { get; set; }

        private ContextMenu _cm = new ContextMenu();
        private DataGridViewRow _row;

        private string _id;
        public PhieuNhapForm()
        {
            InitializeComponent();
            grCapNhat.Visible = false;
            dgPhieuNhap.AutoGenerateColumns = false;
            dgChiTiet.AutoGenerateColumns = false;
            dgPhieuNhap.AllowUserToAddRows = false;

            DSSach = new BindingSource
            {
                DataSource = BL.Ins.Sach.LayDuLieu()
            };
            DSPhieuNhap = new BindingSource
            {
                DataSource = BL.Ins.PhieuNhapSach.LayDuLieu()
            };

            var cot = dgChiTiet.Columns[0] as DataGridViewComboBoxColumn;
            cot.DataSource = DSSach;
            cot.ValueMember = "Id";
            cot.DisplayMember = "Ten";


            dgPhieuNhap.DataSource = DSPhieuNhap;

            dgChiTiet.DataError += (sender, e) => { };

            var mi = new MenuItem("Xoa", new EventHandler(
               (o, e) =>
               {
                   if (_row.IsNewRow) return;
                   dgChiTiet.Rows.Remove(_row);
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
            dgChiTiet.DataSource = null;
            dgChiTiet.Rows.Clear();
            dgChiTiet.Refresh();

            _capNhat = CapNhat.Them;
            grCapNhat.Visible = true;
            AnHienGroupGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _capNhat = CapNhat.Sua;
            var pn = dgPhieuNhap.CurrentRow?.DataBoundItem as PhieuNhapSach;
            if (pn == null) return;
            txtMaSo.Text = pn.Id;
            dtNgay.Value = pn.Ngay;


            var bds = new BindingSource
            {
                
                AllowNew = true, 
            };
            foreach (var ct in pn.ChiTietNhapSaches)
            {
                bds.Add(new ChiTietNhapSach
                {
                    Id = ct.Id,
                    IdSach = ct.IdSach,
                    SoLuong = ct.SoLuong
                });
            }

            dgChiTiet.DataSource = bds;

            _id = pn.Id;
            grCapNhat.Visible = true;
            AnHienGroupGrid();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var pn = (PhieuNhapSach)dgPhieuNhap.CurrentRow?.DataBoundItem;

            var kq = BL.Ins.PhieuNhapSach.Xoa(pn);
            if (kq)
            {
                DSPhieuNhap.Remove(pn);
                dgPhieuNhap.Update();
                dgPhieuNhap.Refresh();
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

            var pn = new PhieuNhapSach
            {
                Id = txtMaSo.Text,
                Ngay = dtNgay.Value
            };

            ICollection<ChiTietNhapSach> ct = new List<ChiTietNhapSach>();
            foreach (DataGridViewRow row in dgChiTiet.Rows)
            {
                if (row.IsNewRow) break;
                var cbCell = row.Cells[0] as DataGridViewComboBoxCell;
                if (cbCell.Value == null) return;
                var idSach = (int)cbCell.Value;
                var sach = (DSSach.DataSource as List<Sach>).FirstOrDefault(s => s.Id == idSach);
                var soLuong = Convert.ToInt64(row.Cells[1].Value);
                if (BL.Ins.QuyDinh.CoDungQuyDinh())
                {
                    if (!BL.Ins.PhieuNhapSach.KiemTraSoLuongNhapToiThieu(soLuong))
                    {
                        MessageBox.Show($"{sach.Ten} không đủ số lượng nhập tối thiểu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                

                ct.Add(new ChiTietNhapSach
                {
                    Id = pn.Id,
                    IdSach = idSach,
                    SoLuong = soLuong,
                });
            }
            pn.ChiTietNhapSaches = ct;

            bool kq = false;



            if (_capNhat == CapNhat.Sua)
            {
                kq = BL.Ins.PhieuNhapSach.Sua(pn, _id);                
            }
            else
            {
                kq = BL.Ins.PhieuNhapSach.Them(pn);
            }

            if (!kq) return;

            DSPhieuNhap = new BindingSource
            {
                DataSource = BL.Ins.PhieuNhapSach.LayDuLieu()
            };

            dgPhieuNhap.DataSource = DSPhieuNhap;


            grCapNhat.Visible = false;
            AnHienGroupGrid();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            AnHienGroupGrid();
            grCapNhat.Visible = false;
        }

        private void dgChiTiet_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            int currentMouseOverRow = dgChiTiet.HitTest(e.X, e.Y).RowIndex;
            if (currentMouseOverRow >= 0 && !dgChiTiet.Rows[currentMouseOverRow].IsNewRow)
            {
                _row = dgChiTiet.Rows[currentMouseOverRow];
                _cm.Show(dgChiTiet, new Point(e.X, e.Y));
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
