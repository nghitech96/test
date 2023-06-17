using Quanly_NhaSach.Helpers;
using Quanly_NhaSach.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanly_NhaSach
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            toolStripStatusLabel_Nguoidung.Text = "";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetAllMenu(false);
        }

       
        private void Hethong_Thoat_mnu_Click(object sender, EventArgs e)
        {
            this.Close();

        }

       

        private void Hethong_DangXuat_mnu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất khỏi chương trình?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result== DialogResult.No)
            {
                return;
            }
            SetAllMenu(false);
            toolStripStatusLabel_Nguoidung.Text = "";

        }

        private void Hethong_Dangnhap_mnu_Click(object sender, EventArgs e)
        {
            Form frm1 = new UI.frmDangNhap();
            frm1.Owner = this;
            //frm.Parent = this;
            frm1.StartPosition = FormStartPosition.CenterParent;
            frm1.ShowDialog(this);
            if (Common.isLogin)
            {
                Common.Initial();
                SetAllMenu(true);
                toolStripStatusLabel_Nguoidung.Text = Common.Nguoidung.TenNhanVien;
                
            }
            
        }
        private void Hethong_QuyDinh_mnu_Click(object sender, EventArgs e)
        {
            Form frm2 = new UI.frmQuyDinh();
            frm2.Owner = this;
            //frm.Parent = this;
            frm2.StartPosition = FormStartPosition.CenterParent;
            frm2.ShowDialog(this);
            frm2.Dispose();
        }
        private void Hethong_TheLoai_mnu_Click(object sender, EventArgs e)
        {
            Form frm3 = new UI.frmTheLoai();
            frm3.Owner = this;
            //frm.Parent = this;
            frm3.StartPosition = FormStartPosition.CenterParent;
            frm3.ShowDialog(this);
            frm3.Dispose();
        }
       

        private void Hethong_Sach_mnu_Click(object sender, EventArgs e)
        {
            Form frm4 = new UI.frmSach();
            frm4.Owner = this;
            //frm.Parent = this;
            frm4.StartPosition = FormStartPosition.CenterParent;
            frm4.ShowDialog(this);
            frm4.Dispose();
        }

        private void Hethong_Tacgia_mnu_Click(object sender, EventArgs e)
        {
            Form frm5 = new UI.frmTacGia();
            frm5.Owner = this;
            //frm.Parent = this;
            frm5.StartPosition = FormStartPosition.CenterParent;
            frm5.ShowDialog(this);
            frm5.Dispose();
        }
        private void NhapHang_PhieuNhap_mnu_Click(object sender, EventArgs e)
        {
            Form frm6 = new UI.frmPhieuNhapSach();
            frm6.Owner = this;
            //frm.Parent = this;
            frm6.StartPosition = FormStartPosition.CenterParent;
            frm6.ShowDialog(this);
            frm6.Dispose();
        }
        private void BanHang_Khachhang_mnu_Click(object sender, EventArgs e)
        {
            Form frmkh = new UI.frmKhachHang();
            frmkh.Owner = this;
            //frm.Parent = this;
            frmkh.StartPosition = FormStartPosition.CenterParent;
            frmkh.ShowDialog(this);
        }
        private void BanHang_Sach_mnu_Click(object sender, EventArgs e)
        {
            Form frm7 = new UI.frmHoaDonBanHang();
            frm7.Owner = this;
            //frm.Parent = this;
            frm7.StartPosition = FormStartPosition.CenterParent;
            frm7.ShowDialog(this);
            frm7.Dispose();
        }

        private void BanHang_Phieuthu_mnu_Click(object sender, EventArgs e)
        {
            Form frm8 = new UI.frmPhieuThuTien();
            frm8.Owner = this;
            //frm.Parent = this;
            frm8.StartPosition = FormStartPosition.CenterParent;
            frm8.ShowDialog(this);

        }

        private void Baocao_XuatNhap_mnu_Click(object sender, EventArgs e)
        {
            Form frm9 = new UI.frmBaocao_XuatNhap();
            frm9.Owner = this;
            //frm.Parent = this;
            frm9.StartPosition = FormStartPosition.CenterParent;
            frm9.ShowDialog(this);
        }

        private void Baocao_CongNo_mnu_Click(object sender, EventArgs e)
        {
            Form frm10 = new UI.frmBaoCao_CongNo();
            frm10.Owner = this;
            //frm.Parent = this;
            frm10.StartPosition = FormStartPosition.CenterParent;
            frm10.ShowDialog(this);
        }
        private void Baocao_TracuuSach_mnu_Click(object sender, EventArgs e)
        {
            Form frm11 = new UI.frmTracuuSach();
            frm11.Owner = this;
            //frm.Parent = this;
            frm11.StartPosition = FormStartPosition.CenterParent;
            frm11.ShowDialog(this);
        }
        private void SetAllMenu(bool value)
        {
            Hethong_DangXuat_mnu.Enabled=value;
            Hethong_Dangnhap_mnu.Enabled=!value;

            Hethong_QuyDinh_mnu.Enabled = value;
            Hethong_Sach_mnu.Enabled=value;
            Hethong_Tacgia_mnu.Enabled=value;
            Hethong_TheLoai_mnu.Enabled=value;

            NhapHang_PhieuNhap_mnu.Enabled= value;

            BanHang_Sach_mnu.Enabled = value;
            BanHang_Phieuthu_mnu.Enabled = value;
            BanHang_Khachhang_mnu.Enabled = value;

            Baocao_CongNo_mnu.Enabled= value;
            Baocao_XuatNhap_mnu.Enabled = value;
            Baocao_TracuuSach_mnu.Enabled = value;


        }

       
    }
}
