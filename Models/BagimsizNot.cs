using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace KisiselAjandaWeb.Models
{
    public class BagimsizNot
    {
        [Key]
        public int NotID { get; set; }

        // Soru işareti (?) sayesinde artık kategori seçmek zorunlu değil
        public int? KategoriID { get; set; }
        
        [ForeignKey("KategoriID")]
        public virtual Kategori? Kategori { get; set; }

        [MaxLength(200)]
        public string Baslik { get; set; }

        public string Icerik { get; set; }

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        public DateTime? GuncellenmeTarihi { get; set; }
    }
}