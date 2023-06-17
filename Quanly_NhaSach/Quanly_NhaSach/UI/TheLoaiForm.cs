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
    public partial class TheLoaiForm : Form
    {
        private CapNhat _capNhat;
        public BindingSource DSTheLoai { get; set; }
        public TheLoaiForm()
        {
            InitializeComponent();
            dgTheLoai.AutoGenerateColumns = false;
            dgTheLoai.AllowUserToAddRows = false;

            grCapNhat.Visible = false;
            DSTheLoai = new BindingSource
            {
                DataSource = BL.Ins.TheLoai.LayDuLieu()
            };
            dgTheLoai.DataSource = DSTheLoai;
        }
        private void AnHienGroupGrid()
        {
            grGrid.Visible = !grGrid.Visible;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _capNhat = CapNhat.Them;
            grCapNhat.Visible = true;
            AnHienGroupGrid();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var ten = txtTen.Text;
            if (string.IsNullOrEmpty(ten))
            {
                return;
            }

            var tg = new TheLoai() { Ten = ten };
            Predicate<TheLoai> pre = BL.Ins.TheLoai.Them;
            if (_capNhat == CapNhat.Sua)
            {
                pre = BL.Ins.TheLoai.Sua;
                tg.Id = ((TheLoai)dgTheLoai.CurrentRow?.DataBoundItem).Id;
            }


            var kq = pre(tg);

            if (!kq)
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (_capNhat == CapNhat.Them && kq)
            //{
            //    DSTheLoai.Add(tg);
            //}

            DSTheLoai = new BindingSource
            {
                DataSource = BL.Ins.TheLoai.LayDuLieu()
            };
            dgTheLoai.DataSource = DSTheLoai;



            txtTen.Text = String.Empty;
            grCapNhat.Visible = false;
            AnHienGroupGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgTheLoai.CurrentRow == null || dgTheLoai.CurrentRow.IsNewRow)
                return;
            txtTen.Text = dgTheLoai.CurrentRow.Cells[0].Value.ToString();
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
            var tl = (TheLoai)dgTheLoai.CurrentRow?.DataBoundItem;
            if (tl == null) return;
            var kq = BL.Ins.TheLoai.Xoa(tl);
            if (kq)
                DSTheLoai.Remove(tl);
            else
            {
                MessageBox.Show("Không thể xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
