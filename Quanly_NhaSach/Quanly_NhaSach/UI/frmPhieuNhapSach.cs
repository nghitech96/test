using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebAPI_QLNS.Models;

namespace Quanly_NhaSach.UI
{
    public partial class frmPhieuNhapSach : Form
    {
        public frmPhieuNhapSach()
        {
           
            InitializeComponent();
            dgvChiTiet.Columns["ColSoluong"].DefaultCellStyle.Format = "N0";
        }
        PhieuNhapSach_Bus _bus = new PhieuNhapSach_Bus();
        ChiTietNhapSach_Bus _busChitietNhapSach = new ChiTietNhapSach_Bus();

        Sach_Bus _busSach = new Sach_Bus();
        TheLoai_Bus _busLoai = new TheLoai_Bus();
        TacGia_Bus _busTg = new TacGia_Bus();

        ChiTietNhapSach _OldChitiet = new ChiTietNhapSach();

        PhieuNhapSach _PhieuNhapSach = new PhieuNhapSach();

        List<TheLoai> dsTheLoai = new List<TheLoai>();
        List<TacGia> dsTacGia = new List<TacGia>();
        List<Sach> dsSach = new List<Sach>();

        List<PhieuNhapSach> dsPhieuNhapSach = new List<PhieuNhapSach>();

        List<ChiTietNhapSach> dsChitietNhapsach = new List<ChiTietNhapSach>();
        List<ChiTietNhapSach> _dsChitietNhapsachDel = new List<ChiTietNhapSach>();
        
        BindingList<ChiTietNhapSach> bdChitietNhapSach = new BindingList<ChiTietNhapSach>();
        
        BindingList<PhieuNhapSach> bdPhieuNhapSach = new BindingList<PhieuNhapSach>();

        BindingList<Sach> bdSach = new BindingList<Sach>();

        BindingSource dsSachbs {get ; set; }

        //BindingSource dsPhieuNhapSachBS {get ; set; }

        BindingSource dsChitietbs { get; set; }
        long _OldSoluong = 0;
        long _SoluongTon = 0;
        int _OldRowIndex = 0;
        private void frmPhieuNhapSach_Load(object sender, EventArgs e)
        {
            //dgvChiTiet.DataSource= bdChitietNhapSach;

            //dgvPhieuNhapSach.DataSource = bdPhieuNhapSach;
            //LoadTemp();
            LayDanhsachSach();

           


        }
       
        private async void LoadData()
        {
            dsPhieuNhapSach = await _bus.LayDanhsachPhieuNhapSach();

            bdPhieuNhapSach=new BindingList<PhieuNhapSach>(dsPhieuNhapSach);

            //dsPhieuNhapSachBS = new BindingSource
            //{
            //    DataSource = bdPhieuNhapSach
            //};

           // dgvChiTiet.DataSource = bdChitietNhapSach;

            dgvPhieuNhapSach.DataSource = bdPhieuNhapSach;

            if (dsPhieuNhapSach.Count > 0)
            {
                _PhieuNhapSach = dsPhieuNhapSach[0];
                LayChitietPhieuNhap(_PhieuNhapSach.Id);
            }
            else
            {
                dgvChiTiet.DataSource = bdChitietNhapSach;
            }


        }
        private async void LayChitietPhieuNhap(string PhieuNhapId)
        {
            dsChitietNhapsach =await _busChitietNhapSach.LayDanhsachChiTietNhapSach(PhieuNhapId);

            bdChitietNhapSach = new BindingList<ChiTietNhapSach>(dsChitietNhapsach);
            
            //dsChitietbs = new BindingSource { DataSource = bdChitietNhapSach };

            
            dgvChiTiet.DataSource = bdChitietNhapSach;

        }
        private async void LayDanhsachTheLoai()
        {
            dsTheLoai = await _busLoai.LayDanhsachTheLoai();

            ColTenSach.ValueMember = "Id";
            ColTenSach.DisplayMember = "Ten";
            ColTenSach.DataSource = dsTheLoai;
        }
        private async void LayDanhsachTacGia()
        {
            dsTacGia = await _busTg.LayDanhsachTacGia();

            ColTenSach.ValueMember = "Id";
            ColTenSach.DisplayMember = "Ten";
            ColTenSach.DataSource = dsTheLoai;
        }
        private async void LayDanhsachSach()
        {
            dsSach =await _busSach.LayDanhsachSach();

          

            bdSach =new BindingList<Sach>(dsSach);

           // dsSachbs = new BindingSource { DataSource = bdSach };

            ColTenSach.ValueMember = "Id";
            ColTenSach.DisplayMember = "Ten";
            ColTenSach.DataSource = dsSach;


            //comboBox1.ValueMember = "Id";
            //comboBox1.DisplayMember = "Ten";
            //comboBox1.DataSource = dsSach;
            LoadData();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddSach_Click(object sender, EventArgs e)
        {
            string mess = null;
            try
            {
                var idPhieu = txtPhieuNhapSachId.Text.Trim();
                if (string.IsNullOrEmpty(idPhieu))
                {
                    throw new Exception("Bạn phải nhập mã phiếu trước");
                }
                var dsChiTiet = (BindingList<ChiTietNhapSach>)dgvChiTiet.DataSource;
                var Item = dsChiTiet.AddNew();
                Item.IdPhieuNhap = idPhieu;
                Item.SoLuong = 1;
                Item.IdSach = 1;


            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,"LỖi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            //var frmSearch = new UI.frmSachTimkiem();
            //frmSearch.Owner = this;
            //frmSearch.StartPosition= FormStartPosition.CenterParent;
            //DialogResult dialogResult = frmSearch.ShowDialog();
            //if (dialogResult == DialogResult.OK)
            //{
            //    dsPhieuNhapSach = frmSearch.dsSach;
            //    dsPhieuNhapSachBS.DataSource = dsPhieuNhapSach;

            //    if (dsPhieuNhapSach == null)
            //    {
            //        return;
            //    }
            //    if (dsPhieuNhapSach.Count <= 0)
            //    {
            //        return;
            //    }
            //    dgvPhieuNhapSach.DataSource = dsPhieuNhapSach;
            //    btnGetAll.Visible = true;
            //}
        }
        
        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null)
                return;
            
            var item = (ChiTietNhapSach)dgvChiTiet.CurrentRow.DataBoundItem;
            if (item == null)
            {
                return;
            }
            _dsChitietNhapsachDel.Add(item);
            bdChitietNhapSach.Remove(item);

        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var item = GetDataCurrentfromGridView(dgvPhieuNhapSach);
            if (item == null)
            {
                return;
            }
            DialogResult dialog = MessageBox.Show($"Bạn muốn xóa phiếu:{item.Id}, ngày {item.Ngay}", "Xóa", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                return;
            }
            var dbdschitiet = (BindingList<ChiTietNhapSach>)dgvChiTiet.DataSource;

            List<ChiTietNhapSachModel> chitietModels = new List<ChiTietNhapSachModel>();

            List<ChiTietNhapSach> dschitiet = dbdschitiet.ToList();

            _busChitietNhapSach.Map(dschitiet,ref chitietModels);
            
            foreach (var chitiet1 in chitietModels)
            {
                var res1 = await _busChitietNhapSach.XoaChiTietNhapSach(chitiet1);
            }
            

            //dsPhieuNhapSachBS.Remove(item);
            var response = await _bus.XoaPhieuNhapSach(item.Id);
            if (response.Count > 0)
            {
                bdPhieuNhapSach.Remove(item);
                bdChitietNhapSach.Clear();
            }

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            var PhieuNhapSachModel = GetDataFromForm();
            //PhieuNhapSachModel.Id = "0";
            var kq = await _bus.ThemPhieuNhapSach(PhieuNhapSachModel);
            var  bdchitietPhieu = (BindingList<ChiTietNhapSach>)dgvChiTiet.DataSource;
            if (kq.Count > 0)
            {
                var chitietPhieu = bdchitietPhieu.ToList();
                List<ChiTietNhapSachModel> chitietModel = new List<ChiTietNhapSachModel>();

                _busChitietNhapSach.Map(chitietPhieu,ref chitietModel);
                foreach (var item1 in chitietModel)
                {
                    var res = await _busChitietNhapSach.CapnhatChiTietNhapSach(item1);
                    
                }
                var item = new PhieuNhapSach();
                _bus.Map(PhieuNhapSachModel, ref item);


                bdPhieuNhapSach.Add(item);


            }
            //dgvPhieuNhapSach.Refresh();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            //dsPhieuNhapSachBS.
            if (dgvPhieuNhapSach.CurrentRow == null)
                return;
            if (dgvPhieuNhapSach.CurrentRow.DataBoundItem == null)
                return;
            var index = dgvPhieuNhapSach.CurrentRow.Index;


            var item = (PhieuNhapSach)dgvPhieuNhapSach.CurrentRow.DataBoundItem;
           
            var data = GetDataFromForm();
            data.Id = item.Id;
            var kq = await _bus.CapnhatPhieuNhapSach(data);

            var bdchitietPhieu = (BindingList<ChiTietNhapSach>)dgvChiTiet.DataSource;
            var chitietPhieu = bdchitietPhieu.ToList();
            if (kq.Count > 0)
            {

                List<ChiTietNhapSachModel> dschitietNhapSachXoaModel = new List<ChiTietNhapSachModel>();
                _busChitietNhapSach.Map(_dsChitietNhapsachDel, ref dschitietNhapSachXoaModel);

                foreach (var itemDel in dschitietNhapSachXoaModel)
                {
                    var del = await _busChitietNhapSach.XoaChiTietNhapSach(itemDel);
                }
                List<ChiTietNhapSachModel> chitietModel = new List<ChiTietNhapSachModel>();
                _busChitietNhapSach.Map(chitietPhieu, ref chitietModel);
                foreach (var chitiet1 in chitietModel)
                {
                    var res = await _busChitietNhapSach.CapnhatChiTietNhapSach(chitiet1);

                }
               
                Map(data, ref item);

            }

        }

        private void dgvPhieuNhapSach_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentRow == null)
                return;
            if (dg.CurrentRow.DataBoundItem == null)
                return;
            var item = GetDataCurrentfromGridView(dg);
           DisplayData(item);
        }
        private PhieuNhapSach GetDataCurrentfromGridView(DataGridView dgv)
        {
            
            var item = (PhieuNhapSach)dgv.CurrentRow.DataBoundItem;
            return item;
        }
        private void Map(PhieuNhapSachModel so, ref PhieuNhapSach dst)
        {
            dst.Id = so.Id;
            dst.Ngay = so.Ngay;
        }
        private PhieuNhapSachModel GetDataFromForm()
        {
            var PhieuNhapSach = new PhieuNhapSachModel
            {
                Id=txtPhieuNhapSachId.Text,
                Ngay=dateTimePicker1.Value
            };
            return PhieuNhapSach;
        }
        private void DisplayData(PhieuNhapSach phieu)
        {
            txtPhieuNhapSachId.Text = phieu.Id;
           dateTimePicker1.Value = phieu.Ngay;
           // LayChitietPhieuNhap(phieu.Id);
        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            LoadData();
            btnGetAll.Visible = false;
        }

        private void txtPhieuNhapSachId_TextChanged(object sender, EventArgs e)
        {
            var idPhieu = ((TextBox)sender).Text.Trim();
            var oldIdPhieu = txtOldIdPhieu.Text.Trim();

            if (idPhieu!=oldIdPhieu)
            {
                LayChitietPhieuNhap(idPhieu);
            }
        }

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentRow == null)
            {
                return;
            }
            if (dgv.CurrentRow.DataBoundItem == null)
            {
                return;
            }
            var item = (ChiTietNhapSach)dgv.CurrentRow.DataBoundItem;
            //var rowIndex =  dgv.CurrentRow.Index;
            if (dgv.Columns[e.ColumnIndex].Name =="ColSoluong")
            {
                if (item.SoLuong<Common.QD1_1)
                {
                    item.SoLuong = _OldSoluong;
                    dgv.Rows[_OldRowIndex].Selected = true;
                    MessageBox.Show($"Bạn phải nhập số lượng theo quy định 1 : >= {Common.QD1_1}");
                    //item = _OldChitiet;
                   
                }
            }
        }

        private void dgvChiTiet_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentRow == null)
            {
                return;
            }
            if (dgv.CurrentRow.DataBoundItem == null)
            {
                return;
            }
            
            _OldRowIndex = dgv.CurrentRow.Index;
            if (dgv.Columns[e.ColumnIndex].Name == "ColSoluong")
            {
                _OldChitiet = (ChiTietNhapSach)dgv.CurrentRow.DataBoundItem;
                _SoluongTon = dsSach.FirstOrDefault(x => x.Id == _OldChitiet.IdSach).SoluongTon;
                _OldSoluong = _OldChitiet.SoLuong;
            }
        }
        private void dgvChiTiet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            DataGridViewRow dr = dgvChiTiet.CurrentRow;

            if (cb != null)
            {
                if (cb.Name != "ColTenSach")
                {
                    var sach = dsSach.Where(x => x.Id == (int)cb.SelectedValue).FirstOrDefault();


                    _SoluongTon = sach.SoluongTon;
                    
                    if (_SoluongTon>Common.QD1_2 && Common.QD4 == true )
                    {
                        MessageBox.Show($"Số lượng đầu sách còn nhiều, không được nhập (Tồn: {_SoluongTon} > QĐ: {Common.QD1_2} )");
                        
                    }

                }
            }
        }

        private void dgvChiTiet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox cb = (ComboBox)e.Control;
                if (cb != null)
                {
                    // Show the DropDown of the combo & set its event
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;

                    cb.SelectionChangeCommitted -= dgvChiTiet_SelectionChangeCommitted;
                    cb.SelectionChangeCommitted += dgvChiTiet_SelectionChangeCommitted;
                }
            }
        }
    }
}
