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
    public partial class TraCuuSachForm : Form
    {
        private List<HoaDonBanHang> _dsHD;
        private List<PhieuNhapSach> _dsPN;
        private List<TacGia> _dsTacGia;
        private List<TheLoai> _dsTheLoai;
        public TraCuuSachForm()
        {
            InitializeComponent();
            dgSach.AutoGenerateColumns = false;
            dgSach.AllowUserToAddRows = false;

            _dsHD = BL.Ins.HoaDonBanHang.LayDuLieu();
            _dsPN = BL.Ins.PhieuNhapSach.LayDuLieu();
            _dsTacGia = BL.Ins.TacGia.LayDuLieu();
            _dsTheLoai = BL.Ins.TheLoai.LayDuLieu();

            var cot = dgSach.Columns[1] as DataGridViewComboBoxColumn;
            cot.DisplayMember = "Ten";
            cot.ValueMember = "Id";
            cot.DataSource = _dsTheLoai;

            cot = dgSach.Columns[2] as DataGridViewComboBoxColumn;
            cot.DisplayMember = "Ten";
            cot.ValueMember = "Id";
            cot.DataSource = _dsTacGia;
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            var tuKhoa = txtTuKhoa.Text ?? "";
            tuKhoa = tuKhoa.ToUpper();
            
            List<Sach> dsSach = BL.Ins.Sach.LayDuLieu().Where(s=>s.Ten.ToUpper().Contains(tuKhoa)).ToList();
            Dictionary<int, Sach> dic = new Dictionary<int, Sach>();
            foreach (Sach s in dsSach)
            {
                s.Ton = 0;
                dic.Add(s.Id, s);
            }

            foreach (var hd in _dsHD)
            {
                foreach (var ct in hd.ChiTietHoaDons)
                {
                    if (dic.ContainsKey(ct.IdSach))
                    {
                        dic[ct.IdSach].Ton -= ct.SoLuong;
                    }
                }
            }
            foreach (var pn in _dsPN)
            {
                foreach (var ct in pn.ChiTietNhapSaches)
                {
                    if (dic.ContainsKey(ct.IdSach))
                    {
                        dic[ct.IdSach].Ton += ct.SoLuong;
                    }
                }
            }

            dgSach.DataSource = dsSach;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
