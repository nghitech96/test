using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.Models
{
    public class NguoiDungModel
    {
        public string TaiKhoan { set; get; }

        public string MatKhau { set; get; }

        public int NguoiDungId { get; set; }

        public int VaiTroId { get; set; }

        public int TrangThai { get; set; }

    }
}
