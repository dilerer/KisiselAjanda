using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace KisiselAjandaWeb.Models
{
    public class Yapilacak
    {
        [Key]
        public int GorevID { get; set; }

        public DateTime Tarih { get; set; }
        [ForeignKey("Tarih")]
        public virtual TakvimGunu TakvimGunu { get; set; } // Takvime bağladık

        [MaxLength(250)]
        public string GorevMetni { get; set; }

        public bool TamamlandiMi { get; set; } = false; // SQL'deki BIT DEFAULT 0 (True/False)
    }
}