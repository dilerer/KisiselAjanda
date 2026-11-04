using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KisiselAjandaWeb.Models
{
    public class Kategori
    {
        [Key] // SQL'deki PRIMARY KEY IDENTITY(1,1) karşılığı
        public int KategoriID { get; set; }

        [Required] // SQL'deki NOT NULL karşılığı
        [MaxLength(100)] // SQL'deki NVARCHAR(100) karşılığı
        public string KategoriAdi { get; set; }

        [MaxLength(20)]
        public string RenkKodu { get; set; } = "#FFFFFF"; // DEFAULT '#FFFFFF'

        // Bire-Çok İlişki (Bir kategorinin birden fazla notu olabilir)
        public virtual ICollection<BagimsizNot> BagimsizNotlar { get; set; }
    }
}