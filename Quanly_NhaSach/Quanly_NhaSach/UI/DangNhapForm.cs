using Quanly_NhaSach.BUS;
using Quanly_NhaSach.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanly_NhaSach.GUI
{
    public partial class DangNhapForm : Form
    {
        public DangNhapForm()
        {
            InitializeComponent();
            grCauHinh.Visible = false;
            txtMatKhau.UseSystemPasswordChar = true;

            txtServer.Text = GetValue("Server");
            txtInstance.Text = GetValue("Instance");
            txtDatabase.Text = GetValue("Database");
            
           


        }
        private void SetValue(string key, string value)
        {
            var configFile = ConfigurationManager
            .OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            settings[key].Value = value;
           
            configFile.Save(ConfigurationSaveMode.Minimal);

            ConfigurationManager.RefreshSection("appSettings");
            
        }
        private  string GetValue(string key)
        {
            string value = ConfigurationManager
                .AppSettings[key];
            return value;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            var server = txtServer.Text;
            var instance = txtInstance.Text;
            var db = txtDatabase.Text;
            SetValue("Server", server);
            SetValue("Instance", instance);
            SetValue("Database", db);

            var str1 = @"metadata=res://*/DAO.Model1.csdl|res://*/DAO.Model1.ssdl|res://*/DAO.Model1.msl;provider=System.Data.SqlClient;provider connection string=';";
            var str2 = $@"data source={server}\{instance};initial catalog={db};integrated security=True;";
            var str3 = @"MultipleActiveResultSets=True;App=EntityFramework';";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Clear();
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings()
            {
                Name = "QLNSEntities",
                ConnectionString = str1+ str2 + str3,
                ProviderName = "System.Data.EntityClient",
            });

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            if (BL.Ins.KiemTraKetNoi())
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Không thể kết nối");
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var taiKhoan = txtTaiKhoan.Text;
            var matKhau = txtMatKhau.Text;
            if (!string.IsNullOrEmpty(taiKhoan) && !string.IsNullOrEmpty(matKhau))
            {
                var nd = BL.Ins.NguoiDung.KiemTraDangNHap(taiKhoan, matKhau);
                if(nd == null)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                    return;
                }
            }

            var main = new MainForm();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }

        private void btnChuyenDoi_Click(object sender, EventArgs e)
        {
            grCauHinh.Visible = !grCauHinh.Visible;
            grDangNhap.Visible = !grDangNhap.Visible;
            if (grCauHinh.Visible)
            {
                btnChuyenDoi.Text = "Quay Lại";
            }
            else
            {
                btnChuyenDoi.Text = "Thiết Lập";
            }
        }
    
    }
}
