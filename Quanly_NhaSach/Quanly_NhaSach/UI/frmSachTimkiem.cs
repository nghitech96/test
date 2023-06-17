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
    public partial class frmSachTimkiem : Form
    {
       

        public frmSachTimkiem()
        {
            InitializeComponent();
        }

       public  List<Sach> dsSach = new List<Sach>();
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
            var kq =await _bus.TimkiemSach(ThongtinModel);
            if (kq.Count>0)
            {
                dsSach =  kq;
                this.DialogResult = DialogResult.OK;
                this.Close();   
            }
            else
            {
                lbMessage.Visible = true;
                lbMessage.Text = "Không tìm thấy thông tin Sách";
            }
        }

        private void frmSachTimkiem_Load(object sender, EventArgs e)
        {

        }
    }
}
