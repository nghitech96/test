using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebAPI_QLNS.Models;

namespace Quanly_NhaSach.UI
{
    public partial class frmTheLoai : Form
    {
        public frmTheLoai()
        {
           
            InitializeComponent();
           
        }
        TheLoai _theloai = new TheLoai();
        TheLoai_Bus _bus = new TheLoai_Bus();
        List<TheLoai> dsTheLoai = new List<TheLoai>();
        BindingList<TheLoai> dsTheLoaiL = new BindingList<TheLoai>();
        BindingSource dsTheLoaiBS {get ; set; }
        private async void frmTheLoai_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dsTheLoai.Count > 0)
            {
                _theloai = dsTheLoai[0];
            }
            else
            {
                _theloai = new TheLoai
                {
                    Ten = ""
                };

            }
          //  txtTheLoai.DataBindings.Add("Text", _theloai.Ten, "Ten", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private async void LoadData()
        {
            dsTheLoai = await _bus.LayDanhsachTheLoai();
            dsTheLoaiBS = new BindingSource
            {
                DataSource = dsTheLoai
            };
            //if (dsTheLoai != null)
            //{
            //    dsTheLoaiBS.DataSource = dsTheLoai;
            //}

            dgvTheLoai.DataSource = dsTheLoaiBS;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private async void btnFind_Click(object sender, EventArgs e)
        //{
        //    dsTheLoai = await _bus.LayDanhsachTheLoai();
        //    if (dsTheLoai == null)
        //    {
        //        return;
        //    }
        //    dgvTheLoai.DataSource = dsTheLoai;
        //}

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var item = GetDataCurrentfromGridView(dgvTheLoai);
            if (item==null)
            {
                return;
            }
            DialogResult dialog = MessageBox.Show($"Bạn muốn xóa :{item.Ten}", "Xóa", MessageBoxButtons.YesNo);
            if (dialog==DialogResult.No)
            {
                return;
            }
            //dsTheLoaiBS.Remove(item);
            var response = await _bus.XoaTheLoai(item.Id);
            if (response.Count > 0)
            {
                dsTheLoaiBS.Remove(item);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            
            var tl = new TheLoaiModel { Ten = txtTheLoai.Text };
            var kq = await _bus.ThemTheLoai(tl);
            if (kq.Count>0)
            {
                var item = new TheLoai
                {
                    Ten = txtTheLoai.Text,
                    Id = int.Parse( kq.Id)
                };
                
                //dsTheLoai.Add(item);
                dsTheLoaiBS.Add(item);
                //dsTheLoaiBS.up
            }
            //dgvTheLoai.DataSource = dsTheLoai;
            //dgvTheLoai.Refresh();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            //dsTheLoaiBS.
            var item = GetDataCurrentfromGridView(dgvTheLoai);
            var data = new TheLoaiModel
            {
                Id = item.Id,
                Ten = txtTheLoai.Text
            };

            var kq = await _bus.CapnhatTheLoai(data);
            if (kq.Count>0)
            {
                item.Ten = txtTheLoai.Text;
                dgvTheLoai.Refresh();
            }



            

           
        }

        private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentRow == null)
                return;
            if (dg.CurrentRow.DataBoundItem == null)
                return;
            var item = GetDataCurrentfromGridView(dg);
            txtTheLoai.Text = item.Ten;
        }
        private TheLoai GetDataCurrentfromGridView(DataGridView dgv)
        {
            
            //DataRow dr = (dg.CurrentRow.DataBoundItem as DataRowView).Row;
            var item = (TheLoai)dgv.CurrentRow.DataBoundItem;
            //txtTheLoai.Text = item.Ten;
            return item;
        }
    }
}
