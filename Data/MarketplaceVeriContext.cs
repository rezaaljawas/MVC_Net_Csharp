using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Data
{
    public class MarketplaceVeriContext : IdentityDbContext<IdentityUser> // IdentityDbContext'ten türemek
    {
        // DbContextOptions ile Yapıcı (Constructor)
        public MarketplaceVeriContext(DbContextOptions<MarketplaceVeriContext> options)
            : base(options)
        {
        }

        // Ürünler tablosu için DbSet
        public DbSet<WebApplication.Models.Urun> Urunler { get; set; }
    }
}