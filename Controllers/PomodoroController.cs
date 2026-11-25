using Microsoft.AspNetCore.Mvc;
using KisiselAjandaWeb.Models;
using System;
using System.Linq;

namespace KisiselAjandaWeb.Controllers
{
    public class PomodoroController : Controller
    {
        private readonly AjandaContext _context;

        public PomodoroController(AjandaContext context)
        {
            _context = context;
        }

        // POMODORO SAYFASI VE GEÇMİŞ KAYITLAR
        public IActionResult Index()
        {
            var bugun = DateTime.Today;
            var kayitlar = _context.PomodoroKayitlari
                .OrderByDescending(x => x.BaslangicZamani)
                .ToList();

            ViewBag.BugunToplamDakika = kayitlar
                .Where(x => x.Tarih.Date == bugun)
                .Sum(x => x.ToplamDakika);

            return View(kayitlar);
        }

        // JAVASCRIPT'TEN GELEN BİTİŞ İSTEĞİNİ SQL'E KAYDEDER
        [HttpPost]
        public IActionResult Kaydet([FromBody] PomodoroIstek istek)
        {
            if (istek == null || istek.ToplamDakika <= 0)
            {
                return BadRequest(new { basarili = false, mesaj = "Geçersiz süre." });
            }

            var bugun = DateTime.Today;

            // Foreign Key bütünlüğü: TakvimGunu yoksa önce bugünü aç
            var takvimGunu = _context.TakvimGunleri.FirstOrDefault(x => x.Tarih == bugun);
            if (takvimGunu == null)
            {
                takvimGunu = new TakvimGunu
                {
                    Tarih = bugun,
                    GununOzeti = "",
                    DurumRengi = "#27272a",
                    GununNotu = ""
                };
                _context.TakvimGunleri.Add(takvimGunu);
                _context.SaveChanges();
            }

            var etiket = string.IsNullOrWhiteSpace(istek.DersEtiketi)
                ? "Genel Çalışma"
                : istek.DersEtiketi.Trim();

            if (etiket.Length > 100)
                etiket = etiket.Substring(0, 100);

            var yeniKayit = new PomodoroKaydi
            {
                Tarih = bugun,
                BaslangicZamani = DateTime.Now.AddMinutes(-istek.ToplamDakika),
                ToplamDakika = istek.ToplamDakika,
                DersEtiketi = etiket
            };

            _context.PomodoroKayitlari.Add(yeniKayit);
            _context.SaveChanges();

            return Json(new { basarili = true, id = yeniKayit.KayitID });
        }

        // KAYIT SİLME
        public IActionResult Sil(int id)
        {
            var kayit = _context.PomodoroKayitlari.Find(id);
            if (kayit != null)
            {
                _context.PomodoroKayitlari.Remove(kayit);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

    public class PomodoroIstek
    {
        public int ToplamDakika { get; set; }
        public string DersEtiketi { get; set; }
    }
}