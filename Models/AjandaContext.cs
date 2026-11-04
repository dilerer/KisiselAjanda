using Microsoft.EntityFrameworkCore;

namespace KisiselAjandaWeb.Models
{
    public class AjandaContext : DbContext
    {
        // SQL'de oluşacak tablolarımız
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<BagimsizNot> BagimsizNotlar { get; set; }
        public DbSet<TakvimGunu> TakvimGunleri { get; set; }
        public DbSet<Yapilacak> Yapilacaklar { get; set; }
        public DbSet<PomodoroKaydi> PomodoroKayitlari { get; set; }
        public DbSet<PanoObjesi> PanoObjeleri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL Server Bağlantı Adresimiz
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=KisiselAjandaDB;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}