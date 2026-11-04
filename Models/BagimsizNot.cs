using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace KisiselAjandaWeb.Models
{
    public class BagimsizNot
    {
        [Key]
        public int NotID { get; set; }

        // SQL'deki FOREIGN KEY bağlantısı (Kategoriye kancalama)
        public int KategoriID { get; set; }
        
        [ForeignKey("KategoriID")]
        public virtual Kategori Kategori { get; set; }

        [MaxLength(200)]
        public string Baslik { get; set; }

        public string Icerik { get; set; } // MaxLength yazmazsan SQL'de NVARCHAR(MAX) olur

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now; // DEFAULT GETDATE()

        public DateTime? GuncellenmeTarihi { get; set; } // Soru işareti boş geçilebilir (Null) demek
    }
}