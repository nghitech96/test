using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using WebAPI_QLNS.Models;

namespace Quanly_NhaSach.UI
{
    public partial class frmPhieuThuTien : Form
    {
        public frmPhieuThuTien()
        {

            InitializeComponent();
            dgvPhieuthu.Columns["ColTien"].DefaultCellStyle.Format = "N0";



        }
        KhachHang_Bus _busKhachhang = new KhachHang_Bus();
        PhieuThuTien_Bus _bus = new PhieuThuTien_Bus();


        List<KhachHang> dskhachhang = new List<KhachHang>();
        PhieuThuTien _PhieuThuTien = new PhieuThuTien();

        List<PhieuThuTien> dsPhieuThuTien = new List<PhieuThuTien>();

        BindingList<PhieuThuTien> bdPhieuThuTien = new BindingList<PhieuThuTien>();

        long _CongnoKhachHang = 0;
        private async void frmPhieuThuTien_Load(object sender, EventArgs e)
        {

            LayDanhKhachHang();


        }
        private async void LoadData()
        {
            dsPhieuThuTien = await _bus.LayDanhsachPhieuThuTien();

            bdPhieuThuTien = new BindingList<PhieuThuTien>(dsPhieuThuTien);


            dgvPhieuthu.DataSource = bdPhieuThuTien;


        }

        private async void LayDanhKhachHang()
        {
            dskhachhang = await _busKhachhang.LayDanhsachKhachHang();


            cbKhachHang.ValueMember = "Id";
            cbKhachHang.DisplayMember = "Ten";
            cbKhachHang.DataSource = dskhachhang;


            ColTenKH.ValueMember = "Id";
            ColTenKH.DisplayMember = "Ten";
            ColTenKH.DataSource = dskhachhang;

            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            var frmSearch = new UI.frmPhieuThuTien_TimKiem();
            frmSearch.Owner = this;
            frmSearch.StartPosition = FormStartPosition.CenterParent;
            DialogResult dialogResult = frmSearch.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dsPhieuThuTien = frmSearch.phieuThuTiens;
                bdPhieuThuTien = new BindingList<PhieuThuTien>(dsPhieuThuTien);

                if (dsPhieuThuTien == null)
                {
                    return;
                }
                if (dsPhieuThuTien.Count <= 0)
                {
                    return;
                }
                dgvPhieuthu.DataSource = dsPhieuThuTien;
                btnGetAll.Visible = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var item = GetDataCurrentfromGridView(dgvPhieuthu);
                if (item == null)
                {
                    return;
                }
                DialogResult dialog = MessageBox.Show($"Bạn muốn xóa phiếu:{item.Id}, ngày {item.Ngay}", "Xóa", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.No)
                {
                    return;
                }
                var itemModel = new PhieuThuTienModel();

                _bus.Map(item, ref itemModel);

                var kq = await _bus.XoaPhieuThuTien(itemModel.Id);
                if (kq.Count > 0)
                {
                    bdPhieuThuTien.Remove(item);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "LỖi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            var PhieuThuTienModel = GetDataFromForm();
            try
            {
                //PhieuThuTienModel.Id = "0";
                var kq = await _bus.ThemPhieuThuTien(PhieuThuTienModel);
                var bdchitietPhieu = (BindingList<PhieuThuTien>)dgvPhieuthu.DataSource;
                if (kq.Count > 0)
                {

                    var item = new PhieuThuTien();
                    _bus.Map(PhieuThuTienModel, ref item);

                    bdPhieuThuTien.Add(item);

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
                if (dgvPhieuthu.CurrentRow == null)
                    return;
                if (dgvPhieuthu.CurrentRow.DataBoundItem == null)
                    return;
                var index = dgvPhieuthu.CurrentRow.Index;


                var item = (PhieuThuTien)dgvPhieuthu.CurrentRow.DataBoundItem;
                var data = GetDataFromForm();

                data.Id = item.Id;

                var kq = await _bus.CapnhatPhieuThuTien(data);


                if (kq.Count > 0)
                {
                    Map(data, ref item);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "LỖi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvPhieuThuTien_SelectionChanged(object sender, EventArgs e)
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

        }
        private void dgvPhieuthu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grd = (DataGridView)sender;
            if (grd.CurrentRow == null)
            {
                return;
            }
            var selectRow = grd.CurrentRow.DataBoundItem;
            if (selectRow != null)
            {
                // var name = grd.Columns[e.ColumnIndex].Name;



            }
        }
        private PhieuThuTien GetDataCurrentfromGridView(DataGridView dgv)
        {

            var item = (PhieuThuTien)dgv.CurrentRow.DataBoundItem;
            //txtPhieuThuTien.Text = item.Ten;
            return item;
        }
        private void Map(PhieuThuTienModel so, ref PhieuThuTien dst)
        {
            dst.Id = so.Id;
            dst.Ngay = so.Ngay;
            dst.Tien = so.Tien;
            dst.IdKhachHang = so.IdKhachHang;
        }
        private PhieuThuTienModel GetDataFromForm()
        {
            var PhieuThuTien = new PhieuThuTienModel();
            string idkh = "0";
            try
            {

                if (cbKhachHang.SelectedValue == null)
                {
                    throw new Exception("Bạn chưa chọn khách hàng");
                }

                idkh = cbKhachHang.SelectedValue.ToString();

                PhieuThuTien = new PhieuThuTienModel
                {
                    Id = txtPhieuThuTien.Text,
                    IdKhachHang = int.Parse(idkh),
                    Tien = int.Parse(txtTongTien.Text),
                    Ngay = dateTimePicker1.Value
                };

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return PhieuThuTien;
        }
        private void DisplayData(PhieuThuTien phieu)
        {
            txtPhieuThuTien.Text = phieu.Id;
            txtOldMaHD.Text = phieu.Id;
            dateTimePicker1.Value = phieu.Ngay;
            cbKhachHang.SelectedValue = phieu.IdKhachHang;
            txtTongTien.Text = phieu.Tien.ToString();
        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            LoadData();
            btnGetAll.Visible = false;
        }



        private void txtPhieuThuTienId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhieuThuTienId_Leave(object sender, EventArgs e)
        {

        }

        private void dgvPhieuthu_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentRow == null)
                return;

            var phieuthu = (PhieuThuTien)dgv.CurrentRow.DataBoundItem;
            DisplayData(phieuthu);
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            try
            {


                var tien = ((TextBox)sender).Text.Trim();

                if (long.Parse(tien)>_CongnoKhachHang)
                {
                    throw new Exception($"Tiền thu khách hàng không lớn hơn Tiền khách đang nợ (Nợ : {_CongnoKhachHang})");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private async void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBox)sender;
            var item = (KhachHang)cb.SelectedItem;
            ResponseModel res = await _bus.LayCongnoKHachHang(item.Id);

            _CongnoKhachHang = long.Parse(res.data.ToString());
           // txtTongTien.Text = _CongnoKhachHang.ToString();
        }
    }
}
