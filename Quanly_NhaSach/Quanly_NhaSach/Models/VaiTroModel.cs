using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quanly_NhaSach.Models
{
    public class VaiTroModel
    {
        public int Id { get; set; }
        public string TenVaiTro { get; set; }
    }
}
