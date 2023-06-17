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

namespace Quanly_NhaSach.UI
{
    public partial class frmBaocao_XuatNhap : Form
    {
        public frmBaocao_XuatNhap()
        {
            InitializeComponent();
            dgvThongke.Columns["ColSoluong"].DefaultCellStyle.Format = "N0";
            dgvThongke.Columns["ColTon"].DefaultCellStyle.Format = "N0";
        }
        Sach_Bus _sach = new Sach_Bus();
        ThongkeBaoCao_Bus tkbao = new ThongkeBaoCao_Bus();


        List<Sach> dsSach = new List<Sach>();
        
        BindingList<Sach> bdSach = new BindingList<Sach>();

        ThongtinThongkeModel thongtin = new ThongtinThongkeModel();
        private void frmBaocao_XuatNhap_Load(object sender, EventArgs e)
        {
            var dsThang =new List<int> { 1,2,3,4,5,6,7,8,9,10,11,12};
            var nam = DateTime.Now.Year;
            var dsNam = new List<int> {
                nam,nam-1,nam-2,nam-3,nam-4
            };

            cbThang.DataSource=dsThang;
            cbNam.DataSource = dsNam;

            LayDanhsachSach();
        }
        private async void LayDanhsachSach()
        {
            dsSach = await _sach.LayDanhsachSach();
            bdSach = new BindingList<Sach>(dsSach);

            cbSach.ValueMember = "Id";
            cbSach.DisplayMember = "Ten";
            cbSach.DataSource = bdSach;
        }

        private async void btnThongke_Click(object sender, EventArgs e)
        {
            thongtin = new ThongtinThongkeModel
            {
                Thang = cbThang.SelectedValue.ToInt32(),
                Nam =cbNam.SelectedValue.ToInt32(),
                Id = cbSach.SelectedValue.ToInt32()
            };

            var kq = await tkbao.BaocaoNhapxuatTon(thongtin);

            if (kq!=null)
            {
                DisplayData(kq);
                DanhsoTT();
            }

        }
        void DanhsoTT()
        {
            for (int i = 0; i < dgvThongke.Rows.Count; i++)
            {
                dgvThongke.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void DisplayData(ThongKeNXTTrongKy data)
        {
            txtDauky.Text=data.DauKy.ToString();
           txtCuoiky.Text=data.CuoiKy.ToString();
           txtTang.Text=data.Tang.ToString();
           txtGiam.Text=data.Giam.ToString();

            dgvThongke.DataSource = data.DS;

        }
    }
}
