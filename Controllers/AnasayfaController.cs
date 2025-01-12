using Microsoft.AspNetCore.Mvc;

namespace Web_Uygulama.Controllers
{
    public class AnasayfaController : Controller
    {
        // Anasayfa için aksiyon
        public IActionResult Index()
        {
            return View();
        }
    }
}
