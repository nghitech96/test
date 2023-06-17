using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_QLNS.Models
{
    public class SachModel
    {
        public int Id { get; set; }

        public string Ten { get; set; }

        public int IdTacGia { get; set; }

        public int IdTheLoai { get; set; }

        public long SoluongTon { get; set; }

        
    }
}
