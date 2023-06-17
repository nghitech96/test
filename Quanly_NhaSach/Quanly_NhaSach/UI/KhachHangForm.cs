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
    public partial class KhachHangForm : Form
    {
        public BindingSource DSKhachHang { get; set; }
        private CapNhat _capNhat;
        public KhachHangForm()
        {
            InitializeComponent();
            grCapNhat.Visible = false;
            dgKhachHang.AutoGenerateColumns = false;
            dgKhachHang.AllowUserToAddRows = false;
          
            DSKhachHang = new BindingSource { DataSource = BUS.BL.Ins.KhachHang.LayDuLieu() };
            dgKhachHang.DataSource = DSKhachHang;
        }
        private void AnHienGroupGrid()
        {
            grGrid.Visible = !grGrid.Visible;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {        

            if (string.IsNullOrEmpty(txtTen.Text))
            {
                return;
            }

            var tg = new KhachHang() {
                Ten = txtTen.Text,
                DiaChi = txtDiaChi.Text,
                Email = txtEmail.Text,
                DienThoai = txtDienThoai.Text
                
            };
            Predicate<KhachHang> pre = BL.Ins.KhachHang.Them;
            if (_capNhat == CapNhat.Sua)
            {
                pre = BL.Ins.KhachHang.Sua;
                tg.Id = ((KhachHang)dgKhachHang.CurrentRow.DataBoundItem).Id;
            }


            var kq = pre(tg);
            //if (_capNhat == CapNhat.Them && kq)
            //{
            //    DSKhachHang.Add(tg);
            //}

            if (!kq)
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DSKhachHang = new BindingSource
            {
                DataSource = BL.Ins.KhachHang.LayDuLieu()
            };
            dgKhachHang.DataSource = DSKhachHang;



            txtTen.Text = String.Empty;
            txtDiaChi.Text = String.Empty;
            txtDienThoai.Text = String.Empty; 
            txtEmail.Text = String.Empty;
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
            _capNhat = CapNhat.Them;
            grCapNhat.Visible = true;
            AnHienGroupGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var kh = (KhachHang)dgKhachHang.CurrentRow?.DataBoundItem;
            if (kh == null) return;
            txtTen.Text = kh.Ten;        
            txtDiaChi.Text = kh.DiaChi;
            txtDienThoai.Text = kh.DienThoai;
            txtEmail.Text = kh.Email;
            AnHienGroupGrid();
            grCapNhat.Visible = true;
            _capNhat = CapNhat.Sua;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var kh = (KhachHang)dgKhachHang.CurrentRow?.DataBoundItem;
            if (kh == null) return;

            var kq = BL.Ins.KhachHang.Xoa(kh);
            if(kq)
                DSKhachHang.Remove(kh);
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
