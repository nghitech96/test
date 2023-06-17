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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
           
            InitializeComponent();
           
        }
        NhanVien _NhanVien = new NhanVien();
        NhanVien_Bus _bus = new NhanVien_Bus();
        List<NhanVien> dsNhanVien = new List<NhanVien>();
        //BindingList<NhanVien> dsNhanVienBDL = new BindingList<NhanVien>();
        BindingSource dsNhanVienBS {get ; set; }
        private async void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dsNhanVien.Count > 0)
            {
                _NhanVien = dsNhanVien[0];
            }
            else
            {
                _NhanVien = new NhanVien
                {
                    TenNhanVien = ""
                };

            }
          //  txtNhanVien.DataBindings.Add("Text", _NhanVien.Ten, "Ten", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private async void LoadData()
        {
            dsNhanVien = await _bus.LayDanhsachNhanVien();
            
            dsNhanVienBS = new BindingSource
            {
                DataSource = dsNhanVien
            };
            
            dgvNhanVien.DataSource = dsNhanVienBS;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            var frmSearch = new UI.frmNhanvienTimkiem();
            frmSearch.Owner = this;
            frmSearch.StartPosition= FormStartPosition.CenterParent;
            DialogResult dialogResult = frmSearch.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dsNhanVien = frmSearch.nhanviens;
                dsNhanVienBS.DataSource = dsNhanVien;

                if (dsNhanVien == null)
                {
                    return;
                }
                if (dsNhanVien.Count<=0)
                {
                    return;
                }
                dgvNhanVien.DataSource = dsNhanVien;
                btnGetAll.Visible = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var item = GetDataCurrentfromGridView(dgvNhanVien);
            if (item==null)
            {
                return;
            }
            DialogResult dialog = MessageBox.Show($"Bạn muốn xóa :{item.TenNhanVien}", "Xóa", MessageBoxButtons.YesNo);
            if (dialog==DialogResult.No)
            {
                return;
            }
            //dsNhanVienBS.Remove(item);
            var response = await _bus.XoaNhanVien(item.Id);
            if (response.Count > 0)
            {
                dsNhanVienBS.Remove(item);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            var nhanvienModel = GetDataFromForm();
            nhanvienModel.Id = 0;
            var kq = await _bus.ThemNhanVien(nhanvienModel);
            if (kq.Count>0)
            {
                var item = new NhanVien();
                _bus.Map(nhanvienModel, ref item);

                item.Id = int.Parse(kq.Id);
                
                dsNhanVienBS.Add(item);
            }
            //dgvNhanVien.Refresh();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            //dsNhanVienBS.
            if (dgvNhanVien.CurrentRow == null)
                return;
            if (dgvNhanVien.CurrentRow.DataBoundItem == null)
                return;

            var item = (NhanVien)dgvNhanVien.CurrentRow.DataBoundItem;
            //var item = GetDataCurrentfromGridView(dgvNhanVien);
            var data = GetDataFromForm();
            data.Id = item.Id;

            var kq = await _bus.CapnhatNhanVien(data);
            if (kq.Count>0)
            {
                _bus.Map(data, ref item);
                //item.TenNhanVien = txtNhanVien.Text;
                dgvNhanVien.Refresh();
            }
           
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentRow == null)
                return;
            if (dg.CurrentRow.DataBoundItem == null)
                return;
            var item = GetDataCurrentfromGridView(dg);
           DisplayData(item);
        }
        private NhanVien GetDataCurrentfromGridView(DataGridView dgv)
        {
            
            var item = (NhanVien)dgv.CurrentRow.DataBoundItem;
            //txtNhanVien.Text = item.Ten;
            return item;
        }
        private NhanVienModel GetDataFromForm()
        {
            var nhanvien = new NhanVienModel
            {
                TenNhanVien=txtNhanVien.Text,
                ChucVu=txtChucVu.Text,
                SoDT= txtSodt.Text,
                Email = txtEmail.Text,
                Id=int.Parse(txtNhanvienId.Text)
            };
            return nhanvien;
        }
        private void DisplayData(NhanVien nv)
        {
            txtNhanVien.Text = nv.TenNhanVien;
            txtChucVu.Text= nv.ChucVu;
            txtSodt.Text= nv.SoDT;
            txtEmail.Text= nv.Email;
            txtNhanvienId.Text = nv.Id.ToString();
        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            LoadData();
            btnGetAll.Visible = false;
        }
    }
}
