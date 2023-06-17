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
    public partial class frmNguoidungTimkiem : Form
    {
       

        public frmNguoidungTimkiem()
        {
            InitializeComponent();
        }

       public  List<NguoiDungDangnhap> NguoiDungs = new List<NguoiDungDangnhap>();
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lbMessage.Text = "";
            var NguoidungSearch = new NguoiDungDangnhapModel
            {
                TaiKhoan = txtTaikhoan.Text,
                TenNhanVien = txtTen.Text,
                Email = txtEmail.Text,
                SoDT = txtSodt.Text
            };

            NguoiDung_Bus _bus = new NguoiDung_Bus();
            var kq =await _bus.TimNguoiDung(NguoidungSearch);
            if (kq.Count>0)
            {
                NguoiDungs =  kq;
                this.DialogResult = DialogResult.OK;
                this.Close();   
            }
            else
            {
                lbMessage.Visible = true;
                lbMessage.Text = "Không tìm thấy thông tin nhân viên";
            }
        }
        
    }
}
