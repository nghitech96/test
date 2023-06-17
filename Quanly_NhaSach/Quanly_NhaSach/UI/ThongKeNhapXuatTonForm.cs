using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanly_NhaSach.GUI
{
    public partial class ThongKeNhapXuatTonForm : Form
    {
        
        public class PhieuNhapXuat
        {
            public string Id { get; set; }
            public string Loai {get; set;}
            public long SoLuong {get; set;}
            public DateTime Ngay {get; set;}
            public long Ton { get; set; }
        }
        private List<HoaDonBanHang> _dsHD;
        private List<PhieuNhapSach> _dsPN;
        public ThongKeNhapXuatTonForm()
        {
            InitializeComponent();
            dgNXT.AutoGenerateColumns = false;
            dgNXT.AllowUserToAddRows = false;
            txtNam.Text = DateTime.Now.Year.ToString();

            var dsThang = new int[] { 
                1,2,3,4,5,6,7,8,9,10,11,12
            };
            cbThang.DataSource = dsThang;
            cbSach.DataSource = new BindingSource
            {
                DataSource = BL.Ins.Sach.LayDuLieu()
            };
            cbSach.DisplayMember = "Ten";
            cbSach.ValueMember = "Id";
            cbSach.SelectedIndex = 0;

            _dsHD = BL.Ins.HoaDonBanHang.LayDuLieu();
            _dsPN = BL.Ins.PhieuNhapSach.LayDuLieu();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var idSach = cbSach.SelectedValue.ToInt32();
            var nam = (txtNam.Text ?? DateTime.Now.Year.ToString()).ToInt32();
            var thang = cbThang.SelectedItem.ToInt32();

            var tk = BL.Ins.ThongKe.BaoCaoNXT(thang, nam, idSach, _dsHD, _dsPN);
            lbTonDauKy.Text = tk.DauKy.ToString();
            lbTongNhap.Text = tk.Tang.ToString();
            lbTongXuat.Text = tk.Giam.ToString();
            lbTonCuoiKy.Text = tk.CuoiKy.ToString();
            dgNXT.DataSource = tk.DS;
            dgNXT.Update();
            dgNXT.Refresh();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
