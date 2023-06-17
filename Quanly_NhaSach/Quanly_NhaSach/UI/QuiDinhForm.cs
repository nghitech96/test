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
    public partial class QuiDinhForm : Form
    {
        private List<QuyDinh> _dsQD;
        public QuiDinhForm()
        {
            InitializeComponent();
            dgQuyDinh.AutoGenerateColumns = false;
            dgQuyDinh.AllowUserToAddRows = false;
            _dsQD = BL.Ins.QuyDinh.LayDuLieu();
            var bds = new BindingSource
            {
                DataSource = _dsQD
            };
            dgQuyDinh.DataSource = bds;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var r = true;
            foreach (var qd in _dsQD)
            {
                r = BL.Ins.QuyDinh.Sua(qd);
            }
            MessageBox.Show("Lưu thành công");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
