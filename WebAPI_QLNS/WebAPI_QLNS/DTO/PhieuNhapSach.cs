using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebAPI_QLNS.DTO
{
    public class PhieuNhapSach
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Column("Ngay")]
        public DateTime Ngay { get; set; }
        public virtual ICollection<ChiTietNhapSach> ChiTietNhapSaches { get; set; }
    }
}
