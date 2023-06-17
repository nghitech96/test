using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Helpers;
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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnDangnhap_Click(object sender, EventArgs e)
        {
            var taikhoan = new AccountModel
            {
                UserName = txtTaikhoan.Text,
                Password = txtMatkhau.Text
            };
            lbMessage.Visible = false;
            NguoiDung_Bus _bus = new NguoiDung_Bus();
            
            var response = await _bus.DangNhap(taikhoan.UserName, taikhoan.Password);
            if (response.Count > 0)
            {
                Common.isLogin = true;
                Common.Token = response.data.ToString();
                Common.Nguoidung = await _bus.LayThongtinNguoiDungDangnhap(int.Parse(response.Id));
                
                this.Close();
            }
            else
            {
                lbMessage.Text = response.data.ToString();
                lbMessage.Visible = true;
                Common.isLogin = false;
                
            }

        }

        
    }
}
