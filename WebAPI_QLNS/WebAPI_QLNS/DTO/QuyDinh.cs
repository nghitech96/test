using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.DTO
{
    public class QuyDinh
    {
        [Key]
        public int Id { get; set; }

        [Column("Ten")]
        [StringLength(50)]
        public string Ten { get; set; }

        [Column("GiaTri")]
        [StringLength(50)]
        public string GiaTri { get; set; }

        [Column("Kieu")]
        [StringLength(50)]
        public string Kieu { get; set; }
    }
}
