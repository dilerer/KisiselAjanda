using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KisiselAjandaWeb.Models;
using System;
using System.Linq;

namespace KisiselAjandaWeb.Controllers
{
    public class NotlarController : Controller
    {
        private readonly AjandaContext _context;

        public NotlarController(AjandaContext context)
        {
            _context = context;
        }

        // LİSTELEME (Read)
        public IActionResult Index()
        {
            var notlar = _context.BagimsizNotlar
                .Include(x => x.Kategori)
                .OrderByDescending(x => x.OlusturulmaTarihi)
                .ToList();
            return View(notlar);
        }

        // EKLEME FORMU (Create - GET)
        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            return View();
        }

        // EKLEME İŞLEMİ (Create - POST)
        [HttpPost]
        public IActionResult Ekle(BagimsizNot yeniNot)
        {
            yeniNot.KategoriID = (yeniNot.KategoriID.HasValue && yeniNot.KategoriID.Value > 0)
                ? yeniNot.KategoriID
                : null;

            yeniNot.Baslik = string.IsNullOrWhiteSpace(yeniNot.Baslik)
                ? "Başlıksız Not"
                : yeniNot.Baslik.Trim();

            yeniNot.Icerik = yeniNot.Icerik ?? "";
            yeniNot.OlusturulmaTarihi = DateTime.Now;
            yeniNot.GuncellenmeTarihi = null;

            _context.BagimsizNotlar.Add(yeniNot);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GÜNCELLEME FORMU (Update - GET)
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var not = _context.BagimsizNotlar.Find(id);
            if (not == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            return View(not);
        }

        // GÜNCELLEME İŞLEMİ (Update - POST)
        [HttpPost]
        public IActionResult Guncelle(BagimsizNot guncelNot)
        {
            var mevcutNot = _context.BagimsizNotlar.Find(guncelNot.NotID);
            if (mevcutNot != null)
            {
                mevcutNot.Baslik = string.IsNullOrWhiteSpace(guncelNot.Baslik)
                    ? "Başlıksız Not"
                    : guncelNot.Baslik.Trim();
                mevcutNot.Icerik = guncelNot.Icerik ?? "";
                mevcutNot.KategoriID = (guncelNot.KategoriID.HasValue && guncelNot.KategoriID.Value > 0)
                    ? guncelNot.KategoriID
                    : null;
                mevcutNot.GuncellenmeTarihi = DateTime.Now;

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // SİLME İŞLEMİ (Delete)
        public IActionResult Sil(int id)
        {
            var not = _context.BagimsizNotlar.Find(id);
            if (not != null)
            {
                _context.BagimsizNotlar.Remove(not);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}