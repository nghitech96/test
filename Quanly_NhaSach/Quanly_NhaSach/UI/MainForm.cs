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
    public partial class MainForm : Form
    {
        private KhachHangForm khachHangForm;
        private TacGiaForm tacGiaForm;
        private TheLoaiForm theLoaiForm ;
        private SachForm sachForm;
        private HoaDonBanHangForm hoaDonBanHangForm;
        private PhieuNhapForm phieuNhapForm;
        private PhieuThuTienForm PhieuThuTienForm ;
        private TraCuuSachForm traCuuSachForm ;
        private ThongKeNhapXuatTonForm thongKeNhapXuatTonForm;
        private QuiDinhForm quiDinhForm;
        private ThongKeCongNoForm thongKeCongNoForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTacGiaForm_Click(object sender, EventArgs e)
        {
            tacGiaForm = new TacGiaForm();
            this.Hide();
            tacGiaForm.ShowDialog();
            this.Show();

        }

        private void btnTheLoaiForm_Click(object sender, EventArgs e)
        {
            theLoaiForm = new TheLoaiForm();
            this.Hide();
            theLoaiForm.ShowDialog();
            this.Show();
        }

        private void btnSachForm_Click(object sender, EventArgs e)
        {
            sachForm = new SachForm();
            this.Hide();
            sachForm.ShowDialog();
            this.Show();
        }

        private void btnPhieuNhapForm_Click(object sender, EventArgs e)
        {
            phieuNhapForm = new PhieuNhapForm();
            this.Hide();
            phieuNhapForm.ShowDialog();
            this.Show();
        }

        private void btnHoaDonForm_Click(object sender, EventArgs e)
        {
            hoaDonBanHangForm = new HoaDonBanHangForm();
            this.Hide();
            hoaDonBanHangForm.ShowDialog();
            this.Show();
        }

        private void btnPhieuThuTien_Click(object sender, EventArgs e)
        {
            PhieuThuTienForm = new PhieuThuTienForm();
            this.Hide();
            PhieuThuTienForm.ShowDialog();
            this.Show();
        }

        private void btnKhachHangForm_Click(object sender, EventArgs e)
        {
            khachHangForm = new KhachHangForm();
            this.Hide();
            khachHangForm.ShowDialog();
            this.Show();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            traCuuSachForm = new TraCuuSachForm();
            this.Hide();
            traCuuSachForm.ShowDialog();
            this.Show();
        }

        private void btnTKNXT_Click(object sender, EventArgs e)
        {
            thongKeNhapXuatTonForm = new ThongKeNhapXuatTonForm();
            this.Hide();
            thongKeNhapXuatTonForm.ShowDialog();
            this.Show();
        }

        private void btnQuyDinh_Click(object sender, EventArgs e)
        {
            quiDinhForm = new QuiDinhForm();
            this.Hide();
            quiDinhForm.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thongKeCongNoForm = new ThongKeCongNoForm();
            this.Hide();
            thongKeCongNoForm.ShowDialog();
            this.Show();
        }
    }
}
