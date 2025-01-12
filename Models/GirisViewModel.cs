using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class GirisViewModel
    {
        [Required]
        [EmailAddress]
        public string Eposta { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool BeniHatirla { get; set; }
    }
}
