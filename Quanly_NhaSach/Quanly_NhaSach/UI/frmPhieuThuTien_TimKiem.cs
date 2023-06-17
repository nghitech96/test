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
    public partial class frmPhieuThuTien_TimKiem : Form
    {
       

        public frmPhieuThuTien_TimKiem()
        {
            InitializeComponent();
        }
       public  List<PhieuThuTien> phieuThuTiens = new List<PhieuThuTien>();
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lbMessage.Text = "";
            var PhieuThuTienSearch = new ThongtinTimPhieuThuModel
            {
                //MaPhieu = txtMaHD.Text.Trim(),
                //Ten = txtTen.Text.Trim(),
                //DiaChi = txtDiachi.Text.Trim(),
                //Email = txtEmail.Text.Trim(),
                //DienThoai = txtSodt.Text.Trim() 
                MaPhieu = txtMaPH.Text,
                Ten = txtTenKH.Text,
                DiaChi = txtDiachi.Text,
                Email = txtEmail.Text,
                DienThoai = txtSodt.Text
            };

            PhieuThuTien_Bus _bus = new PhieuThuTien_Bus();
            var kq = await _bus.TimPhieuThuTien(PhieuThuTienSearch);
            if (kq.Count>0)
            {
                phieuThuTiens =  kq;
                this.DialogResult = DialogResult.OK;
                this.Close();   
            }
            else
            {
                lbMessage.Visible = true;
                lbMessage.Text = "Không tìm thấy thông tin";
            }
        }
        
    }
}
