namespace WebApplication.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Urun
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Adi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [Range(0, 10000)]
        public decimal Fiyat { get; set; }

        [Range(0, 1000)]
        public int Stok { get; set; }

        [StringLength(50)]
        public string Kategori { get; set; }
    }
}
