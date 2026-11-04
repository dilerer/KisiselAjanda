using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace KisiselAjandaWeb.Models
{
    public class PanoObjesi
    {
        [Key]
        public int ObjelD { get; set; }

        public DateTime Tarih { get; set; }
        [ForeignKey("Tarih")]
        public virtual TakvimGunu TakvimGunu { get; set; }

        [MaxLength(50)]
        public string ObjeTuru { get; set; }

        public string Icerik { get; set; }

        // Ekrandaki Sürükle-Bırak Koordinatları (INT karşılıkları)
        public int KonumX { get; set; }
        public int KonumY { get; set; }
        public int Genislik { get; set; }
        public int Yukseklik { get; set; }

        [MaxLength(20)]
        public string ArkaPlanRengi { get; set; }
    }
}