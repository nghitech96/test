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
    public partial class ThongKeCongNoForm : Form 
    { 
        
        private List<HoaDonBanHang> _dsHD;
        private List<PhieuThuTien> _dsPT;
    
        public ThongKeCongNoForm()
        {
            InitializeComponent();
            dgCN.AutoGenerateColumns = false;
            dgCN.AllowUserToAddRows = false;
            txtNam.Text = DateTime.Now.Year.ToString();

            var dsThang = new int[] {
                1,2,3,4,5,6,7,8,9,10,11,12
            };
            cbThang.DataSource = dsThang;
            cbKhachHang.DataSource = new BindingSource
            {
                DataSource = BL.Ins.KhachHang.LayDuLieu()
            };
            cbKhachHang.DisplayMember = "Ten";
            cbKhachHang.ValueMember = "Id";
            cbKhachHang.SelectedIndex = 0;

            _dsHD = BL.Ins.HoaDonBanHang.LayDuLieu();
            _dsPT = BL.Ins.PhieuThuTien.LayDuLieu();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var idKhachHang = cbKhachHang.SelectedValue.ToInt32();
            var nam = (txtNam.Text ?? DateTime.Now.Year.ToString()).ToInt32();
            var thang = cbThang.SelectedItem.ToInt32();


            var tk = BL.Ins.ThongKe.BaoCaoCongNo(thang, nam, idKhachHang, _dsHD, _dsPT);

            lbTonDauKy.Text = tk.DauKy.ToString();
            lbTongThu.Text = tk.Giam.ToString();
            lbTongNo.Text = tk.Tang.ToString();
            lbNoCuoiKy.Text = tk.CuoiKy.ToString();
            dgCN.DataSource = tk.DS;
            dgCN.Update();
            dgCN.Refresh();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
