using Microsoft.AspNetCore.Mvc;
using KisiselAjandaWeb.Models;
using System.Linq;

namespace KisiselAjandaWeb.Controllers
{
    public class YapilacaklarController : Controller
    {
        private readonly AjandaContext _context;

        public YapilacaklarController(AjandaContext context)
        {
            _context = context;
        }

        // LİSTELEME (Read)
        public IActionResult Index()
        {
            // Görevleri tarihe göre sıralı getiriyoruz
            var gorevler = _context.Yapilacaklar.OrderBy(x => x.Tarih).ToList();
            return View(gorevler);
        }

        // EKLEME FORMU (Create - GET)
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        // EKLEME İŞLEMİ (Create - POST)
        [HttpPost]
        public IActionResult Ekle(Yapilacak yeniGorev)
        {
            var secilenTarih = yeniGorev.Tarih.Date;
            yeniGorev.Tarih = secilenTarih;

            var takvimGunu = _context.TakvimGunleri.FirstOrDefault(x => x.Tarih == secilenTarih);

            if (takvimGunu == null)
            {
                takvimGunu = new TakvimGunu
                {
                    Tarih = secilenTarih,
                    GununOzeti = "",
                    DurumRengi = "#27272a",
                    GununNotu = ""
                };
                _context.TakvimGunleri.Add(takvimGunu);
                _context.SaveChanges();
            }

            yeniGorev.TamamlandiMi = false;
            _context.Yapilacaklar.Add(yeniGorev);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DURUM DEĞİŞTİRME (Tamamlandı / Tamamlanmadı Toggle)
        public IActionResult DurumDegistir(int id)
        {
            var gorev = _context.Yapilacaklar.Find(id);
            if (gorev != null)
            {
                // True ise False, False ise True yapar
                gorev.TamamlandiMi = !gorev.TamamlandiMi;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // SİLME İŞLEMİ (Delete)
        public IActionResult Sil(int id)
        {
            var gorev = _context.Yapilacaklar.Find(id);
            if (gorev != null)
            {
                _context.Yapilacaklar.Remove(gorev);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}