using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace KisiselAjandaWeb.Models
{
    public class TakvimGunu
    {
        [Key]
        public DateTime Tarih { get; set; } // Tarihi Primary Key yaptık

        [MaxLength(500)]
        public string GununOzeti { get; set; }

        [MaxLength(20)]
        public string DurumRengi { get; set; }

        public string GununNotu { get; set; }

        // Takvime bağlı olan diğer tablolara giden yollar (Ok işaretleri)
        public virtual ICollection<Yapilacak> Yapilacaklar { get; set; }
        public virtual ICollection<PomodoroKaydi> PomodoroKayitlari { get; set; }
        public virtual ICollection<PanoObjesi> PanoObjeleri { get; set; }
    }
}