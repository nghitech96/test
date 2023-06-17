using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Models;
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
    public partial class frmNguoiDung : Form
    {
        public frmNguoiDung()
        {
           
            InitializeComponent();
           
           
        }

        NguoiDung_Bus _busNguoidung = new NguoiDung_Bus();
        NhanVien_Bus _busNhanvien=new NhanVien_Bus();
        VaiTro_Bus _busVaitro = new VaiTro_Bus();

        NguoiDung _NguoiDung = new NguoiDung();
        NhanVien _nhanvien = new NhanVien();


        List<VaiTro> dsVaitro = new List<VaiTro>();
        List<NhanVien> dsNhanvien = new List<NhanVien>();
        List<NguoiDungDangnhap> dsNguoiDung = new List<NguoiDungDangnhap>();
        
        BindingList<NguoiDungDangnhap> lstNguoidung = new BindingList<NguoiDungDangnhap>();

        //BindingList<NguoiDung> dsNguoiDungBDL = new BindingList<NguoiDung>();
        BindingSource dsNguoiDungBS {get ; set; }
        BindingSource dsNhanVienBS {get ; set; }
        private async void frmNguoiDung_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadVaiTro();
            LoadData();
            
          //  txtNguoiDung.DataBindings.Add("Text", _NguoiDung.Ten, "Ten", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private async void LoadData()
        {
            dsNguoiDung = await _busNguoidung.LayDanhsachNguoiDung2();

            lstNguoidung =new BindingList<NguoiDungDangnhap>(dsNguoiDung);

            dsNguoiDungBS = new BindingSource
            {
                DataSource = lstNguoidung
            };

            if (dsNguoiDung.Count > 0)
            {
                _NguoiDung = dsNguoiDung[0];
            }
            else
            {
                _NguoiDung = new NguoiDungDangnhap
                {
                    TaiKhoan = ""
                };

            }

            dgvNguoiDung.DataSource = dsNguoiDungBS;
            OrderColumnGridView();

        }

        private void OrderColumnGridView()
        {
            dgvNguoiDung.Columns["ColID"].DisplayIndex = 0;
            dgvNguoiDung.Columns["ColTaikhoan"].DisplayIndex = 1;
            dgvNguoiDung.Columns["colTenNhanvien"].DisplayIndex = 2;
            dgvNguoiDung.Columns["sodt"].DisplayIndex = 3;
            dgvNguoiDung.Columns["email"].DisplayIndex = 4;
        }
        private async void LoadNhanVien()
        {
            dsNhanvien = await _busNhanvien.LayDanhsachNhanVien();

            dsNhanVienBS = new BindingSource
            {
                DataSource = dsNhanvien
            };

            cbNhanvien.DisplayMember = "TenNhanVien";
            cbNhanvien.ValueMember = "Id";
            cbNhanvien.DataSource = dsNhanVienBS;

            //colTenNhanvien.ValueMember = "Id";
            //colTenNhanvien.DisplayMember = "TenNhanvien";
            //colTenNhanvien.DataSource = dsNhanVienBS;

        }
        private async void LoadVaiTro()
        {
            dsVaitro = await _busVaitro.LayDanhsachVaiTro();


            cbVaitro.DisplayMember = "TenVaiTro";
            cbVaitro.ValueMember = "Id";
            cbVaitro.DataSource = dsVaitro;

            //colTenNhanvien.ValueMember = "Id";
            //colTenNhanvien.DisplayMember = "TenNhanvien";
            //colTenNhanvien.DataSource = dsNhanVienBS;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            var frmSearch = new UI.frmNguoidungTimkiem();
            frmSearch.Owner = this;
            frmSearch.StartPosition= FormStartPosition.CenterParent;
            DialogResult dialogResult = frmSearch.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dsNguoiDung = frmSearch.NguoiDungs;
                dsNguoiDungBS.DataSource = dsNguoiDung;

                if (dsNguoiDung == null)
                {
                    return;
                }
                if (dsNguoiDung.Count<=0)
                {
                    return;
                }
                dgvNguoiDung.DataSource = dsNguoiDung;

                btnGetAll.Visible = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var item = GetDataCurrentfromGridView(dgvNguoiDung);
            if (item==null)
            {
                return;
            }
            DialogResult dialog = MessageBox.Show($"Bạn muốn xóa :{item.TaiKhoan}", "Xóa", MessageBoxButtons.YesNo);
            if (dialog==DialogResult.No)
            {
                return;
            }
            //dsNguoiDungBS.Remove(item);
            var response = await _busNguoidung.XoaNguoiDung(item.NguoiDungId);
            if (response.Count > 0)
            {
                dsNguoiDungBS.Remove(item);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            var NguoiDungModel = GetDataFromForm();
            NguoiDungModel.NguoiDungId = 0;
            var kq = await _busNguoidung.ThemNguoiDung(NguoiDungModel);
            if (kq.Count>0)
            {
                var item = new NguoiDung();
                _busNguoidung.Map(NguoiDungModel, ref item);

                item.NguoiDungId = int.Parse(kq.Id);
                
                dsNguoiDungBS.Add(item);
            }
            //dgvNguoiDung.Refresh();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            //dsNguoiDungBS.
            if (dgvNguoiDung.CurrentRow == null)
                return;
            if (dgvNguoiDung.CurrentRow.DataBoundItem == null)
                return;

            var item = (NguoiDungDangnhap)dgvNguoiDung.CurrentRow.DataBoundItem;
            //var item = GetDataCurrentfromGridView(dgvNguoiDung);
            var data = GetDataFromForm();
            data.NguoiDungId = item.NguoiDungId;

            var kq = await _busNguoidung.CapnhatNguoiDung(data);
            if (kq.Count>0)
            {
                //lstNguoidung.
                _busNguoidung.Map(data, ref item);
                //item.TenNguoiDung = txtNguoiDung.Text;
                
                dgvNguoiDung.Refresh();
            }
           
        }

        private void dgvNguoiDung_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentRow == null)
                return;
            if (dg.CurrentRow.DataBoundItem == null)
                return;
            var item = GetDataCurrentfromGridView(dg);
           DisplayData(item);
            
        }
        private NguoiDung GetDataCurrentfromGridView(DataGridView dgv)
        {
            
            var item = (NguoiDung)dgv.CurrentRow.DataBoundItem;
            //txtNguoiDung.Text = item.Ten;
            return item;
        }
        private NguoiDungModel GetDataFromForm()
        {
            var NguoiDung = new NguoiDungModel
            {
                TaiKhoan =txtTaikhoan.Text,
                MatKhau= txtMatkhau.Text,
                NguoiDungId = int.Parse(txtNguoiDungId.Text),
                NhanVienId=int.Parse(cbNhanvien.SelectedValue.ToString()),
                VaiTroId =int.Parse(cbVaitro.SelectedValue.ToString())
                
            };
            return NguoiDung;
        }
        private void DisplayData(NguoiDung nd)
        {
            
            txtTaikhoan.Text= nd.TaiKhoan;
            txtMatkhau.Text = nd.MatKhau;
            txtMatkhau2.Text = nd.MatKhau;

            txtNguoiDungId.Text = nd.NguoiDungId.ToString();
            cbNhanvien.SelectedValue = nd.NhanVienId;
            cbVaitro.SelectedValue = nd.VaiTroId;
        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            LoadData();
            btnGetAll.Visible = false;
        }
    }
}
