using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quanly_NhaSach.DTO
{
    public class VaiTro
    {
        [Key]
        public int Id { get; set; }
        [Column("TenVaiTro")]
        [StringLength(150)]
        public string TenVaiTro { get; set; }
    }
}
