using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_QLNS.DTO
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
