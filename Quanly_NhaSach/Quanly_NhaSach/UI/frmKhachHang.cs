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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
           
            InitializeComponent();
           
        }
        KhachHang _KhachHang = new KhachHang();
        KhachHang_Bus _bus = new KhachHang_Bus();

        List<KhachHang> dsKhachHang = new List<KhachHang>();
        //BindingList<KhachHang> dsKhachHangBDL = new BindingList<KhachHang>();
        BindingSource dsKhachHangBS {get ; set; }
        private async void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dsKhachHang.Count > 0)
            {
                _KhachHang = dsKhachHang[0];
            }
            else
            {
                _KhachHang = new KhachHang
                {
                    Ten = ""
                };

            }
          //  txtKhachHang.DataBindings.Add("Text", _KhachHang.Ten, "Ten", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private async void LoadData()
        {
            dsKhachHang = await _bus.LayDanhsachKhachHang();
            
            dsKhachHangBS = new BindingSource
            {
                DataSource = dsKhachHang
            };
            
            dgvKhachHang.DataSource = dsKhachHangBS;
            OrderColumnGridView();
        }
        private void OrderColumnGridView()
        {
            dgvKhachHang.Columns["ColID"].DisplayIndex = 0;
            dgvKhachHang.Columns["ColHoten"].DisplayIndex = 1;
            dgvKhachHang.Columns["ColDienthoai"].DisplayIndex = 2;
            dgvKhachHang.Columns["ColEmail"].DisplayIndex = 3;
            dgvKhachHang.Columns["ColDiachi"].DisplayIndex = 4;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            var frmSearch = new UI.frmKhachHangTimKiem();
            frmSearch.Owner = this;
            frmSearch.StartPosition= FormStartPosition.CenterParent;
            DialogResult dialogResult = frmSearch.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dsKhachHang = frmSearch.KhachHangs;
                dsKhachHangBS.DataSource = dsKhachHang;

                if (dsKhachHang == null)
                {
                    return;
                }
                if (dsKhachHang.Count<=0)
                {
                    return;
                }
                dgvKhachHang.DataSource = dsKhachHang;
                btnGetAll.Visible = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var item = GetDataCurrentfromGridView(dgvKhachHang);
            if (item==null)
            {
                return;
            }
            DialogResult dialog = MessageBox.Show($"Bạn muốn xóa :{item.Ten}", "Xóa", MessageBoxButtons.YesNo);
            if (dialog==DialogResult.No)
            {
                return;
            }
            //dsKhachHangBS.Remove(item);
            var response = await _bus.XoaKhachHang(item.Id);
            if (response.Count > 0)
            {
                dsKhachHangBS.Remove(item);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            var KhachHangModel = GetDataFromForm();
            KhachHangModel.Id = 0;
            var kq = await _bus.ThemKhachHang(KhachHangModel);
            if (kq.Count>0)
            {
                var item = new KhachHang();
                _bus.Map(KhachHangModel, ref item);

                item.Id = int.Parse(kq.Id);
                
                dsKhachHangBS.Add(item);
            }
            //dgvKhachHang.Refresh();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            //dsKhachHangBS.
            if (dgvKhachHang.CurrentRow == null)
                return;
            if (dgvKhachHang.CurrentRow.DataBoundItem == null)
                return;

            var item = (KhachHang)dgvKhachHang.CurrentRow.DataBoundItem;
            //var item = GetDataCurrentfromGridView(dgvKhachHang);
            var data = GetDataFromForm();
            data.Id = item.Id;

            var kq = await _bus.CapnhatKhachHang(data);
            if (kq.Count>0)
            {
                _bus.Map(data, ref item);
                //item.TenKhachHang = txtKhachHang.Text;
                dgvKhachHang.Refresh();
            }
            dgvKhachHang.Refresh();
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentRow == null)
                return;
            if (dg.CurrentRow.DataBoundItem == null)
                return;
            var item = GetDataCurrentfromGridView(dg);
           DisplayData(item);
        }
        private KhachHang GetDataCurrentfromGridView(DataGridView dgv)
        {
            
            var item = (KhachHang)dgv.CurrentRow.DataBoundItem;
            //txtKhachHang.Text = item.Ten;
            return item;
        }
        private KhachHangModel GetDataFromForm()
        {
            var KhachHang = new KhachHangModel
            {
                Ten = txtKhachHang.Text,
                DiaChi = txtDiachi.Text,
                DienThoai = txtSodt.Text,
                Email = txtEmail.Text,
                Id = int.Parse(txtKhachHangId.Text)
            };
            return KhachHang;
        }
        private void DisplayData(KhachHang khachhang)
        {
            txtKhachHang.Text = khachhang.Ten;
            txtDiachi.Text = khachhang.DiaChi;
            txtSodt.Text = khachhang.DienThoai;
            txtEmail.Text = khachhang.Email;
            txtKhachHangId.Text = khachhang.Id.ToString();
        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            LoadData();
            btnGetAll.Visible = false;
        }
    }
}
