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

namespace Quanly_NhaSach.UI
{
    public partial class frmTracuuSach : Form
    {
        public frmTracuuSach()
        {
            InitializeComponent();
            LayDanhSachTacGia();
            LayDanhSachTheLoai();
           
        }
        Sach_Bus _busSach = new Sach_Bus();
        TacGia_Bus _busTacGia = new TacGia_Bus();
        TheLoai_Bus _busTheloai = new TheLoai_Bus();

        Sach _Sach = new Sach();


        List<TheLoai> dsTheLoai = new List<TheLoai>();
        List<TacGia> dsTacGia = new List<TacGia>();
        List<Sach> dsSach = new List<Sach>();

        private async void LayDanhSachTacGia()
        {
            dsTacGia =await _busTacGia.LayDanhsachTacGia();

            colTacgia.ValueMember = "Id";
            colTacgia.DisplayMember = "Ten";
            colTacgia.DataSource = dsTacGia;
        }
        private async void LayDanhSachTheLoai()
        {
            dsTheLoai= await _busTheloai.LayDanhsachTheLoai();

            ColTheLoai.ValueMember = "Id";
            ColTheLoai.DisplayMember = "Ten";
            ColTheLoai.DataSource = dsTheLoai;
        }
        private void ColumnOrder()
        {
            ColID.DisplayIndex = 0;
            ColTensach.DisplayIndex = 1;
            colSoluong.DisplayIndex = 2;
            colTacgia.DisplayIndex = 3;
            ColTheLoai.DisplayIndex = 4;

        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lbMessage.Text = "";
            var ThongtinModel = new ThongtinTimSachModel
            {
                TenSach = txtTenSach.Text,
                TenTacgia = txtTenTacgia.Text,
                Theloai = txtTheloai.Text,
            };

            Sach_Bus _bus = new Sach_Bus();
            var dsSach = await _bus.TimkiemSach(ThongtinModel);
            if (dsSach.Count > 0)
            {
                dgvSach.DataSource = dsSach;
                ColumnOrder();
                //ColTensach.Frozen = true;
            }
            else
            {
                lbMessage.Visible = true;
                lbMessage.Text = "Không tìm thấy thông tin Sách";
            }
        }
    }
}
