using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.Models
{
    public class QuyDinhModel
    {
        public int Id { get; set; }

        public string Ten { get; set; }

        public string GiaTri { get; set; }

        public string Kieu { get; set; }
    }
}
