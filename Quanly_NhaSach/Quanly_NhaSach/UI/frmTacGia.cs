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
    public partial class frmTacGia : Form
    {
        public frmTacGia()
        {
           
            InitializeComponent();
           
        }
        TacGia _TacGia = new TacGia();
        TacGia_Bus _bus = new TacGia_Bus();
        List<TacGia> dsTacGia = new List<TacGia>();
        BindingList<TacGia> dsTacGiaL = new BindingList<TacGia>();
        BindingSource dsTacGiaBS {get ; set; }
        private async void frmTacGia_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dsTacGia.Count > 0)
            {
                _TacGia = dsTacGia[0];
            }
            else
            {
                _TacGia = new TacGia
                {
                    Ten = ""
                };

            }
          //  txtTacGia.DataBindings.Add("Text", _TacGia.Ten, "Ten", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private async void LoadData()
        {
            dsTacGia = await _bus.LayDanhsachTacGia();
            dsTacGiaBS = new BindingSource
            {
                DataSource = dsTacGia
            };
            //if (dsTacGia != null)
            //{
            //    dsTacGiaBS.DataSource = dsTacGia;
            //}

            dgvTacGia.DataSource = dsTacGiaBS;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            dsTacGia = await _bus.LayDanhsachTacGia();
            if (dsTacGia == null)
            {
                return;
            }
            dgvTacGia.DataSource = dsTacGia;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var item = GetDataCurrentfromGridView(dgvTacGia);
            if (item==null)
            {
                return;
            }
            DialogResult dialog = MessageBox.Show($"Bạn muốn xóa :{item.Ten}", "Xóa", MessageBoxButtons.YesNo);
            if (dialog==DialogResult.No)
            {
                return;
            }
            //dsTacGiaBS.Remove(item);
            var response = await _bus.XoaTacGia(item.Id);
            if (response.Count > 0)
            {
                dsTacGiaBS.Remove(item);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            
            var tg = new TacGiaModel { Ten = txtTacGia.Text };
            var kq = await _bus.ThemTacGia(tg);
            if (kq.Count>0)
            {
                var item = new TacGia
                {
                    Ten = txtTacGia.Text,
                    Id = int.Parse( kq.Id)
                };
                
                //dsTacGia.Add(item);
                dsTacGiaBS.Add(item);
                //dsTacGiaBS.up
            }
            //dgvTacGia.DataSource = dsTacGia;
            //dgvTacGia.Refresh();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            //dsTacGiaBS.
            var item = GetDataCurrentfromGridView(dgvTacGia);
            var data = new TacGiaModel
            {
                Id = item.Id,
                Ten = txtTacGia.Text
            };

            var kq = await _bus.CapnhatTacGia(data);
            if (kq.Count>0)
            {
                item.Ten = txtTacGia.Text;
                dgvTacGia.Refresh();
            }



            

           
        }

        private void dgvTacGia_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentRow == null)
                return;
            if (dg.CurrentRow.DataBoundItem == null)
                return;
            var item = GetDataCurrentfromGridView(dg);
            txtTacGia.Text = item.Ten;
        }
        private TacGia GetDataCurrentfromGridView(DataGridView dgv)
        {
            
            //DataRow dr = (dg.CurrentRow.DataBoundItem as DataRowView).Row;
            var item = (TacGia)dgv.CurrentRow.DataBoundItem;
            //txtTacGia.Text = item.Ten;
            return item;
        }
                
    }
}
