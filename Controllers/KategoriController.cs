using Microsoft.AspNetCore.Mvc;
using KisiselAjandaWeb.Models;
using System.Linq;

namespace KisiselAjandaWeb.Controllers
{
    public class KategoriController : Controller
    {
        private readonly AjandaContext _context;

        public KategoriController(AjandaContext context)
        {
            _context = context;
        }

        // 1. LİSTELEME (Read)
        public IActionResult Index()
        {
            var kategoriler = _context.Kategoriler.ToList(); 
            return View(kategoriler);
        }

        // 2. EKLEME FORMU (Create - GET)
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        // 3. EKLEME İŞLEMİ (Create - POST)
        [HttpPost]
        public IActionResult Ekle(Kategori yeniKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Kategoriler.Add(yeniKategori);
                _context.SaveChanges(); 
                return RedirectToAction("Index"); 
            }
            return View(yeniKategori);
        }

        // 4. SİLME İŞLEMİ (Delete)
        public IActionResult Sil(int id)
        {
            var kategori = _context.Kategoriler.Find(id); // SQL'den bul
            if (kategori != null)
            {
                _context.Kategoriler.Remove(kategori); // SQL'den uçur
                _context.SaveChanges(); // Değişikliği kaydet
            }
            return RedirectToAction("Index");
        }

        // 5. GÜNCELLEME FORMU (Update - GET)
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var kategori = _context.Kategoriler.Find(id); // Güncellenecek veriyi bul
            if (kategori == null)
            {
                return RedirectToAction("Index");
            }
            return View(kategori); // Veriyi formun içine doldurarak gönder
        }

        // 6. GÜNCELLEME İŞLEMİ (Update - POST)
        [HttpPost]
        public IActionResult Guncelle(Kategori guncelKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Kategoriler.Update(guncelKategori); // SQL'de üzerine yaz
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guncelKategori);
        }
    }
}