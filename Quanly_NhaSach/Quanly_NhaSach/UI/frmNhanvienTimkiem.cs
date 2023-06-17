using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
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
    public partial class frmNhanvienTimkiem : Form
    {
       

        public frmNhanvienTimkiem()
        {
            InitializeComponent();
        }
       public  List<NhanVien> nhanviens = new List<NhanVien>();
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lbMessage.Text = "";
            var nhanvienSearch = new NhanVienModel
            {
                TenNhanVien = txtTen.Text,
                Email = txtEmail.Text,
                SoDT = txtSodt.Text
            };

            NhanVien_Bus _bus = new NhanVien_Bus();
            var kq =await _bus.TimKiem(nhanvienSearch);
            if (kq.Count>0)
            {
                nhanviens =  kq;
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
