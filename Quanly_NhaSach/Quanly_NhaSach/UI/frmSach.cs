using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WebAPI_QLNS.Models;

namespace Quanly_NhaSach.UI
{
    public partial class frmSach : Form
    {
        public frmSach()
        {
           
            InitializeComponent();
           
           
        }

        Sach_Bus _busSach = new Sach_Bus();
        TacGia_Bus _busTacGia = new TacGia_Bus();
        TheLoai_Bus _busTheloai = new TheLoai_Bus();

        Sach _Sach = new Sach();


        List<TheLoai> dsTheLoai = new List<TheLoai>();
        List<TacGia> dsTacGia = new List<TacGia>();
        List<Sach> dsSach = new List<Sach>();
        
        BindingList<Sach> lstSach = new BindingList<Sach>();

        //BindingList<Sach> dsSachBDL = new BindingList<Sach>();
       // BindingSource dsSachBS {get ; set; }
       // BindingSource dsNhanVienBS {get ; set; }
        private async void frmSach_Load(object sender, EventArgs e)
        {
            LoadTheLoai();

            LoadTacGia();
            Thread.Sleep(50);
            LoadData();
            
          //  txtSach.DataBindings.Add("Text", _Sach.Ten, "Ten", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private async void LoadData()
        {
            dsSach = await _busSach.LayDanhsachSach();

            lstSach =new BindingList<Sach>(dsSach);

            //dsSachBS = new BindingSource
            //{
            //    DataSource = lstSach
            //};

            if (dsSach.Count > 0)
            {
                _Sach = dsSach[0];
            }
            else
            {
                _Sach = new Sach
                {
                    Ten = ""
                };

            }

            dgvSach.DataSource = lstSach;
            OrderColumnGridView();

        }
        private async void LoadTheLoai()
        {
            dsTheLoai = await _busTheloai.LayDanhsachTheLoai();


            cbTheloai.ValueMember = "Id";
            cbTheloai.DisplayMember = "Ten";
            cbTheloai.DataSource = dsTheLoai;

            ColTheLoai.ValueMember = "Id";
            ColTheLoai.DisplayMember = "Ten";
            ColTheLoai.DataSource = dsTheLoai;
        }

            private async void LoadTacGia()
        {
            dsTacGia = await _busTacGia.LayDanhsachTacGia();

            cbTacgia.ValueMember = "Id";
            cbTacgia.DisplayMember = "Ten";
            cbTacgia.DataSource = dsTacGia;

            colTacgia.ValueMember = "Id";
            colTacgia.DisplayMember = "Ten";
            colTacgia.DataSource = dsTacGia;

        }
        private void OrderColumnGridView()
        {
            dgvSach.Columns["ColID"].DisplayIndex = 0;
            dgvSach.Columns["ColTenSach"].DisplayIndex = 1;
            dgvSach.Columns["colSoluong"].DisplayIndex = 2;
            dgvSach.Columns["colTacGia"].DisplayIndex = 3;
            dgvSach.Columns["colTheloai"].DisplayIndex = 4;
        }
        void Map(SachModel so,ref Sach dst)
        {
            dst.IdTacGia = so.IdTacGia;
            dst.Id = so.Id;
            dst.IdTheLoai = so.IdTheLoai;
            dst.Ten = so.Ten;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            var frmSearch = new UI.frmSachTimkiem();
            frmSearch.Owner = this;
            frmSearch.StartPosition= FormStartPosition.CenterParent;
            DialogResult dialogResult = frmSearch.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dsSach = frmSearch.dsSach;
                //dsSachBS.DataSource = dsSach;
                lstSach =new BindingList<Sach>(dsSach);
                if (dsSach == null)
                {
                    return;
                }
                if (dsSach.Count<=0)
                {
                    return;
                }
                dgvSach.DataSource = lstSach;

                btnGetAll.Visible = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var item = GetDataCurrentfromGridView(dgvSach);
            if (item==null)
            {
                return;
            }
            DialogResult dialog = MessageBox.Show($"Bạn muốn xóa :{item.Ten}", "Xóa", MessageBoxButtons.YesNo);
            if (dialog==DialogResult.No)
            {
                return;
            }
            //dsSachBS.Remove(item);
            var response = await _busSach.XoaSach(item.Id);
            if (response.Count > 0)
            {
                //dsSachBS.Remove(item);
                lstSach.Remove(item);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            var SachModel = GetDataFromForm();
            SachModel.Id = 0;
            SachModel.SoluongTon = 0;
            var kq = await _busSach.ThemSach(SachModel);
            if (kq.Count>0)
            {
                var item = new Sach();
                _busSach.Map(SachModel, ref item);

                item.Id = int.Parse(kq.Id);
                
                //dsSachBS.Add(item);
                lstSach.Add(item);
            }
            //dgvSach.Refresh();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            //dsSachBS.
            if (dgvSach.CurrentRow == null)
                return;
            if (dgvSach.CurrentRow.DataBoundItem == null)
                return;

            var item = (Sach)dgvSach.CurrentRow.DataBoundItem;
            //var item = GetDataCurrentfromGridView(dgvSach);
            var data = GetDataFromForm();
            data.Id = item.Id;

            var kq = await _busSach.CapnhatSach(data);
            if (kq.Count>0)
            {
                //lstSach.
               Map(data, ref item);
                
                dgvSach.Refresh();
            }
           
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentRow == null)
                return;
            if (dg.CurrentRow.DataBoundItem == null)
                return;
            var item = GetDataCurrentfromGridView(dg);
           DisplayData(item);
            
        }
        private Sach GetDataCurrentfromGridView(DataGridView dgv)
        {
            
            var item = (Sach)dgv.CurrentRow.DataBoundItem;
            //txtSach.Text = item.Ten;
            return item;
        }
        private SachModel GetDataFromForm()
        {
            var Sach = new SachModel
            {
                Id = int.Parse(txtSachId.Text),
                Ten = txtTenSach.Text,
                SoluongTon =int.Parse( txtSoluongTon.Text),
                
                IdTacGia=int.Parse(cbTacgia.SelectedValue.ToString()),
                IdTheLoai =int.Parse(cbTheloai.SelectedValue.ToString())
                
            };
            return Sach;
        }
        private void DisplayData(Sach sach)
        {

            txtSachId.Text = sach.Id.ToString();
            txtTenSach.Text= sach.Ten;
            txtSoluongTon.Text = sach.SoluongTon.ToString();

            cbTheloai.SelectedValue = sach.IdTheLoai;
            cbTacgia.SelectedValue = sach.IdTacGia;
        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            LoadData();
           // btnGetAll.Visible = false;
        }

        
    }
}
