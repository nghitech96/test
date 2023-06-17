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
    public partial class frmHoaDonTimKiem : Form
    {
       

        public frmHoaDonTimKiem()
        {
            InitializeComponent();
        }
       public  List<HoaDonBanHang> hoaDonBanHangs = new List<HoaDonBanHang>();
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lbMessage.Text = "";
            var HoaDonBanHangSearch = new ThongtinTimHoaDonModel
            {
                MaHD = txtMaHD.Text.Trim(),
               Ten = txtTen.Text.Trim(),
                DiaChi = txtDiachi.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DienThoai = txtSodt.Text.Trim() 
            };

            HoaDonBanHang_Bus _bus = new HoaDonBanHang_Bus();
            var kq =await _bus.TimHoaDonBanHang(HoaDonBanHangSearch);
            if (kq.Count>0)
            {
                hoaDonBanHangs =  kq;
                this.DialogResult = DialogResult.OK;
                this.Close();   
            }
            else
            {
                lbMessage.Visible = true;
                lbMessage.Text = "Không tìm thấy thông tin khách hàng";
            }
        }
        
    }
}
