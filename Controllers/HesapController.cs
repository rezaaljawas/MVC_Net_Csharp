using Microsoft.AspNetCore.Mvc;
using WebApplication.Models; // Kendi ad alanınızı buraya ekleyin
using Microsoft.AspNetCore.Identity;

namespace WebApplication.Controllers
{
    public class HesapController : Controller
    {
        private readonly UserManager<IdentityUser> _kullaniciYoneticisi;
        private readonly SignInManager<IdentityUser> _girisYoneticisi;

        public HesapController(UserManager<IdentityUser> kullaniciYoneticisi, SignInManager<IdentityUser> girisYoneticisi)
        {
            _kullaniciYoneticisi = kullaniciYoneticisi;
            _girisYoneticisi = girisYoneticisi;
        }

        // GET: Giriş Yap
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        // POST: Giriş Yap
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GirisYap(GirisViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await _girisYoneticisi.PasswordSignInAsync(model.Eposta, model.Sifre, model.BeniHatirla, false);
                if (sonuc.Succeeded)
                {
                    return RedirectToAction("Index", "Urunler");
                }
                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            }
            return View(model);
        }

        // GET: Kayıt Ol
        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }

        // POST: Kayıt Ol
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KayitOl(KayitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var kullanici = new IdentityUser { UserName = model.Eposta, Email = model.Eposta };
                var sonuc = await _kullaniciYoneticisi.CreateAsync(kullanici, model.Sifre);
                if (sonuc.Succeeded)
                {
                    await _girisYoneticisi.SignInAsync(kullanici, isPersistent: false);
                    return RedirectToAction("Index", "Urunler");
                }
                foreach (var hata in sonuc.Errors)
                {
                    ModelState.AddModelError(string.Empty, hata.Description);
                }
            }
            return View(model);
        }

        // POST: Çıkış Yap
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CikisYap()
        {
            await _girisYoneticisi.SignOutAsync();
            return RedirectToAction("Index", "Anasayfa");
        }
    }
}
