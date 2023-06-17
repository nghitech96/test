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
    public partial class frmBaoCao_CongNoChiTiet : Form
    {
        public frmBaoCao_CongNoChiTiet()
        {
            InitializeComponent();
        }
        KhachHang_Bus _kh = new KhachHang_Bus();
        ThongkeBaoCao_Bus tkbao = new ThongkeBaoCao_Bus();


        List<KhachHang> dsKhachhang = new List<KhachHang>();
        
        BindingList<KhachHang> bdKhachhang = new BindingList<KhachHang>();

        ThongtinThongkeModel thongtin = new ThongtinThongkeModel();
        private void frmBaoCao_CongNoChiTiet_Load(object sender, EventArgs e)
        {
            //var dsThang =new List<int> { 1,2,3,4,5,6,7,8,9,10,11,12};
            //var nam = DateTime.Now.Year;
            //var dsNam = new List<int> {
            //    nam,nam-1,nam-2,nam-3,nam-4
            //};

            //cbThang.DataSource=dsThang;
            //cbNam.DataSource = dsNam;

            //LayDanhsachKhachhang();
        }
        private async void LayDanhsachKhachhang()
        {
            dsKhachhang = await _kh.LayDanhsachKhachHang();
            var item = new KhachHang
            {
                Id = 0,
                Ten = "Tất cả"
            };
            dsKhachhang.Insert(0,item);
            bdKhachhang = new BindingList<KhachHang>(dsKhachhang);


            cbKhachHang.ValueMember = "Id";
            cbKhachHang.DisplayMember = "Ten";
            cbKhachHang.DataSource = bdKhachhang;


            ColKhachHang.ValueMember = "Id";
            ColKhachHang.DisplayMember = "Ten";
            ColKhachHang.DataSource = bdKhachhang;
        }

        private async void btnThongke_Click(object sender, EventArgs e)
        {
            thongtin = new ThongtinThongkeModel
            {
                Thang = cbThang.SelectedValue.ToInt32(),
                Nam =cbNam.SelectedValue.ToInt32(),
                Id = cbKhachHang.SelectedValue.ToInt32()
            };

            var kq = await tkbao.ThongkeBaocaoCongNo(thongtin);

            if (kq!=null)
            {
                DisplayData(kq);
            }

        }
        private void DisplayData(List<ThongKeCongNoTrongKy> data)
        {
           // txtDauky.Text=data.DauKy.ToString();
           //txtCuoiky.Text=data.CuoiKy.ToString();
           //txtTang.Text=data.Tang.ToString();
           //txtGiam.Text=data.Giam.ToString();

            dgvThongke.DataSource = data;

        }

        
    }
}
