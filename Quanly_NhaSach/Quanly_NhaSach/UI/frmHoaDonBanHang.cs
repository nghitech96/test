using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebAPI_QLNS.Models;

namespace Quanly_NhaSach.UI
{
    public partial class frmHoaDonBanHang : Form
    {
        KhachHang_Bus _busKhachhang = new KhachHang_Bus();
        Sach_Bus _busSach = new Sach_Bus();


        HoaDonBanHang_Bus _bus = new HoaDonBanHang_Bus();
        ChiTietHoaDon_Bus _busChiTietHoaDon = new ChiTietHoaDon_Bus();



        List<Sach> dsSach = new List<Sach>();
        List<KhachHang> dskhachhang = new List<KhachHang>();

        HoaDonBanHang _HoaDonBanHang = new HoaDonBanHang();

        List<HoaDonBanHang> dsHoaDonBanHang = new List<HoaDonBanHang>();

        List<ChiTietHoaDon> dsChiTietHoaDon = new List<ChiTietHoaDon>();
        List<ChiTietHoaDon> _dsChiTietHoaDonDel = new List<ChiTietHoaDon>();


        BindingList<ChiTietHoaDon> bdChiTietHoaDon = new BindingList<ChiTietHoaDon>();
        BindingList<HoaDonBanHang> bdHoaDonBanHang = new BindingList<HoaDonBanHang>();

        long _soluongTon = 0;
        long _oldSoluong = 0;
        public frmHoaDonBanHang()
        {

            InitializeComponent();
           dgvChiTiet.Columns["ColSoluong"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ColDonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ColTien"].DefaultCellStyle.Format = "N0";

           dgvHoaDonBanHang.Columns["ColTongTien"].DefaultCellStyle.Format = "N0";

            
        }
       
        private async void frmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            OrderColum();

            LayDanhKhachHang();
            LayDanhsachSach();
          

        }
        private async void LoadData()
        {
            dsHoaDonBanHang = await _bus.LayDanhsachHoaDonBanHang();

            bdHoaDonBanHang = new BindingList<HoaDonBanHang>(dsHoaDonBanHang);


            dgvHoaDonBanHang.DataSource = bdHoaDonBanHang;

            if (dsHoaDonBanHang.Count > 0)
            {
                _HoaDonBanHang = dsHoaDonBanHang[0];
                LayChitietHoaDon(_HoaDonBanHang.Id);
            }
            else
            {
                LayChitietHoaDon("0");
            }

            
        }
        private void OrderColum()
        {
            dgvChiTiet.Columns["ColIDPhieu"].DisplayIndex = 6;
            dgvChiTiet.Columns["ColMaHD"].DisplayIndex = 5;
            dgvChiTiet.Columns["ColTien"].DisplayIndex = 4;
            dgvChiTiet.Columns["ColSoluong"].DisplayIndex = 3;
            dgvChiTiet.Columns["ColDonGia"].DisplayIndex = 2;
            dgvChiTiet.Columns["ColTenSach"].DisplayIndex = 1;
            dgvChiTiet.Columns["ColStt"].DisplayIndex = 0;

        }
        private async void LayChitietHoaDon(string PhieuNhapId)
        {
            dsChiTietHoaDon = await _busChiTietHoaDon.LayDanhsachChiTietHoaDon(PhieuNhapId);

            bdChiTietHoaDon = new BindingList<ChiTietHoaDon>(dsChiTietHoaDon);


            dgvChiTiet.DataSource = bdChiTietHoaDon;
            long sum = 0;

            if (bdChiTietHoaDon.Count == 0)
            {
                dateTimePicker1.Value = DateTime.Now;
                cbKhachHang.SelectedValue = 0;
            }
            else
            {
                sum = bdChiTietHoaDon.Sum(x => x.TTien);
            }
            DanhsoTT();

            txtTongTien.Text = sum.ToString();
            txtTongTien.Text = string.Format("{0:#,##0}", double.Parse(txtTongTien.Text));

        }
        private async void LayDanhsachSach()
        {
            dsSach = await _busSach.LayDanhsachSach();


            ColTenSach.ValueMember = "Id";
            ColTenSach.DisplayMember = "Ten";
            ColTenSach.DataSource = dsSach;



            LoadData();

        }
        private async void LayDanhKhachHang()
        {
            dskhachhang = await _busKhachhang.LayDanhsachKhachHang();


            cbKhachHang.ValueMember = "Id";
            cbKhachHang.DisplayMember = "Ten";
            cbKhachHang.DataSource = dskhachhang;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            var frmSearch = new UI.frmHoaDonTimKiem();
            frmSearch.Owner = this;
            frmSearch.StartPosition = FormStartPosition.CenterParent;
            DialogResult dialogResult = frmSearch.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dsHoaDonBanHang = frmSearch.hoaDonBanHangs;
                bdHoaDonBanHang = new BindingList<HoaDonBanHang>(dsHoaDonBanHang);

                if (dsHoaDonBanHang == null)
                {
                    return;
                }
                if (dsHoaDonBanHang.Count <= 0)
                {
                    return;
                }
                dgvHoaDonBanHang.DataSource = dsHoaDonBanHang;
                btnGetAll.Visible = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var item = GetDataCurrentfromGridView(dgvHoaDonBanHang);
                if (item == null)
                {
                    return;
                }
                DialogResult dialog = MessageBox.Show($"Bạn muốn xóa phiếu:{item.Id}, ngày {item.Ngay}", "Xóa", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.No)
                {
                    return;
                }
                var bddschitiet = (BindingList<ChiTietHoaDon>)dgvChiTiet.DataSource;
                var dsCHitieet = bddschitiet.ToList();
                List<ChiTietHoaDonModel> chitietModels = new List<ChiTietHoaDonModel>();

                _busChiTietHoaDon.Map(dsCHitieet, ref chitietModels);

                foreach (var chitiet1 in chitietModels)
                {
                    var res1 = await _busChiTietHoaDon.XoaChiTietHoaDon(chitiet1);
                }

                var response = await _bus.XoaHoaDonBanHang(item.Id);
                if (response.Count > 0)
                {
                    dsHoaDonBanHang.Remove(item);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "LỖi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            var HoaDonBanHangModel = GetDataFromForm();
            try
            {
                //HoaDonBanHangModel.Id = "0";
                var kq = await _bus.ThemHoaDonBanHang(HoaDonBanHangModel);
                var bdchitietPhieu = (BindingList<ChiTietHoaDon>)dgvChiTiet.DataSource;
                if (kq.Count > 0)
                {
                    List<ChiTietHoaDonModel> chitietModel = new List<ChiTietHoaDonModel>();
                    var chitietPhieu = bdchitietPhieu.ToList();

                    _busChiTietHoaDon.Map(chitietPhieu, ref chitietModel);
                    foreach (var item1 in chitietModel)
                    {
                        var res = await _busChiTietHoaDon.CapnhatChiTietHoaDon(item1);
                    }
                    var item = new HoaDonBanHang();
                    _bus.Map(HoaDonBanHangModel, ref item);
                    bdHoaDonBanHang.Add(item);

                    _dsChiTietHoaDonDel.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "LỖi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDonBanHang.CurrentRow == null)
                    return;
                if (dgvHoaDonBanHang.CurrentRow.DataBoundItem == null)
                    return;
                var index = dgvHoaDonBanHang.CurrentRow.Index;


                var item = (HoaDonBanHang)dgvHoaDonBanHang.CurrentRow.DataBoundItem;
                var data = GetDataFromForm();

                data.Id = item.Id;

                var kq = await _bus.CapnhatHoaDonBanHang(data);

                var bdchitietHD = (BindingList<ChiTietHoaDon>)dgvChiTiet.DataSource;


                if (kq.Count > 0)
                {
                    Map(data, ref item);

                    List<ChiTietHoaDonModel> chitietModel = new List<ChiTietHoaDonModel>();

                    // Xóa các record đã xóa tạm trong  _dsChiTietHoaDonDel

                    _busChiTietHoaDon.Map(_dsChiTietHoaDonDel, ref chitietModel);

                    foreach (var itemDel in chitietModel)
                    {
                        var kq1 = _busChiTietHoaDon.XoaChiTietHoaDon(itemDel);
                    }

                    _dsChiTietHoaDonDel.Clear();
                    // Cập nhật dữ liệu chi tiết hóa đơn từ Gridview Chi tiết
                    var dschitietHD = bdchitietHD.ToList();

                    chitietModel = new List<ChiTietHoaDonModel>();
                    _busChiTietHoaDon.Map(dschitietHD, ref chitietModel);

                    foreach (var chitiet1 in chitietModel)
                    {
                        var res = await _busChiTietHoaDon.CapnhatChiTietHoaDon(chitiet1);
                        if (res.ResultCode < 0)
                        {
                            throw new Exception(res.Message);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "LỖi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvHoaDonBanHang_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentRow == null)
                return;
            if (dg.CurrentRow.DataBoundItem == null)
                return;
            var item = GetDataCurrentfromGridView(dg);
            DisplayData(item);
        }

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grd = (DataGridView)sender;
            if (grd.CurrentRow == null)
            {
                return;
            }
            if (grd.CurrentRow.DataBoundItem != null)
            {
                var row = (ChiTietHoaDon) grd.CurrentRow.DataBoundItem;
                // var name = grd.Columns[e.ColumnIndex].Name;
                if (grd.Columns[e.ColumnIndex].Name == "ColSoluong")
                {
                    if (row.SoLuong> _soluongTon)
                    {
                        row.SoLuong = _oldSoluong;
                        MessageBox.Show($"Số lượng bán không được lớn hơn số lượng tồn {_soluongTon}");
                    }
                }    
                if (grd.Columns[e.ColumnIndex].Name == "ColSoluong" || grd.Columns[e.ColumnIndex].Name == "ColDonGia" || grd.Columns[e.ColumnIndex].Name == "ColTien")
                {

                    var sum = bdChiTietHoaDon.Sum(x => x.TTien);

                    txtTongTien.Text = sum.ToString();
                }

            }
        }
        private HoaDonBanHang GetDataCurrentfromGridView(DataGridView dgv)
        {

            var item = (HoaDonBanHang)dgv.CurrentRow.DataBoundItem;
            //txtHoaDonBanHang.Text = item.Ten;
            return item;
        }
        private void Map(HoaDonBanHangModel so, ref HoaDonBanHang dst)
        {
            dst.Id = so.Id;
            dst.Ngay = so.Ngay;
            dst.ThanhTien = so.ThanhTien;
            dst.IdKhachHang = so.IdKhachHang;
        }
       
        private HoaDonBanHangModel GetDataFromForm()
        {
            var HoaDonBanHang = new HoaDonBanHangModel();
            string idkh = "0";
            try
            {

                if (cbKhachHang.SelectedValue == null)
                {
                    throw new Exception("Bạn chưa chọn khách hàng");
                }

                idkh = cbKhachHang.SelectedValue.ToString();

                HoaDonBanHang = new HoaDonBanHangModel
                {
                    Id = txtHoaDonBanHangId.Text,
                    IdKhachHang = int.Parse(idkh),
                    ThanhTien = int.Parse(txtTongTien.Text),
                    Ngay = dateTimePicker1.Value
                };

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return HoaDonBanHang;
        }
        private void DisplayData(HoaDonBanHang hoadon)
        {
            txtHoaDonBanHangId.Text = hoadon.Id;
            txtOldMaHD.Text = hoadon.Id;
            dateTimePicker1.Value = hoadon.Ngay;
            cbKhachHang.SelectedValue = hoadon.IdKhachHang;
            txtTongTien.Text = hoadon.ThanhTien.ToString();
        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            LoadData();
            btnGetAll.Visible = false;
        }

        private void btnAddSach_Click(object sender, EventArgs e)
        {
            var mahd = txtHoaDonBanHangId.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(mahd))
                    throw new Exception("Bạn chưa nhập mã hóa đơn!");

                var dsChiTiet = (BindingList<ChiTietHoaDon>)dgvChiTiet.DataSource;
                var Item = dsChiTiet.AddNew();

                Item.IdHoaDon = mahd;
                Item.SoLuong = 1;
                Item.IdSach = 1;
                Item.DonGia = 1;
                DanhsoTT();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void DanhsoTT()
        {
            for (int i = 0; i <dgvChiTiet.Rows.Count; i++)
            {
                dgvChiTiet.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            var item = (ChiTietHoaDon)dgvChiTiet.CurrentRow.DataBoundItem;
            if (item == null)
            {
                return;
            }
            _dsChiTietHoaDonDel.Add(item);
            bdChiTietHoaDon.Remove(item);

        }
        private void txtHoaDonBanHangId_TextChanged(object sender, EventArgs e)
        {
            var idMaHD = ((TextBox)sender).Text.Trim();

            
            var oldMaHD = txtOldMaHD.Text.Trim();

            if (idMaHD != oldMaHD)
            {
                LayChitietHoaDon(idMaHD);

            }
        }

        private void txtHoaDonBanHangId_Leave(object sender, EventArgs e)
        {

        }
        private void dgvChiTiet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            DataGridViewRow dr = dgvChiTiet.CurrentRow;

            if (cb != null)
            {
                if (cb.Name != "ColTenSach")
                {
                    var sp = dsSach.Where(x => x.Id == (int)cb.SelectedValue).FirstOrDefault();


                    _soluongTon = sp.SoluongTon;
                   // dr.Cells["ColSoluong"].Value = _soluongTon;

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

        private void dgvChiTiet_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.CurrentRow == null)
            {
                return;
            }
            if (dgv.CurrentRow.DataBoundItem == null)
            {
                return;
            }

            var row =(ChiTietHoaDon) dgv.CurrentRow.DataBoundItem;
            _soluongTon = dsSach.FirstOrDefault(x => x.Id == row.IdSach).SoluongTon;
            _oldSoluong = row.SoLuong;


        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            Form frm = new UI.frmKhachHang();
            frm.Owner = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LayDanhKhachHang();
        }

        
    }
}
