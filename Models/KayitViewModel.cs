using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class KayitViewModel
    {
        [Required]
        [EmailAddress]
        public string Eposta { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifreyi Onayla")]
        [Compare("Sifre", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string SifreyiOnayla { get; set; }
    }
}
