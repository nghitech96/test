using Quanly_NhaSach.BUS;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanly_NhaSach.Helpers
{


    enum QuyDinhenum
    {
        QD1_1 = 1,
        QD1_2 = 2,
        QD2_1 = 3,
        QD2_2 = 4,
        QD3 = 5,
        QD4 = 6,

    }
    public class Common
    {


        public static bool isLogin = false;
        public static AccountModel Account = new AccountModel();
        public static NguoiDungDangnhap Nguoidung;
        public static string apiBasicUri = "";
        public static string Token; 
        
        private static int _quydinh1_1 = 150;
        private static int _quydinh1_2 = 300;
        private static int _quydinh2_1 = 150;
        private static int _quydinh2_2 = 150;
        private static bool _quydinh3 = false;
        private static bool _quydinh4 = true;
        public static int QD1_1 {
            // Số lượng sách nhập ít nhất là phải lớn hơn hoặc bằng giá trị này
            get {
                return _quydinh1_1;
            }
            set { _quydinh1_1 = value; } 
        }
        public static int QD1_2
        {
            // Chỉ nhập các đầu sách có Số lượng tồn ít hơn giá trị này
            get  { return _quydinh1_2; }
            set { _quydinh1_2 = value; }
        }
        public static int QD2_1
        {
            //Chỉ bán cho các khách hàng có nợ không quá giá trị này
            get { return _quydinh2_1; }
            set { _quydinh2_1 = value; }
        }
        public static int QD2_2 {
            // các đầu sách có số lượng tồn sau khi bán ít nhất bằng giá trị này
            get { return _quydinh2_2; }
            set { _quydinh2_2 = value; }
        }
        public static bool QD3
        {
            //Số tiền thu không quá số tiền khách hàng nợ (true - cho phép nhập số tiền vượt số nợ, false không cho phép nhập quá số tiền nợ
            get { return _quydinh3; }
            set { _quydinh3 = value; }
        }
        public static bool QD4
        {
            // Cho phép sử dụng quy định hay không : true - cho phép, false - không dùng
            get { return _quydinh4; }
            set { _quydinh4 = value; }
        }
        static QuyDinh_Bus _qd = new QuyDinh_Bus();
        public static async void Initial()
        {
            var quydinh = await _qd.LayDanhsachQuyDinh();
            var kq1_1 = quydinh.FirstOrDefault(x => x.Id == QuyDinhenum.QD1_1.ToInt32()).GiaTri;
            var kq1_2 = quydinh.FirstOrDefault(x => x.Id == QuyDinhenum.QD1_2.ToInt32()).GiaTri;
            var kq2_1 = quydinh.FirstOrDefault(x => x.Id == QuyDinhenum.QD2_1.ToInt32()).GiaTri;
            var kq2_2 = quydinh.FirstOrDefault(x => x.Id == QuyDinhenum.QD2_2.ToInt32()).GiaTri;
            var kq3 = quydinh.FirstOrDefault(x => x.Id == QuyDinhenum.QD3.ToInt32()).GiaTri;
            var kq4 = quydinh.FirstOrDefault(x => x.Id == QuyDinhenum.QD4.ToInt32()).GiaTri;

            if (!string.IsNullOrEmpty(kq1_1))
            {
                _quydinh1_1 = int.Parse(kq1_1);
            }
            if (!string.IsNullOrEmpty(kq1_2))
            {
                _quydinh1_2 = int.Parse(kq1_2);
            }
            if (!string.IsNullOrEmpty(kq2_1))
            {
                _quydinh2_1 = int.Parse(kq2_1);
            }
            if (!string.IsNullOrEmpty(kq2_2))
            {
                _quydinh2_2 = int.Parse(kq2_2);
            }
            if (!string.IsNullOrEmpty(kq3))
            {
                _quydinh3 = bool.Parse(kq3);
            }
            if (!string.IsNullOrEmpty(kq4))
            {
                _quydinh4 = bool.Parse(kq4);
            }
        }

    }


    enum StatusCode
    {
        InvalidAuthorization = 500,

    }

}
