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
    public partial class frmKhachHangTimKiem : Form
    {
       

        public frmKhachHangTimKiem()
        {
            InitializeComponent();
        }
       public  List<KhachHang> KhachHangs = new List<KhachHang>();
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lbMessage.Text = "";
            var KhachHangSearch = new KhachHangModel
            {
                Ten = txtTen.Text,
                DiaChi = txtDiachi.Text,
                Email = txtEmail.Text,
                DienThoai = txtSodt.Text
            };

            KhachHang_Bus _bus = new KhachHang_Bus();
            var kq =await _bus.Timkiem(KhachHangSearch);
            if (kq.Count>0)
            {
                KhachHangs =  kq;
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
