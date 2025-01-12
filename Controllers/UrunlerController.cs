using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Data;
using WebApplication.Models;

public class UrunlerController : Controller
{
    private readonly MarketplaceVeriContext _context;

    public UrunlerController(MarketplaceVeriContext context)
    {
        _context = context;
    }

    // GET: Urunler
    public IActionResult Index()
    {
        return View(_context.Urunler.ToList());
    }

    // GET: Urunler/Detaylar/5
    public IActionResult Detaylar(int? id)
    {
        if (id == null)
            return NotFound();

        var urun = _context.Urunler.FirstOrDefault(p => p.Id == id);
        if (urun == null)
            return NotFound();

        return View(urun);
    }

    // GET: Urunler/Olustur
    public IActionResult Olustur()
    {
        return View();
    }

    // POST: Urunler/Olustur
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Olustur([Bind("Id,Adi,Aciklama,Fiyat,Stok,Kategori")] Urun urun)
    {
        if (ModelState.IsValid)
        {
            _context.Add(urun);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(urun);
    }

    // GET: Urunler/Duzenle/5
    public IActionResult Duzenle(int? id)
    {
        if (id == null)
            return NotFound();

        var urun = _context.Urunler.Find(id);
        if (urun == null)
            return NotFound();

        return View(urun);
    }

    // POST: Urunler/Duzenle/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Duzenle(int id, [Bind("Id,Adi,Aciklama,Fiyat,Stok,Kategori")] Urun urun)
    {
        if (id != urun.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(urun);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(urun);
    }

    // GET: Urunler/Sil/5
    public IActionResult Sil(int? id)
    {
        if (id == null)
            return NotFound();

        var urun = _context.Urunler.FirstOrDefault(p => p.Id == id);
        if (urun == null)
            return NotFound();

        return View(urun);
    }

    // POST: Urunler/Sil/5
    [HttpPost, ActionName("Sil")]
    [ValidateAntiForgeryToken]
    public IActionResult SilOnayli(int id)
    {
        var urun = _context.Urunler.Find(id);
        _context.Urunler.Remove(urun);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
