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
    public partial class TacGiaForm : Form
    {
        private CapNhat _capNhat;
        public BindingSource DSTacGia { get; set; }
        public TacGiaForm()
        {
            InitializeComponent();
            dgTacGia.AutoGenerateColumns = false;
            dgTacGia.AllowUserToAddRows = false;

            grCapNhat.Visible = false;
            DSTacGia = new BindingSource
            {
                DataSource = BL.Ins.TacGia.LayDuLieu()
            };
            dgTacGia.DataSource = DSTacGia;
        }
        private void AnHienGroupGrid()
        {          
            grGrid.Visible = !grGrid.Visible;
        }

        private void AnHienGroupEdit()
        {
            
            grCapNhat.Visible = !grCapNhat.Visible;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTen.Text= String.Empty;
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

            var tg = new TacGia() { Ten= ten};
            Predicate<TacGia> pre = BL.Ins.TacGia.Them;
            if(_capNhat == CapNhat.Sua)
            {
                pre = BL.Ins.TacGia.Sua;
                tg.Id = ((TacGia)dgTacGia.CurrentRow.DataBoundItem).Id;
            }
           

            var kq = pre(tg);
            if (!kq)
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if(_capNhat == CapNhat.Them && kq)
            //{
            //    DSTacGia.Add(tg);
            //}

            DSTacGia = new BindingSource
            {
                DataSource = BL.Ins.TacGia.LayDuLieu()
            };
            dgTacGia.DataSource = DSTacGia;
                    

            grCapNhat.Visible = false;
            AnHienGroupGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var curRow = dgTacGia.CurrentRow;
            if (curRow == null) return;
            txtTen.Text = curRow.Cells[0].Value.ToString();
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
            var tg = ((TacGia)dgTacGia.CurrentRow?.DataBoundItem);
            if (tg == null) return;
            var kq = BL.Ins.TacGia.Xoa(tg);
            if(kq)
            {
                DSTacGia.Remove(tg);
                dgTacGia.Update();
                dgTacGia.Refresh();
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
