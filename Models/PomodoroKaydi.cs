using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace KisiselAjandaWeb.Models
{
    public class PomodoroKaydi
    {
        [Key]
        public int KayitID { get; set; }

        public DateTime Tarih { get; set; }
        [ForeignKey("Tarih")]
        public virtual TakvimGunu TakvimGunu { get; set; }

        public DateTime BaslangicZamani { get; set; }

        public int ToplamDakika { get; set; }

        [MaxLength(100)]
        public string DersEtiketi { get; set; }
    }
}