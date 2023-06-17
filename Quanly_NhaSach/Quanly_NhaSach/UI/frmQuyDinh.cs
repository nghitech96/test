using AutoMapper.Internal;
using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebAPI_QLNS.Models;

namespace Quanly_NhaSach.UI
{
    public partial class frmQuyDinh : Form
    {
        public frmQuyDinh()
        {
           
            InitializeComponent();
           
        }
        
        QuyDinh_Bus _bus = new QuyDinh_Bus();

        QuyDinh _QuyDinh = new QuyDinh();

        List<QuyDinh> dsQuyDinh = new List<QuyDinh>();
        List<QuyDinh> _dsQuyDinhDel = new List<QuyDinh>();
        List<QuyDinh> _dsQuyDinhChange = new List<QuyDinh>();

        BindingList<QuyDinh> dsQuyDinhL = new BindingList<QuyDinh>();
        private async void frmQuyDinh_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dsQuyDinh.Count > 0)
            {
                _QuyDinh = dsQuyDinh[0];
            }
            else
            {
                _QuyDinh = new QuyDinh
                {
                    Ten = ""
                };

            }
          //  txtQuyDinh.DataBindings.Add("Text", _QuyDinh.Ten, "Ten", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private async void LoadData()
        {
            dsQuyDinh = await _bus.LayDanhsachQuyDinh();
            dsQuyDinhL = new BindingList<QuyDinh>(dsQuyDinh);

            dgvQuyDinh.DataSource = dsQuyDinhL;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        
        
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            List<QuyDinhModel> quyDinhModels = new List<QuyDinhModel>();
            try
            {

                // Xóa các mục đã xóa trước
                if (_dsQuyDinhDel.Count>0)
                {
                    _bus.Map(_dsQuyDinhDel, ref quyDinhModels);
                    foreach (var item in quyDinhModels)
                    {
                        if (item.Id > 0)
                        {
                            var kq0 = await _bus.XoaQuyDinh(item.Id);

                            if (kq0.ResultCode < 0)
                            {
                                throw new Exception(kq0.Message);
                            }
                        }
                    }

                }

                quyDinhModels = new List<QuyDinhModel>();
                // Cập nhật các nội dung đã thay đổi
                if (_dsQuyDinhChange.Count > 0)
                {
                    _bus.Map(_dsQuyDinhChange, ref quyDinhModels);
                    foreach (var item in quyDinhModels)
                    {
                        if (item.Id > 0)
                        {
                            var kq1 = await _bus.CapnhatQuyDinh(item);

                            if (kq1.ResultCode < 0)
                            {
                                throw new Exception(kq1.Message);
                            }
                        }
                        else
                        {
                            var kq2 = await _bus.ThemQuyDinh(item);

                            if (kq2.ResultCode < 0)
                            {
                                throw new Exception(kq2.Message);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvQuyDinh_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (dg.CurrentRow == null)
                return;
            if (dg.CurrentRow.DataBoundItem == null)
                return;
            var item = GetDataCurrentfromGridView(dg);
            
        }
        private QuyDinh GetDataCurrentfromGridView(DataGridView dgv)
        {
            
            //DataRow dr = (dg.CurrentRow.DataBoundItem as DataRowView).Row;
            var item = (QuyDinh)dgv.CurrentRow.DataBoundItem;
            //txtQuyDinh.Text = item.Ten;
            return item;
        }

        //private void btnAddItem_Click(object sender, EventArgs e)
        //{
        //    var bdList = (BindingList<QuyDinh>)dgvQuyDinh.DataSource;
        //    if (bdList==null)
        //    {
        //        return;
        //    }
        //    var item = bdList.AddNew();
            
        //}

        //private async void btnDeleteItem_Click(object sender, EventArgs e)
        //{
        //    if (dgvQuyDinh.CurrentRow ==null)
        //    {
        //        return;
        //    }
        //    if (dgvQuyDinh.CurrentRow.DataBoundItem == null)
        //    {
        //        return;
        //    }
        //    var bdList = (BindingList<QuyDinh>)dgvQuyDinh.DataSource;
        //    if (bdList == null)
        //    {
        //        return;
        //    }


        //    var row = (QuyDinh)dgvQuyDinh.CurrentRow.DataBoundItem;

        //    if (row.Id <= 6)
        //    {
        //        MessageBox.Show("Bạn không được xóa Nội dung này", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    } 
        //    DialogResult result = MessageBox.Show("Bạn muốn xóa","Xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
        //    if (result == DialogResult.No)
        //    {
        //        return;
        //    }
        //    _dsQuyDinhDel.Add(row); 
        //    bdList.Remove(row);
            
        //}

        private void dgvQuyDinh_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grd = (DataGridView)sender;
            if (grd.CurrentRow == null)
            {
                return;
            }
            var selectRow = grd.CurrentRow.DataBoundItem;
            if (selectRow != null)
            {
                 //var name = grd.Columns[e.ColumnIndex].Name;

                if (grd.Columns[e.ColumnIndex].Name == "ColGiaTri" || grd.Columns[e.ColumnIndex].Name == "ColKieu" || grd.Columns[e.ColumnIndex].Name == "ColTen")
                {
                    var item = (QuyDinh)grd.CurrentRow.DataBoundItem;


                    var i = _dsQuyDinhChange.FirstOrDefault(x => x.Id == item.Id);
                    if (i == null)
                    {
                        _dsQuyDinhChange.Add(item);
                    }
                    else
                    {
                        i.Id=item.Id;
                        i.Ten = item.Ten
                            ;
                        i.GiaTri = item.GiaTri;
                        i.Kieu = item.Kieu;
                    }
                    

                }

            }
        }

        private void frmQuyDinh_Leave(object sender, EventArgs e)
        {
            Common.Initial();
        }
    }
}
